namespace GemsCollections.Dictionary
{
    /// <summary>
    /// Makes it easy to count the number of occurrences of a key in the form of a dictionary.
    /// </summary>
    public class CountDictionary<T> : AutoDictionary<T, int>
    {
        /// <summary>
        /// Call this method decrease the count on a key.
        /// </summary>
        public void Decrement(T pKey)
        {
            base[pKey] = base[pKey] - 1;
        }

        /// <summary>
        /// Call this method to increase the count on a key.
        /// </summary>
        public void Increment(T pKey)
        {
            base[pKey] = base[pKey] + 1;
        }
    }
}