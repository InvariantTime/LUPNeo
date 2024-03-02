using LUP.Logging;
using LUP.Parsing;
using LUP.Parsing.AST;
using LUP.Parsing.AST.Expressions;
using LUP.Parsing.Grammars;
using LUP.Parsing.Parsers;
using LUP.Rendering.ShaderLanguage.AST;
using LUP.Rendering.ShaderLanguage.Parsing;

namespace LUP.Rendering.ShaderLanguage
{
    public sealed class ShaderCompiler
    {
        private readonly ILogger<ShaderCompiler> logger;
        private readonly ShaderParser parser;
        private readonly Lexer lexer;

        public ShaderCompiler(ILogger<ShaderCompiler> logger)
        {
            this.logger = logger;
            lexer = new(ShaderLexerTokens.Tokens);

            Grammar? grammar = default;// GrammarCompiler.Compile(ShaderResources.ShaderGrammar);

            if (grammar == null)
                throw new Exception("Unable to compile grammar");

            StackMachineTableGenerator generator = new(grammar);
            var table = generator.Generate();
            parser = new(logger, table);// new ASTParser<ShaderAST>(new ShaderParseHandler(logger), table);
        }


        public void Compile(string source)
        {
            var lexerResult = lexer.Tokenize(source);

            if (lexerResult.Success == false)
            {
                logger.Error(lexerResult.Error);
                return;
            }

            parser.Parse(lexerResult.Tokens);
        }
    }


    class ShaderParser : LanguageParser
    {
        private readonly ILogger<ShaderCompiler> logger;

        public ShaderParser(ILogger<ShaderCompiler> logger, StackMachineTable table) : base(table)
        {
            this.logger = logger;
        }


        protected override void OnReduce(KeyToken result, IReduceExpression expression, KeyToken[] reduced)
        {
            logger.Debug($"REDUCE: {result.Token.Type}");
        }


        protected override void OnErrorThrow(string message)
        {
            logger.Error(message);
        }


        protected override void OnSuccess()
        {
            logger.Info("Success!");
        }
    }
}
