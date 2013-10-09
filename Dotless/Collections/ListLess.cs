using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dotless
{
    public class ListLess<T>: IEnumerable<T>, IEnumerable
    {
        private IList<T> Adaptee;

        #region [ CONSTRUCTORS ]

        public ListLess(params T[] elems)
        {
            Adaptee = new List<T>(elems);
        }

        public ListLess(IEnumerable<T> elems)
        {
            Adaptee = new List<T>(elems);
        }

        #endregion

        #region [ IENUMERABLE IFACE ]

        public IEnumerator<T> GetEnumerator()
        {
            return Adaptee.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion

        protected IEnumerable<T> Slice(int s, int e) {
            int c = Adaptee.Count;
            if (s < 0) s = Math.Max(c + s + 1, 0);
            if (s > c) s = c;
            if (e < 0) e = Math.Max(c + e + 1, 0);
            if (e > c) e = c;

            if (s < e)
                for (int i = s; i < e; i++)
                    yield return Adaptee.ElementAt(i);
            else if (s > e)
                for (int i = s - 1; i >= e; i--)
                    yield return Adaptee.ElementAt(i);
            else
                yield break;        
        }

        public ListLess<T> Add(T e) {
            Adaptee.Add(e);
            return this;
        }

        public ListLess<T> Add(params T[] es)
        {
            es.Each(e => Adaptee.Add(e));
            return this;
        }

        public T this[int i] {
            get {
                var c = Adaptee.Count;
                return (i >= c || i < -c) ? default(T) :
                       (i < 0) ? Adaptee.ElementAt(c + i) :
                       Adaptee.ElementAt(i);
            }
        }

        public ListLess<T> this[int s, int e]
        {
            get { return new ListLess<T>(Slice(s, e)); }
        }

    }

    public class Listless<T>: ListLess<T> {}
}
