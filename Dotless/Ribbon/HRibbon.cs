using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dotless
{
    public class HRibbon<K,V>: Dictionary<K,V>
    {
        public HRibbon() { }

        public HRibbon(IEnumerable<V> elems, Func<V,K> fetchKey)
        {
            if (fetchKey == null) return;  
        }

        public new V this[K key] {
            get {  
                V value;
                return (this.TryGetValue(key, out value)) ? value : default(V);
            }
            set { base[key] = value; }
        }

        public new HRibbon<K, V> Add(K key, V value) {
            base[key] = value;
            return this;
        }

        public HRibbon<K, V> AddDefault(K key, V value) {
            if (!this.ContainsKey(key))
                base[key] = value;
            return this;
        }

        public HRibbon<K,V> Overlap(IDictionary<K,V> defSource){
            defSource.Each(e => base[e.Key] = e.Value);
            
            return this; // Fluent
        }

        public HRibbon<K, V> Defaults(IDictionary<K, V> defSource)
        {
            defSource.Each(e => this.AddDefault(e.Key, e.Value));

            return this; // Fluent
        }

    }
}
