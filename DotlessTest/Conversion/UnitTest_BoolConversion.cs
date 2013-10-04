using System;
using Dotless;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotlessTest.Dummies;

namespace DotlessTest.Conversion
{
    [TestClass]
    public class UnitTest_BoolConversion
    {

        #region [ FROM STRING ]

        [TestMethod]
        public void Test_ConvertBool_FromString_Wrong()
        {
            var casted = "Wrong".To<Boolean>();
            Assert.IsInstanceOfType(casted, typeof(Boolean?));
            Assert.IsNull(casted);
        }

        [TestMethod]
        public void Test_ConvertBool_FromString_NumericOne()
        {
            var casted = "1";
            Assert.IsInstanceOfType(casted, typeof(Boolean?));
            Assert.Equals(casted, true);
        }

        [TestMethod]
        public void Test_ConvertBool_FromString_NumericZero()
        {
            var casted = "0";
            Assert.IsInstanceOfType(casted, typeof(Boolean?));
            Assert.Equals(casted, false);
        }

        [TestMethod]
        public void Test_ConvertBool_FromString_NumericNotZero()
        {
            var casted = "100".To<Boolean>();
            Assert.IsInstanceOfType(casted, typeof(Boolean?));
            Assert.Equals(casted, true);
        }

        [TestMethod]
        public void Test_ConvertBool_FromString_TrueLower()
        {
            var casted = "true".To<Boolean>();
            Assert.IsInstanceOfType(casted, typeof(Boolean?));
            Assert.Equals(casted, true);
        }

        [TestMethod]
        public void Test_ConvertBool_FromString_FalseLower()
        {
            var casted = "false".To<Boolean>();
            Assert.IsInstanceOfType(casted, typeof(Boolean?));
            Assert.Equals(casted, false);
        }

        [TestMethod]
        public void Test_ConvertBool_FromString_TrueExact()
        {
            var casted = "True".To<Boolean>();
            Assert.IsInstanceOfType(casted, typeof(Boolean?));
            Assert.Equals(casted, true);
        }

        [TestMethod]
        public void Test_ConvertBool_FromString_FalseExact()
        {
            var casted = "False".To<Boolean>();
            Assert.IsInstanceOfType(casted, typeof(Boolean?));
            Assert.Equals(casted, false);
        } 

        #endregion

        #region [ FROM NUMBER ]

        [TestMethod]
        public void Test_ConvertBool_FromIntOne()
        {
            var casted = 1.To<Boolean>();
            Assert.IsInstanceOfType(casted, typeof(Boolean?));
            Assert.Equals(casted, true);
        }

        [TestMethod]
        public void Test_ConvertBool_FloatOne()
        {
            var casted = ((float)1.0).To<Boolean>();
            Assert.IsInstanceOfType(casted, typeof(Boolean?));
            Assert.Equals(casted, true);
        }

        [TestMethod]
        public void Test_ConvertBool_DoubleOne()
        {
            var casted = ((double)1.0).To<Boolean>();
            Assert.IsInstanceOfType(casted, typeof(Boolean?));
            Assert.Equals(casted, true);
        }

        [TestMethod]
        public void Test_ConvertBool_DecimalOne()
        {
            var casted = ((decimal)1.0).To<Boolean>();
            Assert.IsInstanceOfType(casted, typeof(Boolean?));
            Assert.Equals(casted, true);
        }

        [TestMethod]
        public void Test_ConvertBool_FromIntZero()
        {
            var casted = 0.To<Boolean>();
            Assert.IsInstanceOfType(casted, typeof(Boolean?));
            Assert.Equals(casted, false);
            
        }

        [TestMethod]
        public void Test_ConvertBool_FromFloatZero()
        {
            var casted = ((float)0).To<Boolean>();
            Assert.IsInstanceOfType(casted, typeof(Boolean?));
            Assert.Equals(casted, false);
            
        }

        [TestMethod]
        public void Test_ConvertBool_FromDoubleZero()
        {
            var casted = ((double)0).To<Boolean>();
            Assert.IsInstanceOfType(casted, typeof(Boolean?));
            Assert.Equals(casted, false);
        }

        [TestMethod]
        public void Test_ConvertBool_FromDecimalZero()
        {
            var casted = ((decimal)0).To<Boolean>();
            Assert.IsInstanceOfType(casted, typeof(Boolean?));
            Assert.Equals(casted, false);
            
        }

        [TestMethod]
        public void Test_ConvertBool_FromIntNonZero()
        {
            var casted = 100.To<Boolean>();
            Assert.IsInstanceOfType(casted, typeof(Boolean?));
            Assert.Equals(casted, false);
            
        }

        [TestMethod]
        public void Test_ConvertBool_FromFlaotNonZero()
        {
            var casted = ((float)1.7).To<Boolean>();
            Assert.IsInstanceOfType(casted, typeof(Boolean?));
            Assert.Equals(casted, true);
        }

        [TestMethod]
        public void Test_ConvertBool_FromDoubleNonZero()
        {
            var casted = ((double)1.7).To<Boolean>();
            Assert.IsInstanceOfType(casted, typeof(Boolean?));
            Assert.Equals(casted, true);
        }

        [TestMethod]
        public void Test_ConvertBool_FromDecimalNonZero()
        {
            var casted = ((decimal)1.7).To<Boolean>();
            Assert.IsInstanceOfType(casted, typeof(Boolean?));
            Assert.Equals(casted, true);
        }

        [TestMethod]
        public void Test_ConvertBool_FromNumericNegative()
        {
            var casted = (-1).To<Boolean>();
            Assert.IsInstanceOfType(casted, typeof(Boolean?));
            Assert.Equals(casted, true);
            
        }

        #endregion

        #region [ FROM OTHER ]

        [TestMethod]
        public void Test_ConvertBool_FromNull()
        {
            var casted = ((object)null).To<Boolean>();
            Assert.IsInstanceOfType(casted, typeof(Boolean?));
            Assert.IsNull(casted);
        }

        [TestMethod]
        public void Test_ConvertBool_FromTrue()
        {
            var casted = true.To<Boolean>();
            Assert.IsInstanceOfType(casted, typeof(Boolean?));
            Assert.Equals(casted, true);
        }

        [TestMethod]
        public void Test_ConvertBool_FromFalse()
        {
            var casted = false.To<Boolean>();
            Assert.IsInstanceOfType(casted, typeof(Boolean?));
            Assert.Equals(casted, false);
        }

        [TestMethod]
        public void Test_ConvertBool_FromEnum_Zero()
        {
            var casted = (DummyEnum.value0).To<Boolean>();
            Assert.IsInstanceOfType(casted, typeof(Boolean?));
            Assert.Equals(casted, false);
        }

        [TestMethod]
        public void Test_ConvertBool_FromEnum_One()
        {
            var casted = (DummyEnum.value1).To<Boolean>();
            Assert.IsInstanceOfType(casted, typeof(Boolean?));
            Assert.Equals(casted, true);
        }

        [TestMethod]
        public void Test_ConvertBool_FromEnum_NonZero()
        {
            var casted = (DummyEnum.value7).To<Boolean>();
            Assert.IsInstanceOfType(casted, typeof(Boolean?));
            Assert.Equals(casted, true);
        }

        #endregion

    }
}
