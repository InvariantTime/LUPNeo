using LUP.Logging;

namespace LUP.Rendering.ShaderLanguage
{
    public class ShaderCompiler
    {
        private readonly ILogger<ShaderCompiler> logger;
        private readonly ShaderLexer lexer;
        private readonly ShaderParser parser;

        public ShaderCompiler(ILogger<ShaderCompiler> logger)
        {
            this.logger = logger;
            lexer = new(logger);
            parser = new();
        }


        public void Test()
        {
            var tokens = lexer.Tokenize(ShaderResouces.TestShader);
            
            foreach (var token in tokens)
                Console.WriteLine($"{token.Type}: {token.Value}");

            parser.Parse(tokens);
        }
    }
}
