
namespace LUP.Rendering.Language.Expressions
{
    public class ShaderIfStatement : IShaderStatement
    {
        public IShaderExpression Condition { get; }
        
        public IShaderStatement Clause { get; }

        public IShaderStatement? ElseClause { get; }

        public ShaderIfStatement(IShaderExpression condition, IShaderStatement clause, IShaderStatement? elseClause)
        {
            Condition = condition;
            Clause = clause;
            ElseClause = elseClause;
        }


        public void Interpret<T>(IShaderVisitor<T> visitor, T context)
        {
            visitor.Visit(this, context);
        }
    }
}
