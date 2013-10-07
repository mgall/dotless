using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dotless;

namespace DotlessTest.ListLess
{
    [TestClass]
    public class UnitTest_ListLessSlicing
    {
        private static int N = 100;


        #region [ POSITIVE DIRECT SLICING ]

        [TestMethod]
        public void Test_DirectEmptySlicingFirst()
        {
            var x = new ListLess<int>(Enumerable.Range(0, N));

            var sliced = x[0, 0];

            Assert.IsNotNull(sliced);
            Assert.IsTrue(sliced.Count() == 0);
        }

        [TestMethod]
        public void Test_DirectEmptySlicingMiddle()
        {
            var x = new ListLess<int>(Enumerable.Range(0, N));

            var sliced = x[N / 2, N / 2];

            Assert.IsNotNull(sliced);
            Assert.IsTrue(sliced.Count() == 0);
        }

        [TestMethod]
        public void Test_DirectEmptySlicingLast()
        {
            var x = new ListLess<int>(Enumerable.Range(0, N));

            var sliced = x[N, N];

            Assert.IsNotNull(sliced);
            Assert.IsTrue(sliced.Count() == 0);
        }

        [TestMethod]
        public void Test_DirectSingleSlicingFirst()
        {
            var x = new ListLess<int>(Enumerable.Range(0, N));

            var sliced = x[0, 1];

            Assert.IsNotNull(sliced);
            Assert.IsTrue(sliced.Count() == 1);
            Assert.IsTrue(x.First() == sliced.First());
        }

        [TestMethod]
        public void Test_DirectSingleSlicingMiddle()
        {
            var x = new ListLess<int>(Enumerable.Range(0, N));

            var sliced = x[(N / 2), (N / 2) + 1];

            Assert.IsNotNull(sliced);
            Assert.IsTrue(sliced.Count() == 1);
            Assert.IsTrue(x.ElementAt(N / 2) == sliced.First());
        }

        [TestMethod]
        public void Test_DirectSingleSlicingLast()
        {
            var x = new ListLess<int>(Enumerable.Range(0, N));

            var sliced = x[N - 1, N];

            Assert.IsNotNull(sliced);
            Assert.IsTrue(sliced.Count() == 1);
            Assert.IsTrue(x.Last() == sliced.First());
        }

        [TestMethod]
        public void Test_DirectFullSlicing()
        {
            var x = new ListLess<int>(Enumerable.Range(0, N));

            var sliced = x[0, N];

            Assert.IsNotNull(sliced);
            Assert.IsTrue(sliced.Count() == x.Count());
            Assert.IsTrue(x.First() == sliced.First());
            Assert.IsTrue(x.Last() == sliced.Last());
        }

        [TestMethod]
        public void Test_DirectPartialSlicing()
        {
            var x = new ListLess<int>(Enumerable.Range(0, N));

            var sliced = x[N / 2, N];

            Assert.IsNotNull(sliced);
            Assert.IsTrue(sliced.Count() == (N - N/2));
            Assert.IsTrue(x.ElementAt(N / 2) == sliced.First());
            Assert.IsTrue(x.Last() == sliced.Last());
        }

        #endregion

        #region [ POSITIVE REVERSED SLICING ]

        [TestMethod]
        public void Test_ReverseSingleSlicingFirst()
        {
            var x = new ListLess<int>(Enumerable.Range(0, N));

            var sliced = x[1, 0];

            Assert.IsNotNull(sliced);
            Assert.IsTrue(sliced.Count() == 1);
            Assert.IsTrue(x.First() == sliced.First());
        }

        [TestMethod]
        public void Test_ReverseSingleSlicingMiddle()
        {
            var x = new ListLess<int>(Enumerable.Range(0, N));

            var sliced = x[(N/2)+1, (N/2)];

            Assert.IsNotNull(sliced);
            Assert.IsTrue(sliced.Count() == 1);
            Assert.IsTrue(x.ElementAt(N / 2) == sliced.First());
        }

        [TestMethod]
        public void Test_ReverseSingleSlicingLast()
        {
            var x = new ListLess<int>(Enumerable.Range(0, N));

            var sliced = x[N, N-1];

            Assert.IsNotNull(sliced);
            Assert.IsTrue(sliced.Count() == 1);
            Assert.IsTrue(x.Last() == sliced.First());
        }

        [TestMethod]
        public void Test_ReverseFullSlicing()
        {
            var x = new ListLess<int>(Enumerable.Range(0, N));

            var sliced = x[N, 0];

            Assert.IsNotNull(sliced);
            Assert.IsTrue(sliced.Count() == x.Count());
            Assert.IsTrue(x.First() == sliced.Last());
            Assert.IsTrue(x.Last() == sliced.First());
        }

        [TestMethod]
        public void Test_ReversePartialSlicing()
        {
            var x = new ListLess<int>(Enumerable.Range(0, N));

            var sliced = x[N, N/2];

            Assert.IsNotNull(sliced);
            Assert.IsTrue(sliced.Count() == (N- N/2));

            Assert.IsTrue(x.ElementAt(N / 2) == sliced.Last());
            Assert.IsTrue(x.Last() == sliced.First());
        }

        #endregion

        #region [ NEGATIVE DIRECT SLICING ]

        [TestMethod]
        public void Test_NegDirectEmptySlicingFirst()
        {
            var x = new ListLess<int>(Enumerable.Range(0, N));

            var sliced = x[-N, -N];

            Assert.IsNotNull(sliced);
            Assert.IsTrue(sliced.Count() == 0);
        }

        [TestMethod]
        public void Test_NegDirectEmptySlicingMiddle()
        {
            var x = new ListLess<int>(Enumerable.Range(0, N));

            var sliced = x[-N/2, -N/2];

            Assert.IsNotNull(sliced);
            Assert.IsTrue(sliced.Count() == 0);
        }

        [TestMethod]
        public void Test_NegDirectEmptySlicingLast()
        {
            var x = new ListLess<int>(Enumerable.Range(0, N));

            var sliced = x[-1, -1];

            Assert.IsNotNull(sliced);
            Assert.IsTrue(sliced.Count() == 0);
        }

        [TestMethod]
        public void Test_NegDirectSingleSlicingFirst()
        {
            var x = new ListLess<int>(Enumerable.Range(0, N));

            var sliced = x[-(N+1), -N];

            Assert.IsNotNull(sliced);
            Assert.IsTrue(sliced.Count() == 1);
            Assert.IsTrue(x.First() == sliced.First());
        }

        [TestMethod]
        public void Test_NegDirectSingleSlicingMiddle()
        {
            var x = new ListLess<int>(Enumerable.Range(0, N));

            var sliced = x[-(N/2+1), -(N/2)];

            Assert.IsNotNull(sliced);
            Assert.IsTrue(sliced.Count() == 1);
            Assert.IsTrue(x.ElementAt(N / 2) == sliced.First());
        }

        [TestMethod]
        public void Test_NegDirectSingleSlicingLast()
        {
            var x = new ListLess<int>(Enumerable.Range(0, N));

            var sliced = x[-2, -1];

            Assert.IsNotNull(sliced);
            Assert.IsTrue(sliced.Count() == 1);
            Assert.IsTrue(x.Last() == sliced.First());
        }

        [TestMethod]
        public void Test_NegDirectFullSlicing()
        {
            var x = new ListLess<int>(Enumerable.Range(0, N));

            var sliced = x[0, -1];

            Assert.IsNotNull(sliced);
            Assert.IsTrue(sliced.Count() == x.Count());
            Assert.IsTrue(x.First() == sliced.First());
            Assert.IsTrue(x.Last() == sliced.Last());
        }

        [TestMethod]
        public void Test_NegDirectPartialSlicing()
        {
            var x = new ListLess<int>(Enumerable.Range(0, N));

            var sliced = x[-(N/2+1), -1];

            Assert.IsNotNull(sliced);
            Assert.IsTrue(sliced.Count() == (N - N / 2));
            Assert.IsTrue(x.ElementAt(N/2) == sliced.First());
            Assert.IsTrue(x.Last() == sliced.Last());
        }

        #endregion

    }
}
