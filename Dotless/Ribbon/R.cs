using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dotless
{
    public static class R
    {
       
        public static Ribbon<T> Empty<T>() { return new Ribbon<T>(); }

        public static HRibbon<K,V> Empty<K,V>() { return new HRibbon<K,V>(); }

        #region [ RIBBON ]

        public static Ribbon<T> List<T>(params T[] ts)
        {
            if (Null.Is(ts)) return Empty<T>();

            return new Ribbon<T>(ts);
        }

        public static Ribbon<T> List<T>(IEnumerable<T> ts)
        {
            if (Null.Is(ts)) return Empty<T>();

            return new Ribbon<T>(ts);
        }

        public static Ribbon<T> List<T>(T start, Predicate<T> end, Func<T, T> next)
        {
            return new Ribbon<T>(Unity.Forge<T>(start, end, next));
        }

        public static Ribbon<R> List<T, R>(IEnumerable<T> ts, Func<T, R> fetchValue)
        {
            if (Null.AnyOf(ts, fetchValue)) return Empty<R>();

            return new Ribbon<R>(Unity.Map(ts, fetchValue));
        }

        public static Ribbon<int> Range(int endPoint)
        {
            return List<int>(0, i => i < endPoint, i => i + 1);
        }

        public static Ribbon<int> Range(int start, int end)
        {
            return (start < end)
                ? List<int>(start, i => i < end, i => i + 1)
                : List<int>(start - 1, i => i >= end, i => i - 1);
        }

        public static Ribbon<int> Range(int start, int end, int step)
        {
            return (start < end && step > 0) ? List<int>(start, i => i < end, i => i + step) :
                   (start > end && step < 0) ? List<int>(start + step, i => i >= end, i => i + step) :
                   Empty<int>();
        }

        #endregion

        #region [ HASH RIBBON ]

        public static HRibbon<K, V> Dict<K, V>(IEnumerable<V> ts, Func<V, K> fetchKey)
        {
            return new HRibbon<K, V>(ts, fetchKey);
        }

        public static HRibbon<K, V> Dict<E, K, V>(IEnumerable<E> ts, Func<E, K> fetchKey, Func<E, V> fetchValue)
        {
            var hr = R.Empty<K, V>();

            if (Null.AllOf(ts, fetchKey, fetchValue))
                ts.Each(e => hr.Add(fetchKey(e), fetchValue(e)));

            return hr;
        }

        public static HRibbon<K, V> Dict<K, V>(IDictionary<K, V> d)
        {
            return R.Dict(d, e => e.Key, e => e.Value);
        }
        
        #endregion
    }
}
