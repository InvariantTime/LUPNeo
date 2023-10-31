using LUP.Parsing.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Parsing.AST
{
    public abstract class ASTHandler<T> where T : class
    {
        private T? ast;

        private readonly ReduceRegister register;
        private readonly Dictionary<KeyToken, IParserExpression> expressions;

        public T AST => ast ?? throw new Exception("AST is not initialized");

        public ASTHandler()
        {
            register = new();
            expressions = new();

            RegistReduces(register);
        }


        public virtual void OnSucess()
        {
        }


        public virtual void OnError(string message)
        {
        }


        public void HandleReduce(string name, KeyToken result, KeyToken[] tokens)
        {
            var reduce = register.GetReduce(name);

            if (reduce == null)
                return;

            IParserExpression[] exprs = new IParserExpression[tokens.Length];

            for (int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i].IsTerminal == true)
                {
                    exprs[i] = new TokenExpression(tokens[i]);
                    continue;
                }

                bool hasExpr = expressions.TryGetValue(tokens[i], out var e);

                if (hasExpr == false)
                    throw new InvalidOperationException("Unable to get expression");

                exprs[i] = e!;
            }

            var expr = reduce.Invoke(exprs);

            if (expr != null)
                expressions.Add(result, expr);
        }


        public void Start()
        {
            expressions.Clear();
            ast = CreateAST();
        }


        protected abstract void RegistReduces(ReduceRegister register);


        public abstract T? CreateAST();
    }
}
