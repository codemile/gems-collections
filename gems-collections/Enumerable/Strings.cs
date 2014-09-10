using System.Collections.Generic;
using System.Linq;

namespace gems_collections.Enumerable
{
    public static class Strings
    {
        /// <summary>
        /// Only strings with a non-whitespace value.
        /// </summary>
        public static IEnumerable<string> NotNullOrEmpty(this IEnumerable<string> pStrings)
        {
            return pStrings.Where(pItem=>!string.IsNullOrWhiteSpace(pItem));
        }

        /// <summary>
        /// Only the strings that end with.
        /// </summary>
        public static IEnumerable<string> EndsWith(this IEnumerable<string> pStrings, string pWhat)
        {
            return pStrings.Where(pStr=>pStr.EndsWith(pWhat));
        }

        /// <summary>
        /// Only the strings that start with.
        /// </summary>
        public static IEnumerable<string> StartsWith(this IEnumerable<string> pStrings, string pWhat)
        {
            return pStrings.Where(pStr=>pStr.StartsWith(pWhat));
        }

        /// <summary>
        /// Makes all strings lower case.
        /// </summary>
        public static IEnumerable<string> ToLower(this IEnumerable<string> pStrings)
        {
            return pStrings.Select(pStr=>pStr.ToLower());
        }

        /// <summary>
        /// Makes all strings upper case.
        /// </summary>
        public static IEnumerable<string> ToUpper(this IEnumerable<string> pStrings)
        {
            return pStrings.Select(pStr=>pStr.ToUpper());
        }

        /// <summary>
        /// Trims all strings.
        /// </summary>
        public static IEnumerable<string> Trim(this IEnumerable<string> pStrings)
        {
            return pStrings.Select(pStr=>pStr.Trim());
        }
    }
}