using LUP.Parsing.AST.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Parsing.AST
{
    public static class ReduceExpression
    {
        public static IReduceExpression Call(string name, params IReduceExpression[] args)
        {
            return new CallReduceExpression(name, args);
        }


        public static IReduceExpression Equal(IReduceExpression right)
        {
            return new EqualReduceExpression(right);
        }


        public static IReduceExpression Call(string name, string generic, params IReduceExpression[] args)
        {
            return new CallReduceExpression(name, generic, args);
        }


        public static IReduceValue String(string value)
        {
            if (value == string.Empty)
                return StringReduceValue.Empty;

            return new StringReduceValue(value);
        }

        
        public static IReduceValue String()
        {
            return StringReduceValue.Empty;
        }

        
        public static IReduceValue Int(int value)
        {
            return new IntReduceValue(value, IntReduceValue.ValueTypes.Int);
        }

        
        public static IReduceValue Index(int index)
        {
            return new IntReduceValue(index - 1, IntReduceValue.ValueTypes.Index);
        }


        public static IReduceValue AST(IASTExpression ast)
        {
            return new ASTReduceValue(ast);
        }
    }
}
