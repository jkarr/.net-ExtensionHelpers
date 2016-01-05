using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtensionHelpers.Tests
{
    [TestClass]
    public class BooleanTests
    {
        [TestMethod]
        public void ToCustomString_True()
        {
            Assert.AreEqual("Yes", true.ToCustomString("Yes", "No"));
        }

        [TestMethod]
        public void ToCustomString_False()
        {
            Assert.AreEqual("No", false.ToCustomString("Yes", "No"));
        }

        [TestMethod]
        public void ToCustomString_True_Null()
        {
            Assert.AreEqual("true", true.ToCustomString(null, null));
        }

        [TestMethod]
        public void ToCustomString_False_Null()
        {
            Assert.AreEqual("false", false.ToCustomString(null, null));
        }
    }
}