using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ExtensionHelpers.Tests
{
    [TestClass()]
    public class DictionaryTests
    {
        [TestMethod]
        public void SerializeDictionaryTest()
        {
            var list = testDictionary.Serialize();
            Assert.IsTrue(list.Count == testDictionary.Count);
            Assert.IsTrue(list[0].Key == 1 && list[0].Value == "Bob");
        }

        [TestMethod]
        public void DeSerializeDictionaryTest()
        {
            var list = testDictionary.Serialize();
            var dictionary = list.DeSerialize();
            Assert.IsTrue(dictionary.Count == testDictionary.Count);
            Assert.IsTrue(dictionary[1] == "Bob");
        }

        [TestMethod]
        public void AddRangeDictionaryNoOverrideTest()
        {
            testDictionary.AddRange(testDictionary2, false);
            Assert.IsTrue(testDictionary.Count == 5);
            Assert.IsTrue(testDictionary[1] == "Bob");
        }

        [TestMethod]
        public void AddRangeDictionaryOverrideTest()
        {
            testDictionary.AddRange(testDictionary2, true);
            Assert.IsTrue(testDictionary.Count == 5);
            Assert.IsTrue(testDictionary[1] == "Cain");
        }

        [TestMethod]
        public void CopyByValueDictionaryTest()
        {
            var newDictionary = testDictionary.CopyByValue();
            Assert.IsFalse(Object.ReferenceEquals(newDictionary, testDictionary));
            Assert.IsTrue(newDictionary.Count == testDictionary.Count);
        }

        [TestMethod]
        public void AddIfNotExistsDictionaryTestKeyExistsNoOverride()
        {
            testDictionary.AddIfNotExists(1, "John", false);
            Assert.IsFalse(testDictionary[1] == "John");
        }

        [TestMethod]
        public void AddIfNotExistsDictionaryTestKeyExistsOverride()
        {
            testDictionary.AddIfNotExists(1, "John", true);
            Assert.IsTrue(testDictionary[1] == "John");
        }

        [TestMethod]
        public void AddIfNotExistsDictionaryTestKeyDoesNotExist()
        {
            testDictionary.AddIfNotExists(4, "Amy");
            Assert.IsTrue(testDictionary.Count == 4);
            Assert.IsTrue(testDictionary.ContainsKey(4) && testDictionary[4] == "Amy");
        }

        [TestMethod]
        public void IsEqualTo_Equal()
        {
            Assert.IsTrue(testDictionary.IsEqualTo(testDictionary3));
        }

        [TestMethod]
        public void IsEqualTo_NotEqual()
        {
            Assert.IsFalse(testDictionary.IsEqualTo(testDictionary2));
        }

        [TestMethod]
        public void IsEqualTo_OriginalIsNull()
        {
            Dictionary<int, string> nullDictionary = null;
            Assert.IsFalse(nullDictionary.IsEqualTo(testDictionary2));
        }

        [TestMethod]
        public void IsEqualTo_CompareIsNull()
        {
            Dictionary<int, string> nullDictionary = null;
            Assert.IsFalse(testDictionary2.IsEqualTo(nullDictionary));        
        }

        [TestMethod]
        public void IsEqualTo_BothAreNull()
        {
            Dictionary<int, string> nullDictionary = null;
            Dictionary<int, string> nullDictionary2 = null;
            Assert.IsTrue(nullDictionary.IsEqualTo(nullDictionary2));
        }

        private Dictionary<int, string> testDictionary = new Dictionary<int, string>
        {
            { 1, "Bob" },
            { 2, "Alice" },
            { 3, "John" }
        };

        private Dictionary<int, string> testDictionary2 = new Dictionary<int, string>
        {
            { 1, "Cain" },
            { 4, "Sue" },
            { 5, "Allen" }
        };

        private Dictionary<int, string> testDictionary3 = new Dictionary<int, string>
        {
            { 1, "Bob" },
            { 2, "Alice" },
            { 3, "John" }
        };
    }
}