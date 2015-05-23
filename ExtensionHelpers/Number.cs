using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtensionHelpers
{
    public static partial class ExtensionHelpers
    {
        /// <summary>
        /// Determines if a number falls between two other numbers.
        /// </summary>
        /// <param name="number">The number to compare.</param>
        /// <param name="first">The first number.</param>
        /// <param name="second">The second number.</param>
        /// <returns>True if the given number is between the first and second numbers.</returns>
        public static bool IsBetween(this long number, long first, long second)
        {
            return number >= first && number <= second;
        }

        /// <summary>
        /// Determines if a number falls between two other numbers.
        /// </summary>
        /// <param name="number">The number to compare.</param>
        /// <param name="first">The first number.</param>
        /// <param name="second">The second number.</param>
        /// <returns>True if the given number is between the first and second numbers.</returns>
        public static bool IsBetween(this int number, int first, int second)
        {
            return number >= first && number <= second;
        }
    }
}
