using System;
using System.Text.RegularExpressions;

namespace ExtensionHelpers
{
    public static partial class ExtensionHelpers
    {
        /// <summary>
        /// Checks String.IsNullOrEmpty
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns>True if null or empty.  False otherwise.</returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// Checks String.IsNullOrWhiteSpace
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns>True if null or whitespace.  False otherwise.</returns>
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// Checks String.IsNullOrEmpty andalso String.IsNullOrWhiteSpace
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns>True if Null Or Empty or WhiteSpace.  False otherwise.</returns>
        public static bool IsNullOrEmptyOrWhiteSpace(this string value)
        {
            return (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value));
        }

        /// <summary>
        /// Determines if a string is a number.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns>True if a number.  False otherwise.</returns>
        public static bool IsNumeric(this string value)
        {
            long result;
            return long.TryParse(value, System.Globalization.NumberStyles.Integer, System.Globalization.NumberFormatInfo.InvariantInfo, out result);
        }

        /// <summary>
        /// Removes any non digit character from a string.
        /// </summary>
        /// <param name="value">The string to parse.</param>
        /// <returns>The string without any numeric digits.</returns>
        public static string RemoveNonDigits(this string value)
        {
            return Regex.Replace(value, "[^0-9]", string.Empty);
        }

        /// <summary>
        /// Truncates a string down to a maximum number of characters, followed by an elipses(...)(if truncated).
        /// </summary>
        /// <param name="value">The string.</param>
        /// <param name="maxCharacters">The maximum characters to retain.</param>
        /// <returns>The provided string, truncated to the max number of characters, followed by an elipses (if truncated).</returns>
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

        /// <summary>
        /// Truncates a string down to a maximum number of characters, and surrounds the string with the given string.
        /// </summary>
        /// <param name="value">The string.</param>
        /// <param name="maxCharacters">The maximum number of characters.</param>
        /// <param name="surroundWith">The string to surround with.</param>
        /// <returns>The provided string, truncated to the max number of characters, surrounded with the surroundWith string.</returns>
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

        /// <summary>
        /// Surrounds a given string with a given string.
        /// </summary>
        /// <param name="value">The string to surround.</param>
        /// <param name="surroundWith">The string to place at the beginning and end.</param>
        /// <returns>The string surrounded with the surroundWith string.</returns>
        public static string Surround(this string value, string surroundWith)
        {
            return string.Format("{0}{1}{0}", surroundWith, value);
        }

        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="oldValue">The string to be replaced.</param>
        /// <param name="newValue">The string to replace all occurences of oldValue.</param>
        /// <param name="comparison">The StringComparison to use.</param>
        /// <param name="recursive">True to replace all instances of oldValue, False to replace only the first instance of oldValue.</param>
        /// <returns>
        /// A string that is equivalent to the current string except that all instances of
        /// oldValue are replaced with newValue.
        /// </returns>
        public static string Replace(this string source, string oldValue, string newValue, StringComparison comparison, bool recursive = true)
        {
            if (newValue == null)
            {
                newValue = string.Empty;
            }

            if (source.IsNullOrEmpty())
            {
                if (oldValue.IsNullOrEmpty())
                {
                    return newValue;
                }
                else
                {
                    return source;
                }
            }

            if (oldValue.IsNullOrEmpty())
            {
                return source;
            }

            if (newValue == null)
            {
                newValue = string.Empty;
            }

            int index = source.IndexOf(oldValue, comparison);

            source.Replace("a", "b");

            while (index > -1)
            {
                source = source.Remove(index, oldValue.Length);
                source = source.Insert(index, newValue);

                if (!recursive)
                {
                    return source;
                }

                index = source.IndexOf(oldValue, index + newValue.Length, comparison);
            }

            return source;
        }
    }
}