using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dotless
{
    public static class Unity
    {

        public static IEnumerable<T> Each<T>(this IEnumerable<T> e, Action<T> action) 
        {
            if (!Null.AnyOf(e, action))
                foreach (var i in e) action(i);

            return e; // Fluent
        }

        public static IEnumerable<T> Forge<T>(T start, Predicate<T> end, Func<T, T> next)
        {
            if (Null.AnyOf(start, end, next)) yield break;

            for (T t = start; end(t); t = next(t))
                yield return t;
        }

        #region [ Trasformations ]

        public static IEnumerable<R> Map<T, R>(this IEnumerable<T> c, Func<T, R> map)
        {
            if (Null.AnyOf(c, map)) yield break;

            foreach (var e in c) yield return map(e);
        }

        //public static IDictionary<K2, V2> Map<K1, V1, K2, V2, R>(this IDictionary<K1, V1> c,  Func<V1, V2> mapValue)

        public static R Reduce<T, R>(this IEnumerable<T> c, Func<T, R, R> op, R startValue = default(R))
        {
            if (Null.AnyOf(c, op)) return startValue;

            var accumulator = startValue;
            foreach (var e in c)
                accumulator = op(e, accumulator);
            return accumulator;
        }

        public static R MapReduce<T, M, R>(this IEnumerable<T> e, Func<T, M> fMap, Func<M, R, R> fReduce, R startValue = default(R))
        {
            return Reduce(Map(e, fMap), fReduce, startValue);
        }

        public static IDictionary<K, V> Indicize<K, V>(this IEnumerable<V> e, Func<V, K> fKey)
        {
            return (new Dictless<K, V>(e, fKey)).More;
        } 

        #endregion
        
    }
}
