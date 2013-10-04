using System;
using Dotless;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotlessTest.Dummies;

namespace DotlessTest.Conversion
{
    [TestClass]
    public class UnitTest_EnumConversion
    {

        #region [ FROM STRING ]

        [TestMethod]
        public void Test_ConvetEnum_FromString_Wrong()
        {
            var casted = "Wrong".To<DummyEnum>();
            Assert.IsInstanceOfType(casted, typeof(DummyEnum?));
            Assert.IsNull(casted);
        }

        [TestMethod]
        public void Test_ConvetEnum_FromString_NumericDef()
        {
            var casted = "1";
            Assert.IsInstanceOfType(casted, typeof(DummyEnum?));
            Assert.Equals(casted, DummyEnum.value1);
        }

        [TestMethod]
        public void Test_ConvetEnum_FromString_NumericUndef()
        {
            var casted = "100".To<DummyEnum>();
            Assert.IsInstanceOfType(casted, typeof(DummyEnum?));
            Assert.Equals(casted, (DummyEnum)100);
        }

        [TestMethod]
        public void Test_ConvetEnum_FromString_DescriptionLower()
        {
            var casted = "value1".To<DummyEnum>();
            Assert.IsInstanceOfType(casted, typeof(DummyEnum?));
            Assert.Equals(casted, DummyEnum.value1);
        }

        [TestMethod]
        public void Test_ConvetEnum_FromString_DescriptionExact()
        {
            var casted = "value1".To<DummyEnum>();
            Assert.IsInstanceOfType(casted, typeof(DummyEnum?));
            Assert.Equals(casted, DummyEnum.value1);
        }

        [TestMethod]
        public void Test_ConvetEnum_FromString_BooleanTrueLower()
        {
            var casted = "true".To<DummyEnum>();
            Assert.IsInstanceOfType(casted, typeof(DummyEnum?));
            Assert.Equals(casted, DummyEnum.value1);
        }

        [TestMethod]
        public void Test_ConvetEnum_FromString_BooleanFalseLower()
        {
            var casted = "false".To<DummyEnum>();
            Assert.IsInstanceOfType(casted, typeof(DummyEnum?));
            Assert.Equals(casted, DummyEnum.value1);
        }

        [TestMethod]
        public void Test_ConvetEnum_FromString_BooleanTrueExact()
        {
            var casted = "True".To<DummyEnum>();
            Assert.IsInstanceOfType(casted, typeof(DummyEnum?));
            Assert.Equals(casted, DummyEnum.value1);
        }

        [TestMethod]
        public void Test_ConvetEnum_FromString_BooleanFalseExact()
        {
            var casted = "False".To<DummyEnum>();
            Assert.IsInstanceOfType(casted, typeof(DummyEnum?));
            Assert.Equals(casted, DummyEnum.value1);
        } 

        #endregion

        #region [ FROM OTHER ]

        [TestMethod]
        public void Test_ConvetEnum_FromNull()
        {
            var casted = ((object)null).To<DummyEnum>();
            Assert.IsInstanceOfType(casted, typeof(DummyEnum?));
            Assert.IsNull(casted);
        }

        [TestMethod]
        public void Test_ConvetEnum_FromSameEnum()
        {
            var casted = (DummyEnum.value3).To<DummyEnum>();
            Assert.IsInstanceOfType(casted, typeof(DummyEnum?));
            Assert.Equals(casted, DummyEnum.value3);
        }

        [TestMethod]
        public void Test_ConvetEnum_FromNumericDef()
        {
            var casted = 1.To<DummyEnum>();
            Assert.IsInstanceOfType(casted, typeof(DummyEnum?));
            Assert.Equals(casted, DummyEnum.value1);
            
        }

        [TestMethod]
        public void Test_ConvetEnum_FromNumericUndef()
        {
            var casted = 100.To<DummyEnum>();
            Assert.IsInstanceOfType(casted, typeof(DummyEnum?));
            Assert.Equals(casted, (DummyEnum)100);
        }

        [TestMethod]
        public void Test_ConvetEnum_FromTrue()
        {
            var casted = true.To<DummyEnum>();
            Assert.Equals(casted, DummyEnum.value1);
            Assert.IsInstanceOfType(casted, typeof(DummyEnum?));
        }

        [TestMethod]
        public void Test_ConvetEnum_FromFalse()
        {
            var casted = false.To<DummyEnum>();
            Assert.Equals(casted, DummyEnum.value0);
            Assert.IsInstanceOfType(casted, typeof(DummyEnum?));
        }

        #endregion

    }
}
