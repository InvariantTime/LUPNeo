using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.Language.Expressions
{
    public class ShaderUnaryOperation : IShaderExpression
    {
        public IShaderExpression Param { get; }

        public Types Operator { get; }

        public ShaderUnaryOperation(IShaderExpression param, Types op)
        {
            Param = param;
            Operator = op;
        }

        public enum Types
        {
            PreIncr,
            PreDicr,
            PostIncr,
            PostDicr,
            Not
        }


        public void Interpret<T>(IShaderVisitor<T> visitor, T context)
        {
            visitor.Visit(this, context);
        }
    }

    public class ShaderBinaryOperation : IShaderExpression
    {
        public IShaderExpression Left { get; }

        public IShaderExpression Right { get; }

        public Types Operator { get; }

        public ShaderBinaryOperation(IShaderExpression left, IShaderExpression right, Types op)
        {
            Left = left;
            Right = right;
            Operator = op;
        }


        public void Interpret<T>(IShaderVisitor<T> visitor, T context)
        {
            visitor.Visit(this, context);
        }


        public enum Types
        {
            Plus,
            Minus,
            Divide,
            Multiply,
            Equal,
            NotEqual,
            Less,
            Greater,
            LEqual,
            GEqual,

            And,
            Or,
        }
    }
}
