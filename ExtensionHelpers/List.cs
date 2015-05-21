using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtensionHelpers
{
    public static partial class ExtensionHelpers
    {
        public static IList<T> CopyByValue<T>(this IList<T> list)
        {
            var newList = new List<T>();
            foreach(var item in list)
            {
                newList.Add(item);
            }

            return newList;
        }
    }
}
