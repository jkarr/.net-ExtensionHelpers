using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtensionHelpers
{
    public static partial class ExtensionHelpers
    {
        /// <summary>
        /// Copies a list by value.
        /// </summary>
        /// <param name="list">The list to copy.</param>
        /// <returns>A new copy of the list.</returns>
        public static IList<T> CopyByValue<T>(this IList<T> list)
        {
            var newList = new List<T>();
            foreach(var item in list)
            {
                newList.Add(item);
            }

            return newList;
        }

        /// <summary>
        /// Add's a value to the collection if it doesn't already exist.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="value">The value.</param>
        public static void AddIfNotExists<T>(this IList<T> list, T value)
        {
            if(!list.Contains(value))
            {
                list.Add(value);
            }
        }
    }
}
