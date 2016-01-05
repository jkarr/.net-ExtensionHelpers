using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ExtensionHelpers.Tests
{
    [TestClass()]
    public class DateTimeTests
    {
        private DateTime wayBack = new DateTime(1900, 05, 15, 14, 23, 17);
        private DateTime someBack = new DateTime(1970, 05, 15, 14, 23, 17);
        private DateTime future = new DateTime(3000, 05, 15, 14, 23, 17);

        [TestMethod()]
        public void BetweenDateTimeTest()
        {
            Assert.IsTrue(someBack.IsBetween(wayBack, future));
        }

        [TestMethod()]
        public void BetweenDateTimeTestBackwards()
        {
            Assert.IsTrue(someBack.IsBetween(future, wayBack));
        }

        [TestMethod()]
        public void IsBeforeOrEqualeDateTimeTest()
        {
            Assert.IsTrue(wayBack.IsBeforeOrEqual(future));
        }

        [TestMethod()]
        public void IsAfterOrEqualDateTimeTest()
        {
            Assert.IsTrue(future.IsAfterOrEqual(wayBack));
        }
    }
}