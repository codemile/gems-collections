using System.Collections.Generic;
using System.Threading;

namespace gems_collections.Dictionary
{
    /// <summary>
    /// Creates a different Dictionary instance for each thread that
    /// accesses this object.
    /// 
    /// When a thread is finished it should call the Release() method
    /// to free memory.
    /// </summary>
    public class ThreadPoolDictionary<TKey, TValue>
    {
        /// <summary>
        /// The inner dictionary
        /// </summary>
        private readonly Dictionary<int, Dictionary<TKey, TValue>> _value;

        /// <summary>
        /// Access the Dictionary for the current thread. If the Dictionary
        /// doesn't exist one will be created.
        /// </summary>
        public Dictionary<TKey, TValue> Value
        {
            get
            {
                return get(Thread.CurrentThread.ManagedThreadId);
            }
            private set
            {
                set(Thread.CurrentThread.ManagedThreadId, value);
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ThreadPoolDictionary()
        {
            _value = new Dictionary<int, Dictionary<TKey, TValue>>();
        }

        /// <summary>
        /// Gets the Dictionary for a given thread ID.
        /// </summary>
        public Dictionary<TKey, TValue> get(int pThreadID)
        {
            lock (_value)
            {
                if (!_value.ContainsKey(pThreadID))
                {
                    _value.Add(pThreadID, new Dictionary<TKey, TValue>());
                }
                return _value[pThreadID];
            }
        }

        /// <summary>
        /// Sets the Dictionary for a given thread ID.
        /// </summary>
        /// <param name="pThreadID"></param>
        /// <param name="pDict"></param>
        public void set(int pThreadID, Dictionary<TKey, TValue> pDict)
        {
            lock (_value)
            {
                _value[pThreadID] = pDict;
            }
        }

        /// <summary>
        /// Release memory used by the current thread.
        /// </summary>
        public void Release()
        {
            Release(Thread.CurrentThread.ManagedThreadId);
        }

        /// <summary>
        /// Releases memory for a give thread.
        /// </summary>
        public void Release(int pThreadID)
        {
            lock (_value)
            {
                _value.Remove(pThreadID);
            }
        }
    }
}
