using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtensionHelpers
{
    public static partial class ExtensionHelpers
    {
        public static bool IsBetween(this long l, long a, long b)
        {
            return l >= a && l <= b;
        }

        public static bool IsBetween(this int i, int a, int b)
        {
            return i >= a && i <= b;
        }
    }
}
