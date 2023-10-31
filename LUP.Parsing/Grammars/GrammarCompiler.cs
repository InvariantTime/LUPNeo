using LUP.Parsing.AST;
using LUP.Parsing.Grammars.AST;
using LUP.Parsing.Grammars.Compiler;
using LUP.Parsing.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Parsing.Grammars
{
    public static class GrammarCompiler
    {
        private static readonly Lexer lexer = new(GrammarTokenDefinitions.Definitions);
        private static readonly StackMachineTable table = StackTableReader.Read(GrammarResource.grammar);
        private static readonly ASTParser<AST.GrammarAST> parser = new(new GrammarParseHandler(), table);

        public static Grammar? Compile(string source)
        {
            var lexerResult = lexer.Tokenize(source);

            if (lexerResult.Success == false)
                throw new InvalidOperationException(lexerResult.Error);

            var ast = parser.Parse(lexerResult.Tokens);

            if (ast == null)
                return null;

            return ast.CreateGrammar();
        }
    }
}
