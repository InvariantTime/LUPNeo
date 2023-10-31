using LUP.Parsing.AST;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Parsing.Grammars.AST
{
    class RuleParamExpr : IParserExpression
    {
        public string Name { get; }

        public RuleParamBodyExpr Body { get; }

        public RuleParamExpr(string name, RuleParamBodyExpr body)
        {
            Name = name;
            Body = body;
        }


        public static IParserExpression BuildParam(TokenExpression token, RuleParamBodyExpr body)
        {
            if (token.Token.Value == null)
                throw new InvalidOperationException("Unable to get token id");

            return new RuleParamExpr(token.Token.Value, body);
        }
    }

    class RuleParamBodyExpr : IParserExpression
    {
        public static readonly RuleParamBodyExpr Empty = new();

        private readonly List<int> indices;

        public IReadOnlyCollection<int> Indices { get; }

        public RuleParamBodyExpr(int first)
        {
            if (first < 1)
                throw new IndexOutOfRangeException("index of token cannot be less than 1");

            indices = new()
            {
                first - 1
            };

            Indices = new ReadOnlyCollection<int>(indices);
        }

        
        public RuleParamBodyExpr()
        {
            indices = new();
            Indices = new ReadOnlyCollection<int>(indices);
        }


        public void Add(int index)
        {
            if (index < 1)
                throw new IndexOutOfRangeException("index of token cannot be less than 1");

            indices.Add(index - 1);
        }


        public static IParserExpression BuildBody(TokenExpression token)
        {
            if (token.Token.Value == null)
                throw new InvalidOperationException("Unable to get token number");

            bool result = int.TryParse(token.Token.Value, out int num);

            if (result == false)
                throw new InvalidCastException("Unable to cast token to integer");

            return new RuleParamBodyExpr(num);
        }


        public static IParserExpression BuildBody(RuleParamBodyExpr body, TokenExpression token)
        {
            if (token.Token.Value == null)
                throw new InvalidOperationException("Unable to get token number");

            bool result = int.TryParse(token.Token.Value, out int num);

            if (result == false)
                throw new InvalidCastException("Unable to cast token to integer");

            body.Add(num);
            return body;
        }
    }
}
