using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Parsing.AST.Expressions
{
    public interface IReduceExpression
    {
        IReduceExpression? Handle(ReduceContext context);
    }

    public interface IReduceValue : IReduceExpression
    {
        IASTExpression ToAST(ReduceContext context);
    }

    class EmptyReduceExpression : IReduceValue
    {
        public static readonly EmptyReduceExpression Instance = new();

        private EmptyReduceExpression() { }


        public IReduceExpression? Handle(ReduceContext context)
        {
            return null;
        }


        public IASTExpression ToAST(ReduceContext context)
        {
            return EmptyASTExpression.Instance;
        }
    }
}
