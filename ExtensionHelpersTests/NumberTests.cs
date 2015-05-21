using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExtensionHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtensionHelpers.Tests
{
    [TestClass()]
    public class NumberTests
    {
        private long l = 85743;
        private int i = 463;

        [TestMethod()]
        public void IsBetweenNumberLongTest()
        {
            Assert.IsTrue(l.IsBetween(1, 999999));
        }

        [TestMethod()]
        public void IsBetweenNumberIntTest()
        {
            Assert.IsTrue(i.IsBetween(1, 999));
        }
    }
}