using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        public void IsBetweenNumberLongTestBackwards()
        {
            Assert.IsTrue(l.IsBetween(999999, 1));
        }

        [TestMethod()]
        public void IsBetweenNumberIntTest()
        {
            Assert.IsTrue(i.IsBetween(1, 999));
        }

        [TestMethod()]
        public void IsBetweenNumberIntTestBackwards()
        {
            Assert.IsTrue(i.IsBetween(999, 1));
        }
    }
}