using LUP.Rendering.Language.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.Language.Generation
{
    public interface IShaderGenerationProvider
    {
        IShaderVisitor<StringBuilder> ExpressionGenerator { get; }

        IShaderMemberGenerator MemberGenerator { get; }

        IShaderGenerationHandler Handler { get; }

        string ShaderTemplate { get; }
    }
}
