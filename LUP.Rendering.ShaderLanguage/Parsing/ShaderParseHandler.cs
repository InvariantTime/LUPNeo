using LUP.Logging;
using LUP.Parsing.AST;
using LUP.Rendering.ShaderLanguage.AST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.ShaderLanguage.Parsing
{
    class ShaderParseHandler : ASTHandler<ShaderAST>
    {
        private readonly ILogger<ShaderCompiler> logger;

        public ShaderParseHandler(ILogger<ShaderCompiler> logger)
        {
            this.logger = logger;
        }


        public override void OnSucess()
        {
            logger.Info("shader compiled");   
        }


        public override void OnError(string message)
        {
            logger.Error("unable to compile shader: " + message);
        }


        protected override void RegistHandlers(ReduceRegister register)
        {
        }
    }
}
