using System;
using System.Collections.Generic;
using System.Linq;

namespace gems_collections.List
{
    /// <summary>
    /// An implementation of the Queue collection that drops items when the
    /// size limit has been reached. The queue will not exceed the size limit
    /// of the list.
    /// 
    /// When a new item is added and the limit is reached. An item from the
    /// bottom of the queue is removed.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    // ReSharper disable InconsistentNaming
    // ReSharper disable MemberCanBePrivate.Global
    public class LimitedList<T> : List<T>
    {
        /// <summary>
        /// The limit on the size of the list.
        /// </summary>
        public int Limit { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pLimit"></param>
        public LimitedList(int pLimit)
        {
            if (pLimit <= 0)
            {
                throw new ArgumentOutOfRangeException("pLimit", @"Must be greater then 1");
            }
            Limit = pLimit;
        }

        /// <summary>
        /// Adds an object to the end of the System.Collections.Generic.List<T>.
        /// </summary>
        /// <param name="pItem">
        /// The object to be added to the end of the System.Collections.Generic.List.
        /// The value can be null for reference types.
        /// </param>
        // ReSharper disable once InconsistentNaming
        public new void Add(T pItem)
        {
            base.Add(pItem);
            if (Count == Limit)
            {
                RemoveAt(Count - 1);
            }
        }

        /// <summary>
        /// Adds the elements of the specified collection to the end of the System.Collections.Generic.List
        /// </summary>
        /// <param name="pCollection">
        /// The collection whose elements should be added to the end of the System.Collections.Generic.List.
        /// The collection itself cannot be null, but it can contain elements that are
        /// null, if type T is a reference type.
        /// </param>
        /// <exception cref="System.ArgumentNullException">collection is null</exception>
        // ReSharper disable once InconsistentNaming
        public new void AddRange(IEnumerable<T> pCollection)
        {
            pCollection.ToList().ForEach(Add);
        }
    }
}
