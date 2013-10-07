using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dotless;

namespace DotlessTest.ListLess
{
    /// <summary>
    /// Summary description for UnitTest_ListLessFactory
    /// </summary>
    [TestClass]
    public class UnitTest_ListLessFactory
    {
        [TestMethod]
        public void CreateValueList()
        {
            var fib = R.List(1, 1, 2, 3, 5, 8, 13);

            Assert.IsTrue(fib.Count() == 7);
            Assert.IsTrue(fib.First() == 1);
            Assert.IsTrue(fib.Last() == 13);
        }

        [TestMethod]
        public void CreateRefList()
        {
            var fib = R.List( "apple", "orange", "peach", "pear", "banana");

            Assert.IsTrue(fib.Count() == 5);
            Assert.IsTrue(fib.First() == "apple");
            Assert.IsTrue(fib.Last() == "banana");
        }

       
        [TestMethod]
        public void CreateRange()
        {
            var r = R.Range(100);

            Assert.IsTrue(r.Count() == 100);
            Assert.IsTrue(r.First() == 0);
            Assert.IsTrue(r.Last() == 99);
        }

        [TestMethod]
        public void CreateSpecificRange()
        {
            var r = R.Range(10, 100);

            Assert.IsTrue(r.Count() == 90);
            Assert.IsTrue(r.First() == 10);
            Assert.IsTrue(r.Last() == 99);
        }

        [TestMethod]
        public void CreateSpecificReverseRange()
        {
            var r = R.Range(100,0);

            Assert.IsTrue(r.Count() == 100);
            Assert.IsTrue(r.First() == 99);
            Assert.IsTrue(r.Last() == 0);
        }

        [TestMethod]
        public void CreateSpecificRangeWithStep()
        {
            var r = R.Range(0, 100, +2);

            Assert.IsTrue(r.Count() == 50);
            Assert.IsTrue(r.First() == 0);
            Assert.IsTrue(r.Last() == 98);
        }

        [TestMethod]
        public void CreateSpecificReverseRangeWithStep()
        {
            var r = R.Range(100, 0, -2);

            Assert.IsTrue(r.Count() == 50);
            Assert.IsTrue(r.First() == 98);
            Assert.IsTrue(r.Last() == 0);
        }

    }
}

