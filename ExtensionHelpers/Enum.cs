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

        public static T ToEnum<T>(this int value)
        {
            return (T)Enum.Parse(typeof(T), value.ToString());
        }

        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }
    }
}
