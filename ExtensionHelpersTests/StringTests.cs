using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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

        [TestMethod()]
        public void CaseInsensitiveReplaceTest_Recursive()
        {
            string replaceText = "banana";

            Assert.IsTrue(replaceText.Replace("AN", "banana", StringComparison.InvariantCultureIgnoreCase) == "bbananabananaa");
        }

        [TestMethod()]
        public void CaseInsensitiveReplaceTest_NotRecursive()
        {
            string replaceText = "banana";

            Assert.IsTrue(replaceText.Replace("AN", "banana", StringComparison.InvariantCultureIgnoreCase, false) == "bbananaana");
        }

        [TestMethod]
        public void CaseInsensitiveReplaceTest_ReplaceIsNull_OldNotEmpty_Recursive()
        {
            string replaceText = null;

            Assert.IsTrue(replaceText.Replace("AN", "banana", StringComparison.InvariantCultureIgnoreCase) == null);
        }

        [TestMethod]
        public void CaseInsensitiveReplaceTest_ReplaceIsNull_OldNotEmpty_NotRecursive()
        {
            string replaceText = null;

            Assert.IsTrue(replaceText.Replace("AN", "banana", StringComparison.InvariantCultureIgnoreCase, false) == null);
        }

        [TestMethod]
        public void CaseInsensitiveReplaceTest_ReplaceIsNull_OldEmpty_Recursive()
        {
            string replaceText = null;

            Assert.IsTrue(replaceText.Replace(string.Empty, "banana", StringComparison.InvariantCultureIgnoreCase) == "banana");
        }

        [TestMethod]
        public void CaseInsensitiveReplaceTest_ReplaceIsNull_OldEmpty_NotRecursive()
        {
            string replaceText = null;

            Assert.IsTrue(replaceText.Replace(string.Empty, "banana", StringComparison.InvariantCultureIgnoreCase, false) == "banana");
        }

        [TestMethod]
        public void CaseInsensitiveReplaceTest_OldIsNull_Recursive()
        {
            string replaceText = "banana";

            Assert.IsTrue(replaceText.Replace(null, "AN", StringComparison.InvariantCultureIgnoreCase) == "banana");
        }

        [TestMethod]
        public void CaseInsensitiveReplaceTest_OldIsNull_NotRecursive()
        {
            string replaceText = "banana";

            Assert.IsTrue(replaceText.Replace(null, "AN", StringComparison.InvariantCultureIgnoreCase, false) == "banana");
        }

        [TestMethod]
        public void CaseInsensitiveReplaceTest_NewIsNull_Recursive()
        {
            string replaceText = "banana";

            Assert.IsTrue(replaceText.Replace("AN", null, StringComparison.InvariantCultureIgnoreCase) == "ba");
        }

        [TestMethod]
        public void CaseInsensitiveReplaceTest_NewIsNull_NotRecursive()
        {
            string replaceText = "banana";

            Assert.IsTrue(replaceText.Replace("AN", null, StringComparison.InvariantCultureIgnoreCase, false) == "bana");
        }
    }
}