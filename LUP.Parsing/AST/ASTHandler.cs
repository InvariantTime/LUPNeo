using LUP.Parsing.AST.Expressions;
using LUP.Parsing.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Parsing.AST
{
    public abstract class ASTHandler<T> where T : class, IASTExpression
    {
        private readonly ReduceRegister register;
        private readonly ReducePool pool;

        public ReducePool Pool => pool;

        public ASTHandler()
        {
            register = new();
            pool = new();

            RegistHandlers(register);
        }


        public virtual void OnSucess()
        {
        }


        public virtual void OnError(string message)
        {
        }


        public void HandleReduce(IReduceExpression expression, KeyToken result, KeyToken[] tokens)
        {
            if (expression is EmptyReduceExpression)
                return;

            var context = new ReduceContext
            {
                Pool = pool,
                Register = register,
                Tokens = tokens,
                ResultToken = result
            };

            try
            {
                expression.Handle(context);
            }
            catch(Exception ex)
            {
                OnError(ex.Message);
            }
        }


        public void Clear()
        {
            pool.Clear();
        }


        protected abstract void RegistHandlers(ReduceRegister register);
    }
}
