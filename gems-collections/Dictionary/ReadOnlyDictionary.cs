using System;
using System.Collections;
using System.Collections.Generic;

namespace gems_collections.Dictionary
{
    public class ReadOnlyDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private readonly IDictionary<TKey, TValue> _dictionary;

        public ReadOnlyDictionary()
        {
            _dictionary = new Dictionary<TKey, TValue>();
        }

        public ReadOnlyDictionary(IDictionary<TKey, TValue> pDictionary)
        {
            _dictionary = pDictionary;
        }

        #region IDictionary<TKey,TValue> Members

        void IDictionary<TKey, TValue>.Add(TKey pKey, TValue pValue)
        {
            throw readOnlyException();
        }

        public bool ContainsKey(TKey pKey)
        {
            return _dictionary.ContainsKey(pKey);
        }

        public ICollection<TKey> Keys
        {
            get { return _dictionary.Keys; }
        }

        bool IDictionary<TKey, TValue>.Remove(TKey pKey)
        {
            throw readOnlyException();
        }

        public bool TryGetValue(TKey pKey, out TValue pValue)
        {
            return _dictionary.TryGetValue(pKey, out pValue);
        }

        public ICollection<TValue> Values
        {
            get { return _dictionary.Values; }
        }

        public TValue this[TKey pKey]
        {
            get
            {
                return _dictionary[pKey];
            }
        }

        TValue IDictionary<TKey, TValue>.this[TKey pKey]
        {
            get
            {
                return this[pKey];
            }
            set
            {
                throw readOnlyException();
            }
        }

        #endregion

        #region ICollection<KeyValuePair<TKey,TValue>> Members

        void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> pItem)
        {
            throw readOnlyException();
        }

        void ICollection<KeyValuePair<TKey, TValue>>.Clear()
        {
            throw readOnlyException();
        }

        public bool Contains(KeyValuePair<TKey, TValue> pItem)
        {
            return _dictionary.Contains(pItem);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] pArray, int pArrayIndex)
        {
            _dictionary.CopyTo(pArray, pArrayIndex);
        }

        public int Count
        {
            get { return _dictionary.Count; }
        }

        public bool IsReadOnly
        {
            get { return true; }
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> pItem)
        {
            throw readOnlyException();
        }

        #endregion

        #region IEnumerable<KeyValuePair<TKey,TValue>> Members

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        private static Exception readOnlyException()
        {
            return new NotSupportedException("This dictionary is read-only");
        }
    }
}
