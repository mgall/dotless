using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dotless;

namespace DotlessTest.ListLess
{
    [TestClass]
    public class UnitTest_ListLessIndexing
    {
        private static int N = 100;

        [TestMethod]
        public void AccessFirst()
        {
            var source = Enumerable.Range(0, N);
            var x = new ListLess<int>(source);

            Assert.IsTrue(x[0] == source.First());
        }

        [TestMethod]
        public void AccessMiddle()
        {
            var source = Enumerable.Range(0, N);
            var x = new ListLess<int>(source);

            Assert.IsTrue(x[N/2] == source.ElementAt(N/2));
        }

        [TestMethod]
        public void AccessNegMiddle()
        {
            var source = Enumerable.Range(0, N);
            var x = new ListLess<int>(source);

            Assert.IsTrue(x[-N/2] == source.ElementAt(N-(N/2)));
        }

        [TestMethod]
        public void AccessLast()
        {
            var source = Enumerable.Range(0, N);
            var x = new ListLess<int>(source);

            Assert.IsTrue(x[-1] == source.Last());
        }

        [TestMethod]
        public void AccessOverflow()
        {
            var source = Enumerable.Range(0, N);
            var x = new ListLess<int>(source);

            Assert.IsTrue(x[N-1] != default(int));
            Assert.IsTrue(x[N  ] == default(int));
            Assert.IsTrue(x[N+1] == default(int));
        }

        [TestMethod]
        public void AccessUnderflow()
        {
            var source = Enumerable.Range(-1, N);
            var x = new ListLess<int>(source);

            Assert.IsTrue(x[-N] == -1);
            Assert.IsTrue(x[-N -1] == default(int));
            Assert.IsTrue(x[-N -2] == default(int));
        }

    }
}
