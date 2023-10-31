using LUP.Parsing;
using LUP.Parsing.Grammars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Parsing.Parsers
{
    public abstract class LanguageParser
    {
        private readonly StackMachineTable table;

        public LanguageParser(StackMachineTable table)
        {
            this.table = table;
        }


        public bool Parse(IEnumerable<Token> tokens)
        {
            StackMachine machine = new(table);

            bool success = false;
            int index = 0;

            while (success == false)
            {
                var token = tokens.ElementAt(index);
                var result = machine.Handle(token);

                switch (result.Code)
                {
                    case HandleCodes.Success:
                        OnSuccess();
                        success = true;
                        break;

                    case HandleCodes.Error:
                        OnErrorThrow(result.Error);
                        return false;

                    case HandleCodes.Shift:
                        index++;
                        break;

                    case HandleCodes.Reduce:
                        if (result.Reduced == null)
                            throw new InvalidOperationException("reduced cannot be empty");

                        OnReduce(result.Result, result.Param, result.Reduced);
                        break;
                }
            }

            return true;
        }


        protected virtual void OnReduce(KeyToken result, ReduceParam? param, KeyToken[] reduced)
        {
        }


        protected virtual void OnSuccess()
        {
        }


        protected virtual void OnErrorThrow(string message)
        {
        }
    }
}