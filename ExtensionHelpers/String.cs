using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ExtensionHelpers
{
    public static partial class ExtensionHelpers
    {
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static bool IsNullOrEmptyOrWhiteSpace(this string value)
        {
            return (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value));
        }

        public static bool IsNumeric(this string value)
        {
            long result;
            return long.TryParse(value, System.Globalization.NumberStyles.Integer, System.Globalization.NumberFormatInfo.InvariantInfo, out result);
        }

        public static string RemoveNonDigits(this string value)
        {
            return Regex.Replace(value, "[^0-9]", string.Empty);
        }

        public static string Truncate(this string value, int maxCharacters)
        {
            if(value.IsNullOrEmptyOrWhiteSpace())
            {
                return value;
            }

            if(value.Length < maxCharacters)
            {
                return value;
            }

            return value.Substring(0, maxCharacters) + "...";
        }

        public static string Truncate(this string value, int maxCharacters, string surroundWith)
        {
            if(value.IsNullOrEmptyOrWhiteSpace())
            {
                return value;
            }

            if(value.Length < maxCharacters)
            {
                return value.Surround(surroundWith);
            }

            return value.Substring(0, maxCharacters).Surround(surroundWith);
        }

        public static string Surround(this string value, string surroundWith)
        {
            return string.Format("{0}{1}{0}", surroundWith, value);
        }
    }
}
