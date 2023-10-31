using LUP.Parsing.Grammars;
using LUP.Parsing.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Parsing.AST
{
    public sealed class ASTParser<T> where T : class
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
            handler.Start();

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

                        OnReduce(result.Result, result.Param, result.Reduced);
                        break;
                }
            }

            return handler.AST;
        }


        private void OnReduce(KeyToken result, ReduceParam? param, KeyToken[] reduced)
        {
            if (param == null)
                return;

            KeyToken[] tokens = new KeyToken[param.TokenIndices.Length];

            for(int i = 0; i < tokens.Length; i++)
            {
                tokens[i] = reduced[param.TokenIndices[i]];
            }

            handler.HandleReduce(param.Name, result, tokens);
        }
    }
}
