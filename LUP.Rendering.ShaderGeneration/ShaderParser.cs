using LUP.Rendering.ShaderLanguage.Lexers;
using LUP.Rendering.ShaderLanguage.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.ShaderLanguage
{
    class ShaderParser
    {
        private readonly Grammar grammar;

        public ShaderParser()
        {
            grammar = GrammarReader.Read(ShaderResouces.ShaderGrammar);
        }


        public void Parse(IEnumerable<Token> source)
        {

            var generator = new StackMachineTableGenerator(grammar);

            var table = generator.Generate();
            StackMachine machine = new(table);
            machine.Handle(source);
        }
    }
}
