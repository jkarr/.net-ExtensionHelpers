using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExtensionHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtensionHelpers.Tests
{
    [TestClass()]
    public class ExtensionHelpersStringTests
    {
        private string nullString = null;
        private string empty = string.Empty;
        private string emptyString = "";
        private string whiteSpace = "  ";
        private string stringText = "text";
        private string numericText = "124";
        private string mixedText = "abc123";

        [TestMethod()]
        public void IsNullOrEmptyStringTest()
        {
            Assert.IsTrue(nullString.IsNullOrEmpty());
            Assert.IsTrue(empty.IsNullOrEmpty());
            Assert.IsTrue(emptyString.IsNullOrEmpty());
            Assert.IsFalse(whiteSpace.IsNullOrEmpty());
            Assert.IsFalse(stringText.IsNullOrEmpty());
        }

        [TestMethod()]
        public void IsNullOrWhiteSpaceStringTest()
        {
            Assert.IsTrue(nullString.IsNullOrWhiteSpace());
            Assert.IsTrue(empty.IsNullOrWhiteSpace());
            Assert.IsTrue(emptyString.IsNullOrWhiteSpace());
            Assert.IsTrue(whiteSpace.IsNullOrWhiteSpace());
            Assert.IsFalse(stringText.IsNullOrWhiteSpace());
        }

        [TestMethod()]
        public void IsNullOrEmptyOrWhiteSpaceStringTest()
        {
            Assert.IsTrue(nullString.IsNullOrEmptyOrWhiteSpace());
            Assert.IsTrue(empty.IsNullOrEmptyOrWhiteSpace());
            Assert.IsTrue(emptyString.IsNullOrEmptyOrWhiteSpace());
            Assert.IsTrue(whiteSpace.IsNullOrEmptyOrWhiteSpace());
            Assert.IsFalse(stringText.IsNullOrEmptyOrWhiteSpace());
        }

        [TestMethod()]
        public void IsNumericStringTest()
        {
            Assert.IsTrue(numericText.IsNumeric());
            Assert.IsFalse(mixedText.IsNumeric());
        }

        [TestMethod()]
        public void RemoveNonDigitsStringTest()
        {
            Assert.IsTrue(mixedText.RemoveNonDigits() == "123");
        }

        [TestMethod()]
        public void TruncateStringNoSurroundTest()
        {
            Assert.IsTrue(stringText.Truncate(2) == "te...");
        }

        [TestMethod()]
        public void TruncateStringTestSurround()
        {
            Assert.IsTrue(stringText.Truncate(2, "*") == "*te*");
        }

        [TestMethod()]
        public void SurroundStringTest()
        {
            Assert.IsTrue(stringText.Surround("**") == "**text**");
        }
    }
}