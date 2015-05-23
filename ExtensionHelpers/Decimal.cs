using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtensionHelpers
{
    public static partial class ExtensionHelpers
    {
        /// <summary>
        /// Converts a decimal value to a money string.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The money representation.</returns>
        public static string ToMoney(this decimal value)
        {
            return string.Format("{0:C}", value);
        }

        /// <summary>
        /// Converts a decimal value to a percentage string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The percent representation.</returns>
        public static string ToPercent(this decimal value)
        {
            return String.Format("{0:P2}", value);
        }
    }
}