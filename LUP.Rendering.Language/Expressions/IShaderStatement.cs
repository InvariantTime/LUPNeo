using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.Language.Expressions
{
    public interface IShaderStatement
    {
        void Interpret<T>(IShaderVisitor<T> visitor, T info);
    }

    public interface IShaderExpression
    {
        void Interpret<T>(IShaderVisitor<T> visitor, T info);
    }

    public interface IShaderMemberCall : IShaderExpression
    {
        string? ParentParameter { get; }
    }
}
