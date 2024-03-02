using LUP.Rendering.Language.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Rendering.Language.Generation.OpenGL
{
    class ShaderExpressionGenerator : IShaderVisitor<StringBuilder>
    {
        public void Visit(IShaderStatement statement, StringBuilder context)
        {
        }


        public void Visit(IShaderExpression expression, StringBuilder context)
        {
        }


        public void Visit(ShaderStatementBlock statement, StringBuilder context)
        {
            foreach (var st in statement.Statements)
                st.Interpret(this, context);
        }


        public void Visit(ShaderExpressionStatement statement, StringBuilder context)
        {
            statement.Expression.Interpret(this, context);
            context.Append(';');
            context.AppendLine();
        }


        public void Visit(ShaderParamExpression expression, StringBuilder context)
        {
            context.Append(ExpressionConverter.GetTypeString(expression.Type));
            context.Append($" {expression.Alias}");
            
            if (expression.EqualExpression != null)
            {
                context.Append('=');
                expression.EqualExpression.Interpret(this, context);
            }
        }


        public void Visit(ShaderEqualExpression expression, StringBuilder context)
        {
            context.Append(expression.Alias);
            context.Append('=');
            expression.Expression.Interpret(this, context);
        }


        public void Visit(ShaderVariableExpression expression, StringBuilder context)
        {
            context.Append(expression.Value);
        }


        public void Visit(ShaderCallExpression expression, StringBuilder context)
        {
            context.Append(expression.Alias);
            context.Append('(');

            for (int i = 0; i < expression.Arguments.Length; i++)
            {
                expression.Arguments[i].Interpret(this, context);

                if (i < expression.Arguments.Length - 1)
                    context.Append(',');
            }

            context.Append(')');
        }


        public void Visit(ShaderForStatement statement, StringBuilder context)
        {
            context.Append("for(");
            statement.Param?.Interpret(this, context);
            context.Append(';');
            statement.Condition?.Interpret(this, context);
            context.Append(';');
            statement.Step?.Interpret(this, context);
            context.AppendLine("){");
            statement.Body.Interpret(this, context);
            context.Append('}');
            context.AppendLine();
        }


        public void Visit(ShaderIfStatement statement, StringBuilder context)
        {
            context.Append("if(");
            statement.Condition.Interpret(this, context);
            context.Append(") {");
            statement.Clause.Interpret(this, context);
            context.Append('}');
            context.AppendLine();

            if (statement.ElseClause != null)
            {
                context.Append("else ");

                if (statement.ElseClause is ShaderIfStatement @if)
                {
                    Visit(@if, context);
                }
                else
                {
                    context.Append('{');
                    context.AppendLine();
                    statement.ElseClause.Interpret(this, context);
                    context.Append('}');
                    context.AppendLine();
                }
            }
        }


        public void Visit(ShaderReturnStatement statement, StringBuilder context)
        {
            context.Append("return ");
            statement.Expression?.Interpret(this, context);
            context.Append(';');
            context.AppendLine();
        }


        public void Visit(ShaderBinaryOperation expression, StringBuilder context)
        {
            context.Append('(');

            var op = expression.Operator switch
            {
                ShaderBinaryOperation.Types.Plus => "+",
                ShaderBinaryOperation.Types.Minus => "-",
                ShaderBinaryOperation.Types.Multiply => "*",
                ShaderBinaryOperation.Types.Divide => "/",
                ShaderBinaryOperation.Types.Equal => "==",
                ShaderBinaryOperation.Types.NotEqual => "!=",
                ShaderBinaryOperation.Types.Greater => ">",
                ShaderBinaryOperation.Types.Less => "<",
                ShaderBinaryOperation.Types.GEqual => ">=",
                ShaderBinaryOperation.Types.LEqual => "<=",

                ShaderBinaryOperation.Types.And => "&&",
                ShaderBinaryOperation.Types.Or => "||",

                _ => throw new NotSupportedException()
            };

            expression.Left.Interpret(this, context);
            context.Append(op);
            expression.Right.Interpret(this, context);
            context.Append(')');
        }


        public void Visit(ShaderUnaryOperation expression, StringBuilder context)
        {
            string op = expression.Operator switch
            {
                ShaderUnaryOperation.Types.PostIncr or ShaderUnaryOperation.Types.PreIncr => "++",
                ShaderUnaryOperation.Types.PostDicr or ShaderUnaryOperation.Types.PreDicr => "--",
                ShaderUnaryOperation.Types.Not => "!",

                _ => throw new NotSupportedException()
            };

            bool isPrefix = expression.Operator == ShaderUnaryOperation.Types.Not ||
                expression.Operator == ShaderUnaryOperation.Types.PreIncr ||
                expression.Operator == ShaderUnaryOperation.Types.PreDicr;

            if (isPrefix == true)
                context.Append(op);

            expression.Param.Interpret(this, context);

            if (isPrefix == false)
                context.Append(op);
        }
    }
}
