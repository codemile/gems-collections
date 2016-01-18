using System;
using System.Collections.Generic;

namespace GemsCollections.Comparers
{
    public class EqualComparer<T, TKey> : IEqualityComparer<T>
    {
        private readonly Func<T, TKey> _lookup;

        public EqualComparer(Func<T, TKey> pLookup)
        {
            _lookup = pLookup;
        }

        public bool Equals(T pX, T pY)
        {
            string x = _lookup(pX) as string;
            string y = _lookup(pY) as string;
            if (x != null && y != null)
            {
                return String.CompareOrdinal(x, y) == 0;
            }
            return _lookup(pX).Equals(_lookup(pY));
        }

        public int GetHashCode(T pObj)
        {
            return _lookup(pObj).GetHashCode();
        }
    }
}