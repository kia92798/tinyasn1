using System;
using System.Collections.Generic;

namespace tinyAsn1
{
    // The difference with the normal dictionary is that
    // the Values property retains order (as inserted)
    public class OrderedDictionary<TKey, TValue> 
    {
        Dictionary<TKey, TValue> m_keyval = new Dictionary<TKey, TValue>();
        List<TValue> m_values = new List<TValue>();
        List<TKey> m_keys = new List<TKey>();

        public void Add(TKey key, TValue value)
        {
            m_keyval.Add(key, value);
            m_values.Add(value);
            m_keys.Add(key);
        }

        public TValue this[TKey key] {
            get
            {
                return m_keyval[key];
            }
        }

        public bool ContainsKey(TKey key)
        {
            return m_keyval.ContainsKey(key);
        }



        public List<TValue> Values {
            get { return m_values; }
        }
        public List<TKey> Keys
        {
            get { return m_keys; }
        }
        public int Count { get { return m_values.Count; } }
    }

}