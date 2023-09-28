using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Client.Input
{
    class InputProcessor : IInputProcessor
    {
        public IInputHandler Input { get; }

        public InputProcessor(IInputHandler input)
        {
            Input = input;
        }


        public void Handle(LoopContext context)
        {
        }
    }
}
