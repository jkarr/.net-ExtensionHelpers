using ExtensionHelpers.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ExtensionHelpers
{
    public static partial class ExtensionHelpers
    {
        // Derived From http://stackoverflow.com/a/4523087/403404
        public struct MemberComparison
        {
            public readonly string MemberName; //Which member this Comparison compares
            public readonly object Value1, Value2;//The values of each object's respective member
            public MemberComparison(string memberName, object value1, object value2)
            {
                MemberName = memberName;
                Value1 = value1;
                Value2 = value2;
            }

            public override string ToString()
            {
                return MemberName + ": " + Value1.ToString() + (Value1.Equals(Value2) ? " == " : " != ") + Value2.ToString();
            }
        }

        // http://stackoverflow.com/a/17139700/403404
        private static bool isCollection(this object obj)
        {
            return obj.GetType().GetInterfaces()
                    .Any(i => (
                            i.Name == "ICollection" || 
                            i.Name == "IEnumerable" || 
                            i.Name == "IList") || 
                            (i.IsGenericTypeDefinition && 
                                (i.GetGenericTypeDefinition() == typeof(ICollection<>) || 
                                i.GetGenericTypeDefinition() == typeof(IEnumerable<>) || i.GetGenericTypeDefinition() == typeof(IList<>))));
        }

        public static List<MemberComparison> ReflectiveCompare<T>(this T x, T y)
        {
            List<MemberComparison> list = new List<MemberComparison>();

            foreach (MemberInfo m in typeof(T).GetMembers(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public))
            {
                // Ignore anything that is not field or property
                if (m.MemberType != MemberTypes.Field && m.MemberType != MemberTypes.Property)
                {
                    continue;
                }

                // ignore auto generated backing fields
                if (m.Name.EndsWith(">k__BackingField", StringComparison.InvariantCulture))
                {
                    continue;
                }

                object[] attributes = m.GetCustomAttributes(typeof(SkipReflectiveCompare), false);

                if (attributes != null && attributes.Length > 0)
                {
                    continue;
                }

                // Only look at fields and properties
                if (m.MemberType == MemberTypes.Field)
                {
                    FieldInfo field = (FieldInfo)m;
                    var xValue = field.GetValue(x);
                    var yValue = field.GetValue(y);

                    if (xValue.isCollection())
                    {
                        IList xCollection = (IList)xValue;
                        IList yCollection = (IList)yValue;
                        list.AddRange(xCollection.ReflectiveCompare(yCollection));
                    }
                    else
                    {
                        if (!object.Equals(xValue, yValue))
                        {
                            list.Add(new MemberComparison(field.Name, xValue, yValue));
                        }
                    }
                }
                else if (m.MemberType == MemberTypes.Property)
                {
                    var prop = (PropertyInfo)m;
                    if (prop.CanRead && prop.GetGetMethod().GetParameters().Length == 0)
                    {
                        var xValue = prop.GetValue(x, null);
                        var yValue = prop.GetValue(y, null);

                        if (xValue.isCollection())
                        {
                            /// http://stackoverflow.com/a/632618/403404
                            var xEnumerator = ((IEnumerable)xValue).GetEnumerator();
                            var yEnumerator = ((IEnumerable)yValue).GetEnumerator();

                            //var collectionType = xValue.GetType().GetGenericArguments()[0];

                            List<object> xCollection = new List<object>();
                            List<object> yCollection = new List<object>();

                            while (xEnumerator.MoveNext())
                            {
                                xCollection.Add(xEnumerator.Current);
                            }

                            while (yEnumerator.MoveNext())
                            {
                                yCollection.Add(yEnumerator.Current);
                            }

                            list.AddRange(xCollection.ReflectiveCompare(yCollection));
                        }
                        else
                        {
                            if (!object.Equals(xValue, yValue))
                            {
                                list.Add(new MemberComparison(prop.Name, xValue, yValue));
                            }
                        }
                    }
                }
            }

            return list;
        }

        public static List<MemberComparison> ReflectiveCompare<T>(this List<T> x, List<T> y)
        {
            List<MemberComparison> list = new List<MemberComparison>();

            if (x.IsEqualTo(y))
            {
                return list;
            }

            IList<T> xCopy = x.CopyByValue();
            IList<T> yCopy = y.CopyByValue();
            IList<T> common = new List<T>();

            // Step 1, Remove common items from x and y
            // Step 2, Note the lists are different

            foreach (var item in x)
            {
                int index = -1;
                int i = 0;

                while (index < 0 && i < yCopy.Count)
                {
                    if (item.ReflectiveCompare(yCopy[i]).Count > 0)
                    {
                        index = i;
                        common.Add(item);
                    }

                    i++;
                }
            }

            foreach (var item in common)
            {
                xCopy.Remove(item);
                yCopy.Remove(item);
            }

            list.Add(new MemberComparison(typeof(T).Name, xCopy, yCopy));

            return list;
        }
    }
}