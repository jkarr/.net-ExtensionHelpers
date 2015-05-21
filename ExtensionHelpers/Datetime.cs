using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtensionHelpers
{
    public static partial class ExtensionHelpers
    {
        public static bool IsBetween(this DateTime dateTime, DateTime from, DateTime to)
        {
            return dateTime >= from && dateTime <= to;
        }

        public static bool IsBeforeOrEqual(this DateTime dateTime, DateTime compareDate)
        {
            return dateTime <= compareDate;
        }

        public static bool IsAfterOrEqual(this DateTime dateTime, DateTime compareDate)
        {
            return dateTime >= compareDate;
        }
    }
}
