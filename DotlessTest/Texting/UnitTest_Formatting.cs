using System;
using Dotless.Texting;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotlessTest.Texting
{
    [TestClass]
    public class UnitTest_Formatting
    {
        [TestMethod]
        public void Test_FormatClassic()
        {
            var formatted = "Foo {0}".ff("Bar");
            Assert.IsTrue( formatted == "Foo Bar" );
        }

        #region [ FORMAT CASE ]
        
        [TestMethod]
        public void Test_FormatCase_Lower()
        {
            var formatted = "TEST {0:L}".fCase("FOO BAR");

            Assert.IsTrue(formatted == "TEST foo bar");
        }

        [TestMethod]
        public void Test_FormatCase_Upper()
        {
            var formatted = "test {0:U}".fCase("Foo Bar");

            Assert.IsTrue(formatted == "test FOO BAR");
        }

        [TestMethod]
        public void Test_FormatCase_Capital_FromLower()
        {
            var formatted = "Test {0:C}".fCase("foo bar");

            Assert.IsTrue(formatted == "Test Foo Bar");
        }

        [TestMethod]
        public void Test_FormatCase_Capital_FromUpper()
        {
            var formatted = "Test {0:C}".fCase("FOO BAR");

            Assert.IsTrue(formatted == "Test Foo Bar");
        } 

        #endregion

    }
}
