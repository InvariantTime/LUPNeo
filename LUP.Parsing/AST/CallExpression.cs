using System.Collections.Immutable;

namespace LUP.Parsing.AST
{
    public delegate IASTExpression Call(object instance, Type? generic, params IASTExpression[] args);

    class CallExpression
    {
        private readonly object instance;
        private readonly Call call;

        public string Name { get; }

        public ImmutableArray<CallArgument> Args { get; }

        public CallExpression(object instance, CallInfo info)
        {
            this.instance = instance;
            call = info.Call;
            Name = info.Name;
            Args = info.Args.ToImmutableArray();
        }


        public IASTExpression Invoke(params IASTExpression[] args)
        {
            return Invoke(null, args);
        }


        public IASTExpression Invoke(Type? generic, params IASTExpression[] args)
        {
            return call.Invoke(instance, generic, args);
        }
    }

    readonly struct CallInfo
    {
        public Call Call { get; init; }

        public string Name { get; init; }

        public IEnumerable<CallArgument> Args { get; init; }

        public bool IsGeneric { get; init; }
    }


    readonly struct CallArgument
    {
        public Type ArgumentType { get; init; }

        public bool IsGeneric { get; init; }
    }
}
