using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dotless
{
    public class DictionaryLess<K,V>: IDictionary<K, V>
    {
        private readonly V _DefValue;

        public V DefValue { get { return _DefValue; } }

        private IDictionary<K, V> Adptee;

        public IDictionary<K, V> More { get { return this.Adptee; } }


        #region [ Constructors ]

        // Wrapper Constructors
        public DictionaryLess(IDictionary<K, V> adptee)
        {
            this.Adptee = adptee ?? new Dictionary<K, V>();
        }

        // Empty Constructors
        public DictionaryLess() : this(null) { }

        // Build Constructors
        public DictionaryLess(IEnumerable<V> elems, Func<V, K> fetchKey) : this(null) 
        { 
            if(Null.AnyOf(elems, fetchKey)) return;
            foreach (var i in elems)
                this[fetchKey(i)] = i;
        } 
        
        #endregion


        #region [ Expressiveness ]
        
        public V this[K key]
        {
            get { return this.Get(key); }
            set { this.Add(key, value); }
        }

        #endregion

        #region [ Colletion Item Manipulation ]

        public bool ContainsKey(K key)
        {
            return Adptee.ContainsKey(key);
        }

        public bool HasKey(K key)
        {
            return this.ContainsKey(key);
        }

        public virtual V Get(K key)
        {
            V value;
            return (Adptee.TryGetValue(key, out value)) ? value : DefValue;
        }

        public virtual DictionaryLess<K, V> Add(K key, V value)
        {
            Adptee[key] = value;
            return this; // Fluent
        }

        public DictionaryLess<K, V> AddUnless(K key, V value, bool condition)
        {
            if (!condition) Adptee[key] = value;
            return this; // Fluent
        }

        public DictionaryLess<K, V> AddDefault(K key, V value)
        {
            return AddUnless(key, value, Adptee.ContainsKey(key)); // Fluent
        }

        public DictionaryLess<K, V> Remove(K key)
        {
            Adptee.Remove(key);
            return this; // Fluent
        }

        public DictionaryLess<K, V> RemoveUnless(K key, bool condition)
        {
            if (!condition) Adptee.Remove(key);
            return this; // Fluent
        }

        #endregion

        public int Count { get { return Adptee.Count; } }

        public bool IsEmpty { get { return this.Adptee.FirstOrDefault().Value.Equals(DefValue); } }

        public DictionaryLess<K, V> Overlap(IDictionary<K, V> that)
        {
            that.Each(e => this.Add(e.Key, e.Value));
            return this; // Fluent
        }

        public DictionaryLess<K, V> Defaults(IDictionary<K, V> that)
        {
            that.Each(e => this.AddDefault(e.Key, e.Value));
            return this; // Fluent
        }

        public DictionaryLess<K, V> Clear() 
        {
            Adptee.Clear();
            return this; // Fluent
        }

        #region [ Explicit Implementations ]

        void IDictionary<K, V>.Add(K key, V value) { Add(key, value); }

        ICollection<K> IDictionary<K, V>.Keys
        {
            get { throw new NotImplementedException(); }
        }

        ICollection<V> IDictionary<K, V>.Values
        {
            get { throw new NotImplementedException(); }
        }

        bool IDictionary<K, V>.Remove(K key)
        {
            var hit = this.ContainsKey(key);
            this.Remove(key);
            return hit;
        }

        bool IDictionary<K, V>.TryGetValue(K key, out V value)
        {
            value = this.Get(key);
            return true;
        }
       
        void ICollection<KeyValuePair<K, V>>.Add(KeyValuePair<K, V> item) { this.Add(item.Key, item.Value); }

        void ICollection<KeyValuePair<K, V>>.Clear() { this.Clear(); }

        bool ICollection<KeyValuePair<K, V>>.Contains(KeyValuePair<K, V> item)
        {
            var hit = Get(item.Key);
            return Null.AllOf(hit, item) || hit.Equals(item.Value);
        }

        void ICollection<KeyValuePair<K, V>>.CopyTo(KeyValuePair<K, V>[] array, int arrayIndex)
        {
            Adptee.CopyTo(array, arrayIndex);
        }

        bool ICollection<KeyValuePair<K, V>>.IsReadOnly { get { return false; } }

        bool ICollection<KeyValuePair<K, V>>.Remove(KeyValuePair<K, V> item)
        {
            return (((IDictionary<K, V>)this).Contains(item))
                    ? this.Remove(item.Key).True()
                    : false;
        }

        IEnumerator<KeyValuePair<K, V>> IEnumerable<KeyValuePair<K, V>>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        } 
        
        #endregion
    }

    public class Dictless<K, V> : DictionaryLess<K, V> { 
    
        public Dictless(IDictionary<K, V> adptee): base(adptee) {}

        public Dictless(): base() { }

        public Dictless(IEnumerable<V> elems, Func<V, K> fetchKey): base(elems, fetchKey) { }
    
    }

}
