using ExtensionHelpers;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ExtensionHelpers.Tests
{
    [TestClass()]
    public class DictionaryTests
    {
        [TestMethod()]
        public void SerializeDictionaryTest()
        {
            var list = testDictionary.Serialize();
            Assert.IsTrue(list.Count == testDictionary.Count);
            Assert.IsTrue(list[0].Key == 1 && list[0].Value == "Bob");
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
        public void CopyByValueDictionary()
        {
            var newDictionary = testDictionary.CopyByValue();
            Assert.IsFalse(Object.ReferenceEquals(newDictionary, testDictionary));
            Assert.IsTrue(newDictionary.Count == testDictionary.Count);
        }

        private void scrubData()
        {
            testDictionary = new Dictionary<int, string>
            {
                { 1, "Bob" },
                { 2, "Alice" },
                { 3, "John" }
            };
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
    }
}