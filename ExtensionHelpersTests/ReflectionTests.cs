using ExtensionHelpers;
using ExtensionHelpers.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ExtensionHelpersTests
{
    [TestClass]
    public class ReflectionTests
    {
        [TestMethod]
        public void ReflectiveCompare_Same()
        {
            Assert.IsFalse(complex1.ReflectiveCompare(complex2).Any());
        }

        [TestMethod]
        public void ReflectiveCompare_Same_SkippedAttributeDifferent()
        {
            Assert.IsFalse(complex1.ReflectiveCompare(complex2).Any());
        }

        [TestMethod]
        public void ReflectiveCompare_Different()
        {
            Assert.IsTrue(complex1.ReflectiveCompare(complex3).Any());
        }

        [TestMethod]
        public void ReflectiveCompare_List_Different()
        {
            Assert.IsTrue(listA.ReflectiveCompare(listB).Any());
        }

        private Complex complex1 = new Complex
        {
            X = 12,
            Y = 5,
            ZList = new List<int>
            {
                { 10 },
                { 20 }
            }
        };

        private Complex complexA = new Complex
        {
            X = 12,
            Y = 5,
            ZList = new List<int>
            {
                { 10 },
                { 20 }
            }
        };

        private Complex complex2 = new Complex
        {
            X = 12,
            Y = 8,
            ZList = new List<int>
            {
                { 10 },
                { 20 }
            }
        };

        private Complex complex3 = new Complex
        {
            X = 5,
            Y = 12,
            ZList = new List<int>
            {
                { 8 },
                { 10 }
            }
        };

        private List<string> listA = new List<string>
        {
            { "one" },
            { "two" }
        };

        private List<string> listB = new List<string>
        {
            { "one" },
            { "two" },
            { "three" }
        };
    }

    public class Complex
    {
        public int X { get; set; }

        [SkipReflectiveCompare]
        public int Y { get; set; }
        public List<int> ZList { get; set; }
    }
}