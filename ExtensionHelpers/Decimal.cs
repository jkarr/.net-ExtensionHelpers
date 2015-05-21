using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtensionHelpers
{
    public static partial class ExtensionHelpers
    {
        public static string ToMoney(this decimal value)
        {
            return string.Format("{0:C}", value);
        }

        public static string ToPercent(this decimal value)
        {
            return String.Format("{0:P2}", value);
        }
    }
}
