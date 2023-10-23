using LUP.Rendering.ShaderLanguage.Lexers;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.ShaderLanguage.Parsers
{
    class StackMachine
    {
        private readonly Stack<int> stack;

        private readonly StackMachineTable table;

        public StackMachine(StackMachineTable table)
        {
            this.table = table;

            stack = new();
        }


        public StackMachineResult Handle(IEnumerable<Token> source)
        {
            Clear();

            bool success = false;
            int index = 0;

            var token = source.ElementAt(index);
            index++;

            stack.Push(table.Start);
            while (success == false)
            {
                int state = stack.Peek();

                if (state == -1)
                    throw new InvalidOperationException("Unable to pop state"); 

                bool result = table.TryGetState(state, token.Type, out var jmp);

                if (result == true)
                {
                    switch (jmp.Type)
                    {
                        case StateTypes.Success:
                            success = true;
                            break;

                        case StateTypes.Reduce:

                            if (jmp.Rule == null)
                                throw new Exception();

                            for (int i = 0; i < jmp.Rule.Value.Tokens.Length; i++)
                                stack.Pop();

                            result = table.TryGetState(stack.Pop(), jmp.Rule.Value.Result, out jmp);

                            if (result == true)
                            {
                                stack.Push(jmp.NewState);
                            }
                            else
                            {
                                throw new Exception();
                            }

                            break;

                        case StateTypes.Shift:

                            stack.Push(jmp.NewState);
                            token = source.ElementAt(index);
                            index++;
                            break;
                    }
                    
                }
                else
                {
                    throw new Exception();
                }
            }

            return StackMachineResult.Empty;
        }

        
        private void Clear()
        {
            stack.Clear();
        }
    }

    readonly struct StackMachineResult
    {
        public static readonly StackMachineResult Empty = new();

        public bool Success { get; init; }

        public string[]? Errors { get; init; }
    }
}
