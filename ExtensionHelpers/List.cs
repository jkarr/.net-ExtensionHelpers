using System.Collections.Generic;
using System.Linq;

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

        /// <summary>
        /// Compares two lists for equality, regardless of list order.
        /// </summary>
        /// <param name="list1">The first list.</param>
        /// <param name="list2">The list to compare with.</param>
        /// <returns>True if the lists match, false otherwise.</returns>
        public static bool IsEqualTo<T>(this IList<T> list1, IList<T> list2)
        {
            if (list1.Count != list2.Count)
            {
                return false;
            }

            IList<T> list3 = list2.CopyByValue();

            foreach (var item in list1)
            {
                int index = -1;
                for (int x = 0; x < list3.Count; x++)
                {
                    if (list3[x].Equals(item))
                    {
                        index = x;
                    }
                }

                if (index > -1)
                {
                    list3.RemoveAt(index);
                }
                else
                {
                    return false;
                }
            }

            return !list3.Any();
        }
    }
}