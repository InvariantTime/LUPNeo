using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Parsing.AST.Standard
{
    class ListHandler
    {
        private static readonly Type listType = typeof(ListExpression<>);
        private static readonly ConcurrentDictionary<Type, Func<object>> factories = new();

        [GrammarCall("createList")]
        public ListExpression<T> CreateList<T>(T value)
        {
            var list = CreateList<T>();
            list.Add(value);
            return list;
        }


        [GrammarCall("createList")]
        public ListExpression<T> CreateList<T>()
        {
            var factory = factories.GetOrAdd(typeof(T), BuildFactory);

            if (factory is null)
                throw new InvalidCastException($"unable to make factory");

            var list = (ListExpression<T>)factory.Invoke();

            return list;
        }


        [GrammarCall("addToList")]
        public ListExpression<T> AddToList<T>(ListExpression<T> list, T value)
        {
            list.Add(value);
            return list;
        }


        private static Func<object> BuildFactory(Type genericType)
        {
            var ctor = listType.MakeGenericType(genericType).GetConstructors().First();
            var @new = Expression.Convert(Expression.New(ctor), typeof(object));

            var lambda = Expression.Lambda<Func<object>>(@new);
            return lambda.Compile();
        }
    }
}
