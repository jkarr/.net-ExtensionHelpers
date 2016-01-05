using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ExtensionHelpers.Tests
{
    [TestClass()]
    public class EnumTests
    {
        private enum Colors
        {
            [System.ComponentModel.Description("Color Blue")]
            Blue,

            [System.ComponentModel.Description("Color White")]
            White,

            [Obsolete("Use Purple Instead")]
            Violet,

            [System.ComponentModel.Description("Color Purple")]
            Purple
        }
        [TestMethod()]
        public void ToDescriptionEnumTest()
        {
            Assert.IsTrue(Colors.Blue.ToDescription() == "Color Blue");
        }

        [TestMethod()]
        public void IsObsoleteEnumTest()
        {
            Assert.IsTrue(Colors.Violet.IsObsolete());
            Assert.IsFalse(Colors.White.IsObsolete());
        }

        [TestMethod()]
        public void ToEnumFromIntEnumTest()
        {
            var i = 1;
            Assert.IsTrue(i.ToEnum<Colors>() == Colors.White);
        }

        [TestMethod()]
        public void ToEnumFromString()
        {
            Assert.IsTrue("Purple".ToEnum<Colors>() == Colors.Purple);
        }
    }
}