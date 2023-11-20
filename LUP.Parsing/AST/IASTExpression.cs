using LUP.Parsing.AST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Parsing
{
    public interface IASTExpression
    {
    }

    public class EmptyASTExpression : IASTExpression
    {
        public static readonly EmptyASTExpression Instance = new();

        private EmptyASTExpression() { }
    }
}
