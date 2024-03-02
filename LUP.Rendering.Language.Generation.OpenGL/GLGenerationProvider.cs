using LUP.Rendering.Language.Expressions;
using LUP.Rendering.Language.Generation.OpenGL.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.Language.Generation.OpenGL
{
    public class GLGenerationProvider : IShaderGenerationProvider
    {
        public IShaderVisitor<StringBuilder> ExpressionGenerator { get; }

        public IShaderMemberGenerator MemberGenerator { get; }

        public IShaderGenerationHandler Handler { get; }

        public string ShaderTemplate { get; } = ShaderTemplates.ShaderTemplate;

        public GLGenerationProvider()
        {
            ExpressionGenerator = new ShaderExpressionGenerator();
            Handler = new ShaderGenerationHandler();
            MemberGenerator = new ShaderMemberGenerator(ExpressionGenerator);
        }
    }
}
