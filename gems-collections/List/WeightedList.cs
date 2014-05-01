using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace gems_collections.List
{
    /// <summary>
    /// Holds a collection of items. Each having a weight relative to
    /// the other items in the collection.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class WeightedList<T> : IList<T>
    {
        /// <summary>
        /// The items.
        /// </summary>
        private readonly List<T> _items;

        /// <summary>
        /// A unit used to normalize the weights.
        /// </summary>
        private readonly List<int> _units;

        /// <summary>
        /// The percentage of each item.
        /// </summary>
        private List<float> _weights;

        /// <summary>
        /// True to normalize.
        /// </summary>
        private bool _modified;

        /// <summary>
        /// Constructor
        /// </summary>
        public WeightedList()
        {
            _items = new List<T>();
            _units = new List<int>();
            _weights = new List<float>();
            _modified = false;
        }

        /// <summary>
        /// Adds an item to the collection.
        /// </summary>
        /// <param name="pItem">The item</param>
        /// <param name="pUnits">It's weight</param>
        public void Add(T pItem, int pUnits)
        {
            if (pUnits <= 0)
            {
                throw new ArgumentOutOfRangeException("pUnits",@"Must be greater than 0.");
            }
            _items.Add(pItem);
            _units.Add(pUnits);
            _modified = true;
        }

        /// <summary>
        /// Normalizes the weights of all items.
        /// </summary>
        private void Noramlize()
        {
            if (!_modified)
            {
                return;
            }

            int total = _units.Sum(pItem=>pItem);
            float delta = 1.0f / (float)total;
            _weights = (from u in _units select (float)u * delta).ToList();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<T> GetEnumerator()
        {
            Noramlize();
            return _items.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            Noramlize();
            return GetEnumerator();
        }

        /// <summary>
        /// Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <param name="pItem">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param><exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.</exception>
        public void Add(T pItem)
        {
            _items.Add(pItem);
            _units.Add(1);
            _modified = true;
        }

        /// <summary>
        /// Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only. </exception>
        public void Clear()
        {
            _items.Clear();
            _units.Clear();
            _weights.Clear();
            _modified = true;
        }

        /// <summary>
        /// Determines whether the <see cref="T:System.Collections.Generic.ICollection`1"/> contains a specific value.
        /// </summary>
        /// <returns>
        /// true if <paramref name="pItem"/> is found in the <see cref="T:System.Collections.Generic.ICollection`1"/>; otherwise, false.
        /// </returns>
        /// <param name="pItem">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
        public bool Contains(T pItem)
        {
            return _items.Contains(pItem);
        }

        /// <summary>
        /// Copies the elements of the <see cref="T:System.Collections.Generic.ICollection`1"/> to an <see cref="T:System.Array"/>, starting at a particular <see cref="T:System.Array"/> index.
        /// </summary>
        /// <param name="pArray">The one-dimensional <see cref="T:System.Array"/> that is the destination of the elements copied from <see cref="T:System.Collections.Generic.ICollection`1"/>. The <see cref="T:System.Array"/> must have zero-based indexing.</param><param name="pArrayIndex">The zero-based index in <paramref name="pArray"/> at which copying begins.</param><exception cref="T:System.ArgumentNullException"><paramref name="pArray"/> is null.</exception><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="pArrayIndex"/> is less than 0.</exception><exception cref="T:System.ArgumentException">The number of elements in the source <see cref="T:System.Collections.Generic.ICollection`1"/> is greater than the available space from <paramref name="pArrayIndex"/> to the end of the destination <paramref name="pArray"/>.</exception>
        public void CopyTo(T[] pArray, int pArrayIndex)
        {
            _items.CopyTo(pArray,pArrayIndex);
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <returns>
        /// true if <paramref name="pItem"/> was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1"/>; otherwise, false. This method also returns false if <paramref name="pItem"/> is not found in the original <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </returns>
        /// <param name="pItem">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param><exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.</exception>
        public bool Remove(T pItem)
        {
            _modified = true;
            int i = _items.IndexOf(pItem);
            if (i == -1)
            {
                return false;
            }
            _items.RemoveAt(i);
            _units.RemoveAt(i);
            return true;
        }

        /// <summary>
        /// Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <returns>
        /// The number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </returns>
        public int Count
        {
            get { return _items.Count; }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.
        /// </summary>
        /// <returns>
        /// true if the <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only; otherwise, false.
        /// </returns>
        public bool IsReadOnly 
        {
            get { return false; }
        }

        /// <summary>
        /// Determines the index of a specific item in the <see cref="T:System.Collections.Generic.IList`1"/>.
        /// </summary>
        /// <returns>
        /// The index of <paramref name="pItem"/> if found in the list; otherwise, -1.
        /// </returns>
        /// <param name="pItem">The object to locate in the <see cref="T:System.Collections.Generic.IList`1"/>.</param>
        public int IndexOf(T pItem)
        {
            return _items.IndexOf(pItem);
        }

        /// <summary>
        /// Inserts an item to the <see cref="T:System.Collections.Generic.IList`1"/> at the specified index.
        /// </summary>
        /// <param name="pIndex">The zero-based index at which <paramref name="pItem"/> should be inserted.</param><param name="pItem">The object to insert into the <see cref="T:System.Collections.Generic.IList`1"/>.</param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="pIndex"/> is not a valid index in the <see cref="T:System.Collections.Generic.IList`1"/>.</exception><exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.IList`1"/> is read-only.</exception>
        public void Insert(int pIndex, T pItem)
        {
            _modified = true;
            _items.Insert(pIndex, pItem);
            _units.Insert(pIndex,1);
        }

        /// <summary>
        /// Removes the <see cref="T:System.Collections.Generic.IList`1"/> item at the specified index.
        /// </summary>
        /// <param name="pIndex">The zero-based index of the item to remove.</param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="pIndex"/> is not a valid index in the <see cref="T:System.Collections.Generic.IList`1"/>.</exception><exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.IList`1"/> is read-only.</exception>
        public void RemoveAt(int pIndex)
        {
            _modified = true;
            _items.RemoveAt(pIndex);
        }

        /// <summary>
        /// Gets or sets the element at the specified index.
        /// </summary>
        /// <returns>
        /// The element at the specified index.
        /// </returns>
        /// <param name="pIndex">The zero-based index of the element to get or set.</param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="pIndex"/> is not a valid index in the <see cref="T:System.Collections.Generic.IList`1"/>.</exception><exception cref="T:System.NotSupportedException">The property is set and the <see cref="T:System.Collections.Generic.IList`1"/> is read-only.</exception>
        public T this[int pIndex]
        {
            get { return _items[pIndex]; }
            set { _items[pIndex] = value; }
        }

        /// <summary>
        /// Gets the weight associated with an item.
        /// </summary>
        /// <param name="pIndex"></param>
        /// <returns></returns>
        public float getWeight(int pIndex)
        {
            Noramlize();
            return _weights[pIndex];
        }

        /// <summary>
        /// Gets the weight associated with an item.
        /// </summary>
        /// <param name="pItem"></param>
        /// <returns></returns>
        public float getWeight(T pItem)
        {
            Noramlize();
            return _weights[_items.IndexOf(pItem)];
        }
    }
}
