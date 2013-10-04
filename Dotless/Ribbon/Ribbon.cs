using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dotless
{
    public class Ribbon<T> : IEnumerable<T>, IEnumerable
    {
        private IList<T> body;

        #region [ CONSTRUCTORS ]

        public Ribbon(params T[] elems)
        {
            body = new List<T>(elems);
        }

        public Ribbon(IEnumerable<T> elems)
        {
            body = new List<T>(elems);
        }

        #endregion

        #region [ IENUMERABLE IFACE ]

        public IEnumerator<T> GetEnumerator()
        {
            return body.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion

        protected IEnumerable<T> Slice(int s, int e) {
            int c = body.Count;
            if (s < 0) s = Math.Max(c + s + 1, 0);
            if (s > c) s = c;
            if (e < 0) e = Math.Max(c + e + 1, 0);
            if (e > c) e = c;

            if (s < e)
                for (int i = s; i < e; i++)
                    yield return body.ElementAt(i);
            else if (s > e)
                for (int i = s - 1; i >= e; i--)
                    yield return body.ElementAt(i);
            else
                yield break;        
        }

        public Ribbon<T> Add(T e) {
            body.Add(e);
            return this;
        }

        public Ribbon<T> Add(params T[] es)
        {
            es.Each(e => body.Add(e));
            return this;
        }

        public T this[int i] {
            get {
                var c = body.Count;
                return (i >= c || i < -c) ? default(T) :
                       (i < 0) ? body.ElementAt(c + i) :
                       body.ElementAt(i);
            }
        }

        public Ribbon<T> this[int s, int e]
        {
            get { return new Ribbon<T>(Slice(s, e)); }
        }

    }

}
