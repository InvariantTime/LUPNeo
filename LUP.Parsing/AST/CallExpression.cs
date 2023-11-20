using System.Collections.Immutable;

namespace LUP.Parsing.AST
{
    public delegate IASTExpression Call(object instance, Type? generic, params IASTExpression[] args);

    class CallExpression
    {
        private static readonly Type astExprType = typeof(IASTExpression);

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
           // Validate(args, generic);
            return call.Invoke(instance, generic, args);
        }


        private void Validate(IASTExpression[] args, Type? generic)
        {
            if (Args.Length != args.Length)
                throw new IndexOutOfRangeException("Array of arguments hasn't valid length");

            for (int i = 0; i < Args.Length; i++)
            {
                var type = Args[i].ArgumentType;

                if (astExprType.IsAssignableFrom(type) == false)
                {
                    if (args[i] is not IValueExpression val)
                        throw new InvalidOperationException($"Argument with index {i} must be IValueExpression");

                    if (type.IsAssignableFrom(val.ValueType) == false)
                        throw new InvalidCastException($"Unable to cast {val.ValueType.FullName} to {type.FullName}");
                }
                else
                {
                    if (type.IsAssignableFrom(args[i].GetType()) == false)
                        throw new InvalidCastException($"Unable to cast {args[i].GetType()} to {Args[i]}");
                }
            }
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
