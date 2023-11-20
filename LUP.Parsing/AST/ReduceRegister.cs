using LUP.Parsing.AST.Standard;
using System.Collections.Immutable;

namespace LUP.Parsing.AST
{
    public class ReduceRegister
    {
        private static readonly Type astExprType = typeof(IASTExpression);

        private readonly List<CallExpression> calls;
        private readonly Dictionary<string, Type> typesMap;

        public ReduceRegister()
        {
            calls = new();
            typesMap = new(StandardHandlers.Types);

            foreach (var handler in StandardHandlers.Handlers)
                AddHandler(handler);
        }


        public void AddHandler(object handler)
        {
            var type = handler.GetType();
            var methods = CallMethodFinder.Find(type);

            foreach (var (info, name) in methods)
            {
                var call = CallBuilder.Build(handler, name, info);
                calls.Add(call);
            }
        }


        public void AddTypeMap(string name, Type type)
        {
            typesMap.Add(name, type);
        }


        public void AddTypeMapRange(IEnumerable<KeyValuePair<string, Type>> pairs)
        {
            foreach (var pair in pairs)
                typesMap.Add(pair.Key, pair.Value);
        }


        public IASTExpression? Call(string name, string? genericName, params IASTExpression[] args)
        {
            Type? generic = null;

            if (genericName != null)
            {
                var result = typesMap.TryGetValue(genericName, out generic);

                if (result == false)
                    throw new InvalidOperationException($"type {genericName} doesnt exist in this context");
            }

            var call = calls.FirstOrDefault(x => FindPredicate(x, generic, name, args));

            if (call == null)
                return null;

            if (genericName == null)
                return call.Invoke(args);

            return call.Invoke(generic, args);
        }


        private static bool FindPredicate(CallExpression call, Type? generic, string name, IASTExpression[] args)
        {
            if (call.Name != name)
                return false;

            if (call.Args.Length != args.Length)
                return false;

            for (int i = 0; i < args.Length; i++)
            {
                var type = call.Args[i].IsGeneric == true ? generic! : call.Args[i].ArgumentType;

                if (astExprType.IsAssignableFrom(type) == false)
                {
                    if (args[i] is not IValueExpression vl)
                        return false;

                    if (type.IsAssignableFrom(vl.ValueType) == false)
                        return false;
                }
                else
                {
                    var arg = args[i].GetType();

                    if (type.IsGenericTypeDefinition == true)
                    {
                        if (arg.IsGenericType == false)
                            return false;

                        if (type.IsAssignableFrom(arg.GetGenericTypeDefinition()) == false)
                            return false;
                    }
                    else if (type.IsAssignableFrom(arg) == false)
                        return false;
                }
            }

            return true;
        }
    }
}
