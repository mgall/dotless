using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dotless
{
    public static class R
    {
       
        public static ListLess<T> Empty<T>() { return new ListLess<T>(); }

        public static DictionaryLess<K, V> Empty<K, V>() { return new DictionaryLess<K, V>(); }

        #region [ ListLess ]

        public static ListLess<T> List<T>(params T[] ts)
        {
            if (Null.Is(ts)) return Empty<T>();

            return new ListLess<T>(ts);
        }

        public static ListLess<T> List<T>(IEnumerable<T> ts)
        {
            if (Null.Is(ts)) return Empty<T>();

            return new ListLess<T>(ts);
        }

        public static ListLess<T> List<T>(T start, Predicate<T> end, Func<T, T> next)
        {
            return new ListLess<T>(Unity.Forge<T>(start, end, next));
        }

        public static ListLess<R> List<T, R>(IEnumerable<T> ts, Func<T, R> fetchValue)
        {
            if (Null.AnyOf(ts, fetchValue)) return Empty<R>();

            return new ListLess<R>(Unity.Map(ts, fetchValue));
        }

        public static ListLess<int> Range(int endPoint)
        {
            return List<int>(0, i => i < endPoint, i => i + 1);
        }

        public static ListLess<int> Range(int start, int end)
        {
            return (start < end)
                ? List<int>(start, i => i < end, i => i + 1)
                : List<int>(start - 1, i => i >= end, i => i - 1);
        }

        public static ListLess<int> Range(int start, int end, int step)
        {
            return (start < end && step > 0) ? List<int>(start, i => i < end, i => i + step) :
                   (start > end && step < 0) ? List<int>(start + step, i => i >= end, i => i + step) :
                   Empty<int>();
        }

        #endregion

        #region [ HASH ListLess ]

        public static DictionaryLess<K, V> Dict<K, V>(IEnumerable<V> ts, Func<V, K> fetchKey)
        {
            return new DictionaryLess<K, V>(ts, fetchKey);
        }

        public static DictionaryLess<K, V> Dict<E, K, V>(IEnumerable<E> ts, Func<E, K> fetchKey, Func<E, V> fetchValue)
        {
            var hr = R.Empty<K, V>();

            if (Null.AllOf(ts, fetchKey, fetchValue))
                ts.Each(e => hr.Add(fetchKey(e), fetchValue(e)));

            return hr;
        }

        public static DictionaryLess<K, V> Dict<K, V>(IDictionary<K, V> d)
        {
            return R.Dict(d, e => e.Key, e => e.Value);
        }
        
        #endregion
    }
}
