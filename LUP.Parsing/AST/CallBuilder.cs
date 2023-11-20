using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Linq.Expressions;
using System.Reflection;

namespace LUP.Parsing.AST
{
    static class CallBuilder
    {
        private static readonly ConcurrentDictionary<MethodInfo, Call> factories = new();

        private static readonly Type astExprType = typeof(IASTExpression);
        private static readonly MethodInfo getMethod = typeof(IValueExpression)
            .GetMethod(nameof(IValueExpression.GetValue))!;

        public static CallExpression Build(object handler, string name, MethodInfo info)
        {
            if (info.GetGenericArguments().Length > 1)
                throw new Exception("Call methods cannot has generics more than one");

            bool isGeneric = info.IsGenericMethodDefinition;
            Type type = handler.GetType();

            var call = factories.GetOrAdd(info, x => isGeneric == true ?
                BuildGeneric(type, x) : Build(type, x));

            var args = info.GetParameters().Select(x =>
            {
                bool isGeneric = x.ParameterType.IsGenericMethodParameter;
                bool hasGeneric = x.ParameterType.ContainsGenericParameters;

                Type paramType = x.ParameterType;

                if (isGeneric == true)
                    paramType = x.ParameterType.BaseType!;

                else if (hasGeneric == true)
                    paramType = x.ParameterType.GetGenericTypeDefinition();

                return new CallArgument()
                {
                    ArgumentType = paramType,
                    IsGeneric = isGeneric
                };
            });

            return new CallExpression(handler, new CallInfo
            {
                Args = args,
                Call = call,
                Name = name
            });
        }


        public static Call Build(Type handler, MethodInfo info)
        {
            var instance = Expression.Parameter(typeof(object));
            var generic = Expression.Parameter(typeof(Type));
            var array = Expression.Parameter(typeof(IASTExpression[]));
            var parameters = CreateParameters(array, info);

            var call = Expression.Call(Expression.Convert(instance, handler), info, parameters);
            var lambda = Expression.Lambda<Call>(BuildReturn(call, info), instance, generic, array);

            return lambda.Compile();
        }


        private static Call BuildGeneric(Type handler, MethodInfo info)
        {
            var provider = new GenericCallProvider(info, handler);

            return (instance, generic, args) =>
            {
                if (generic == null)
                    throw new InvalidOperationException("Unable to call method without generic parameter");

                return provider.Invoke(instance, generic, args);
            };
        }


        private static Expression[] CreateParameters(Expression array, MethodInfo info)
        {
            var ps = info.GetParameters();

            if (ps.Length == 0)
                return Array.Empty<Expression>();

            var expressions = new Expression[ps.Length];

            for (int i = 0; i < ps.Length; i++)
            {
                var p = Expression.ArrayIndex(array, Expression.Constant(i));
                
                if (astExprType.IsAssignableFrom(ps[i].ParameterType) == true)
                {
                    expressions[i] = Expression.Convert(p, ps[i].ParameterType);
                }
                else
                {
                    var val = Expression.Call(Expression.Convert(p, typeof(IValueExpression)), getMethod);
                    expressions[i] = Expression.Convert(val, ps[i].ParameterType);
                }
            }

            return expressions;
        }


        private static Expression BuildReturn(MethodCallExpression call, MethodInfo info)
        {
            if (info.ReturnType == typeof(void))
                return Expression.Block(call, Expression.Constant(EmptyASTExpression.Instance));

            if (astExprType.IsAssignableFrom(info.ReturnType) == true)
                return call;

            var ctor = typeof(ValueExpression<>).MakeGenericType(info.ReturnType).GetConstructors().First();

            var @new = Expression.New(ctor, call);
            return @new;
        }
    }
}
