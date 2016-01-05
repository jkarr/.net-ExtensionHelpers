using System.Collections.Generic;
using System.Linq;

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
        /// Convers a List of KeyValuePair back to a Dictionary.
        /// </summary>
        /// <param name="list">The list that represents a serialized dictionary</param>
        /// <returns>A dictionary</returns>
        public static Dictionary<T1, T2> DeSerialize<T1, T2>(this List<KeyValuePair<T1, T2>> list)
        {
            Dictionary<T1, T2> dictionary = new Dictionary<T1, T2>();
            dictionary.AddRange(list.ToDictionary(k => k.Key, k => k.Value));
            return dictionary;
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
                dictionary.AddIfNotExists(entry.Key, entry.Value, overrideEntries);
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

        /// <summary>
        /// Compares Two Dictionaries For Equality.  Order of entries doesn't matter.
        /// </summary>
        /// <param name="dictionary1">The first Dictionary.</param>
        /// <param name="dictionary2">The second Dictionary.</param>
        /// <returns>True if both dictionaries are the same.  False otherwise.</returns>
        public static bool IsEqualTo<T1, T2>(this IDictionary<T1, T2> dictionary1, Dictionary<T1, T2> dictionary2)
        {
            if (dictionary1 == null)
            {
                dictionary1 = new Dictionary<T1, T2>();
            }

            if (dictionary2 == null)
            {
                dictionary2 = new Dictionary<T1, T2>();
            }

            if (!dictionary1.Any() && !dictionary2.Any())
            {
                return true;
            }

            if (dictionary1.Count != dictionary2.Count)
            {
                return false;
            }

            Dictionary<T1, T2> dictionary3 = dictionary2.CopyByValue();

            foreach (var item in dictionary1)
            {
                var match = dictionary3[item.Key];

                if (match == null)
                {
                    return false;
                }

                if (!match.Equals(item.Value))
                {
                    return false;
                }

                dictionary3.Remove(item.Key);
            }

            return !dictionary3.Any();
        }
    }
}