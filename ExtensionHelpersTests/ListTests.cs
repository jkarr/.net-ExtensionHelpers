using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ExtensionHelpers;

namespace ExtensionHelpers.Tests
{
    [TestClass]
    public class ListTests
    {
        [TestMethod]
        public void CopyByValueListTest()
        {
            var newList = testList.CopyByValue();

            Assert.IsFalse(Object.ReferenceEquals(newList, testList));
            Assert.IsTrue(newList.Count == testList.Count);
        }

        [TestMethod]
        public void AddIfNotExistsListTestValueDoesExist()
        {
            testList.AddIfNotExists("Bob");
            Assert.IsTrue(testList.Count == 3);
        }

        [TestMethod]
        public void AddIfNotExistsListTestValueDoesNotExist()
        {
            testList.AddIfNotExists("John");
            Assert.IsTrue(testList.Count == 4);
            Assert.IsTrue(testList.Contains("John"));
        }

        private List<string> testList = new List<string>
        {
            { "Bob" },
            { "Sally" },
            { "Joe" }
        };
    }
}
