using System;

namespace ExtensionHelpers
{
    public static partial class ExtensionHelpers
    {
        /// <summary>
        /// Determines if a given datetime is between two other datetimes.
        /// </summary>
        /// <param name="dateTime">The given DateTime.</param>
        /// <param name="first">The first datetime.</param>
        /// <param name="second">The second Datetime.</param>
        /// <returns>True if the given datetime is between the first and second datetimes.  False if not.</returns>
        public static bool IsBetween(this DateTime dateTime, DateTime first, DateTime second)
        {
            return (dateTime >= first && dateTime <= second) || (dateTime <= first && dateTime >= second);
        }

        /// <summary>
        /// Determines if a given datetime is before or equal to another datetime.
        /// </summary>
        /// <param name="dateTime">The given datetime.</param>
        /// <param name="compareDate">The datetime to compare against.</param>
        /// <returns>True if the given datetime falls before or is equal to the compared datetime. False otherwise.</returns>
        public static bool IsBeforeOrEqual(this DateTime dateTime, DateTime compareDate)
        {
            return dateTime <= compareDate;
        }

        /// <summary>
        /// Determines if a given datetime is after or equal to another datetime.
        /// </summary>
        /// <param name="dateTime">The given datetime.</param>
        /// <param name="compareDate">The datetime to compare against.</param>
        /// <returns>True if the given datetime falls after or is equal to the compared datetime.  False otherwise.</returns>
        public static bool IsAfterOrEqual(this DateTime dateTime, DateTime compareDate)
        {
            return dateTime >= compareDate;
        }
    }
}