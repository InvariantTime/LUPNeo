using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LUP.Parsing.AST
{
    class GenericCallProvider
    {
        public static readonly MethodInfo InvokeMethod = typeof(GenericCallProvider).GetMethod(nameof(Invoke))!;

        private readonly Dictionary<Type, Call> generics;
        private readonly MethodInfo method;
        private readonly Type handler;

        public GenericCallProvider(MethodInfo method, Type handler)
        {
            generics = new();
            this.method = method;
            this.handler = handler;
        }


        public IASTExpression Invoke(object instance, Type generic, IASTExpression[] args)
        {
            if (generics.ContainsKey(generic) == false)
            {
                var call = CallBuilder.Build(handler, method.MakeGenericMethod(generic));
                generics.Add(generic, call);
                return call.Invoke(instance, null, args);
            }

            return generics[generic].Invoke(instance, null, args);
        }
    }
}
