using System;
using System.Collections.Generic;
using System.Linq;
using GemsCollections.Comparers;

namespace GemsCollections.Enumerable
{
    public static class Enumerated
    {
        /// <summary>
        /// Distinct by a value.
        /// </summary>
        public static IEnumerable<T> Distinct<T, TKey>(this IEnumerable<T> pList, Func<T, TKey> pValue) 
        {
            return pList.Distinct(new EqualComparer<T, TKey>(pValue));
        }

        /// <summary>
        /// Filters the list so it doesn't contain any items from the other list.
        /// </summary>
        public static IEnumerable<T> ExceptThese<T>(this IEnumerable<T> pThis, IEnumerable<T> pThese)
        {
            return pThis.Where(pItem=>!pThese.Contains(pItem));
        }

        public static IEnumerable<T> NotNull<T>(this IEnumerable<T> pThis) where T : class
        {
            return pThis.Where(pItem=>pItem != null);
        }

        /// <summary>
        /// Filters the list so it only contains items found in the other list.
        /// </summary>
        public static IEnumerable<T> OnlyThese<T>(this IEnumerable<T> pThis, IEnumerable<T> pThese)
        {
            return pThis.Where(pThese.Contains);
        }
    }
}