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
        public void CopyByValueList()
        {
            var newList = testList.CopyByValue();

            Assert.IsFalse(Object.ReferenceEquals(newList, testList));
            Assert.IsTrue(newList.Count == testList.Count);
        }

        private List<string> testList = new List<string>
        {
            { "Bob" },
            { "Sally" },
            { "Joe" }
        };
    }
}
