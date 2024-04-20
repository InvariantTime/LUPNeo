using LUP.Parsing.AST.Expressions;
using LUP.Parsing.Parsers;

namespace LUP.Parsing.AST
{
    public sealed class ASTParser<T> where T : class, IASTExpression
    {
        private readonly ASTHandler<T> handler;
        private readonly StackMachineTable table;

        public ASTParser(ASTHandler<T> handler, StackMachineTable table)
        {
            this.handler = handler;
            this.table = table;
        }


        public T? Parse(IEnumerable<Token> tokens)
        {
            StackMachine machine = new(table);
            handler.Clear();

            bool success = false;
            int index = 0;

            while (success == false)
            {
                var token = tokens.ElementAt(index);
                var result = machine.Handle(token);

                switch (result.Code)
                {
                    case HandleCodes.Success:
                        handler.OnSucess();
                        success = true;
                        break;

                    case HandleCodes.Error:
                        handler.OnError(result.Error);
                        return null;

                    case HandleCodes.Shift:
                        index++;
                        break;

                    case HandleCodes.Reduce:
                        if (result.Reduced == null)
                        {
                            handler.OnError("reduced tokens is null");
                            return null;
                        }

                        if (result.Param == null)
                        {
                            handler.OnError("unable to get reduce expression");
                            return null;
                        }

                        OnReduce(result.Result, result.Param, result.Reduced);
                        break;
                }
            }

            var ast = handler.Pool.FirstOrDefault(x => x.Value is T);

            if (ast.Value == null)
            {
                handler.OnError("Grammar must return AST");
                return null;
            }

            return ast.Value as T;
        }


        private void OnReduce(KeyToken result, IReduceExpression expr, KeyToken[] reduced)
        {
            handler.HandleReduce(expr, result, reduced);
        }
    }
}
