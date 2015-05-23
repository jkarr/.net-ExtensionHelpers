using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtensionHelpers
{
    public static partial class ExtensionHelpers
    {
        /// <summary>
        /// Serializes a dictionary to a list
        /// </summary>
        public static List<KeyValuePair<T1, T2>> Serialize<T1, T2>(this IDictionary<T1, T2> dictionary)
        {
            List<KeyValuePair<T1, T2>> list = new List<KeyValuePair<T1, T2>>();
            list.AddRange(dictionary);
            return list;
        }

        /// <summary>
        /// Add a range of KeyValuePairs to the dictionary
        /// </summary>
        /// <param name="dictionary">The dictionary to add to.</param>
        /// <param name="entries">The range of values to add.</param>
        /// <param name="overrideEntries">True to override values, whose keys exist in both the entries and the dictionary collections.</param>
        public static void AddRange<T1, T2>(this IDictionary<T1, T2> dictionary, IDictionary<T1, T2> entries, bool overrideEntries = false)
        {
            foreach(var entry in entries)
            {
                if(dictionary.ContainsKey(entry.Key))
                {
                    if(overrideEntries)
                    {
                        dictionary[entry.Key] = entry.Value;
                    }
                }
                else
                {
                    dictionary.Add(entry.Key, entry.Value);
                }
            }
        }

        /// <summary>
        /// Copies a dictionary by value.
        /// </summary>
        /// <param name="dictionary">the dictionary to copy</param>
        /// <returns>A new dictionary</returns>
        public static Dictionary<T1, T2> CopyByValue<T1, T2>(this IDictionary<T1, T2> dictionary)
        {
            var newDictionary = new Dictionary<T1, T2>();
            newDictionary.AddRange(dictionary);

            return newDictionary;
        }

        /// <summary>
        /// Adds a value if the key doesn't already exist in the collection.  Optionally overwrite if the value does exist.
        /// </summary>
        /// <param name="dictionary">The dictionary to add to.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The pair.</param>
        /// <param name="overrideExisting">If true, override the value for the found key.  If false, do not override.  Only taken into account if the key already exists.</param>
        public static void AddIfNotExists<T1, T2>(this IDictionary<T1, T2> dictionary, T1 key, T2 value, bool overrideExisting = false)
        {
            if (dictionary.ContainsKey(key))
            {
                if(overrideExisting)
                {
                    dictionary[key] = value;
                }
            }
            else
            {
                dictionary.Add(key, value);
            }
        }
    }
}