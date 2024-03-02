using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.Language.Expressions
{
    public interface IShaderVisitor<T>
    {
        void Visit(IShaderStatement statement, T context);

        void Visit(IShaderExpression expression, T context);

        void Visit(ShaderStatementBlock statement, T context);

        void Visit(ShaderExpressionStatement statement, T context);

      //  void Visit(ShaderParamExpression expression, T context);

      //  void Visit(ShaderEqualExpression expression, T context);

       // void Visit(ShaderVariableExpression expression, T context);

        void Visit(ShaderMethodCall expression, T context);

        void Visit(ShaderForStatement statement, T context);

        void Visit(ShaderIfStatement statement, T context);

        void Visit(ShaderReturnStatement statement, T context);

        void Visit(ShaderBinaryOperation expression, T context);

        void Visit(ShaderUnaryOperation expression, T context);
    }
}
