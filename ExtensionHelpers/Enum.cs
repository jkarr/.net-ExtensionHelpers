using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ExtensionHelpers
{
    public static partial class ExtensionHelpers
    {
        /// <summary>
        /// Gets the description of an Enum value.
        /// </summary>
        /// <param name="e">The enum value.</param>
        /// <returns>The description attribute (if exists) or the value.</returns>
        public static string ToDescription(this Enum e)
        {
            Type type = e.GetType();
            MemberInfo[] info = type.GetMember(e.ToString());

            if (info != null && info.Length > 0)
            {
                object[] attributes = info[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes != null && attributes.Length > 0)
                {
                    return ((DescriptionAttribute)attributes[0]).Description;
                }
            }

            return e.ToString();
        }

        /// <summary>
        /// Determines if an Enum value is obsolete.
        /// </summary>
        /// <param name="e">The enum value.</param>
        /// <returns>True if the value is obsolete.  False otherwise.</returns>
        public static bool IsObsolete(this Enum e)
        {
            Type type = e.GetType();
            MemberInfo[] info = type.GetMember(e.ToString());

            if (info != null && info.Length > 0)
            {
                object[] attributes = info[0].GetCustomAttributes(typeof(ObsoleteAttribute), false);
                return attributes != null && attributes.Length > 0;
            }

            return false;
        }

        /// <summary>
        /// Converts an integer to its enum value representation.
        /// </summary>
        /// <typeparam name="T">The Enum type.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>The enum operator represented by the integer for the given enum type.</returns>
        public static T ToEnum<T>(this int value)
        {
            return (T)Enum.Parse(typeof(T), value.ToString());
        }

        /// <summary>
        /// Converts a string to its enum value representation.
        /// </summary>
        /// <typeparam name="T">The Enum type.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>The enum operator represented by the string for the given enum type.</returns>
        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }
    }
}
