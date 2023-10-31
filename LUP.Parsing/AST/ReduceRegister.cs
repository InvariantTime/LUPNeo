using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LUP.Parsing.AST
{
    public class ReduceRegister
    {
        private readonly Dictionary<string, Func<IParserExpression[], IParserExpression?>> reduces;

        public ReduceRegister()
        {
            reduces = new();
        }


        public void Register(string name, Func<IParserExpression[], IParserExpression?> reduce)
        {
            if (reduce == null)
                throw new ArgumentNullException(nameof(reduce));

            reduces.Add(name, reduce);
        }


        public void Register<T1, T2>(string name, Func<T1, T2, IParserExpression?> reduce)
            where T1 : IParserExpression where T2 : IParserExpression
        {
            Register(name, (exprs) =>
            {
                if (exprs.Length != 2)
                    throw new IndexOutOfRangeException();

                if (exprs[0] is not T1 t1)
                    throw new InvalidOperationException("Unable to convert");

                if (exprs[1] is not T2 t2)
                    throw new InvalidOperationException("Unable to convert");

                return reduce(t1, t2);
            });
        }


        public void Register<T>(string name, Func<T, IParserExpression?> reduce)
            where T : IParserExpression
        {
            Register(name, (exprs) =>
            {
                if (exprs.Length != 1)
                    throw new IndexOutOfRangeException();

                if (exprs[0] is not T t)
                    throw new InvalidOperationException("Unable to convert");

                return reduce(t);
            });
        }
        

        public void Register(string name, Func<IParserExpression?> reduce)
        {
            Register(name, (exprs) =>
            {
                if (exprs.Length != 0)
                    throw new IndexOutOfRangeException();

                return reduce();
            });
        }


        public Func<IParserExpression[], IParserExpression?>? GetReduce(string name)
        {
            reduces.TryGetValue(name, out var result);
            return result;
        }
    }
}
