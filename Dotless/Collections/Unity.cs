using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dotless
{
    public static class Unity
    {
        public static IEnumerable<T> Forge<T>(T start, Predicate<T> end, Func<T, T> next)
        {
            if (Null.AnyOf(start, end, next)) yield break;

            for (T t = start; end(t); t = next(t))
                yield return t;
        }

        public static void Each<T>(this IEnumerable<T> c, Action<T> action)
        {
            if (Null.AnyOf(c, action)) return;

            foreach (var e in c) action(e);
        }

        public static IEnumerable<R> Map<T, R>(this IEnumerable<T> c, Func<T, R> map)
        {
            if (Null.AnyOf(c, map)) yield break;

            foreach (var e in c) yield return map(e);
        }

        public static R Reduce<T, R>(this IEnumerable<T> c, Func<T, R, R> op, R startValue = default(R))
        {
            if (Null.AnyOf(c, op)) return startValue;

            var accumulator = startValue;
            foreach (var e in c) 
                accumulator = op(e, accumulator);
            return accumulator;
        }

        public static R MapReduce<T, M, R>(this IEnumerable<T> c, Func<T, M> fMap, Func<M, R, R> fReduce, R startValue = default(R))
        {
            return Unity.Reduce(Unity.Map(c, fMap), fReduce, startValue);
        }

    }
}
