using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExtensionHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtensionHelpers.Tests
{
    [TestClass()]
    public class DecimalTests
    {
        private decimal testDecimal = 59.74M;

        [TestMethod()]
        public void ToMoneyDecimalTest()
        {
            Assert.IsTrue(testDecimal.ToMoney() == "$59.74");
        }

        [TestMethod()]
        public void ToPercentDecimalTest()
        {
            Assert.IsTrue(testDecimal.ToPercent() == "5,974.00 %");
        }
    }
}