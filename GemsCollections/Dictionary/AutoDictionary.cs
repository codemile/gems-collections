using System;
using System.Collections.Generic;
using System.Linq;

namespace GemsCollections.Dictionary
{
    /// <summary>
    /// A dictionary that will auto create entries, and remove
    /// entries where the value is empty.
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class AutoDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public AutoDictionary()
        {

        }

        /// <summary>
        /// Constructor from another Dictionary
        /// </summary>
        /// <param name="pPairs"></param>
        public AutoDictionary(IEnumerable<KeyValuePair<TKey, TValue>> pPairs)
        {
            Array.ForEach(pPairs.ToArray(), pPair => this[pPair.Key] = pPair.Value);
        }

        /// <summary>
        /// Auto create entries.
        /// </summary>
        /// <param name="pKey"></param>
        /// <returns></returns>
        public new TValue this[TKey pKey]
        {
            get
            {
                if (!ContainsKey(pKey))
                {
                    Add(pKey, default(TValue));
                }
                return base[pKey];
            }

            set
            {
                if (!ContainsKey(pKey))
                {
                    Add(pKey, value);
                }
                base[pKey] = value;
            }
        }
    }
}
