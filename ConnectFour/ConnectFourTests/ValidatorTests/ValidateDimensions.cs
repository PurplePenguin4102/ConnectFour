using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConnectFour;

namespace ConnectFourTests.ValidatorTests
{
    [TestClass]
    public class ValidateDimensions
    {
        [TestMethod]
        public void ValidDimensions()
        {
            var rules = new Validator();
            Assert.IsTrue(rules.ValidateDimensions(new int[] { 5, 5 }));
        }

        [TestMethod]
        public void ValidDimensions_big()
        {
            var rules = new Validator();
            Assert.IsTrue(rules.ValidateDimensions(new int[] { 500, 500 }));
        }

        [TestMethod]
        public void InvalidDimensions_TooMany()
        {
            var rules = new Validator();
            Assert.IsFalse(rules.ValidateDimensions(new int[] { 5, 5, 5 }));
        }

        [TestMethod]
        public void InvalidDimensions_NotEnough()
        {
            var rules = new Validator();
            Assert.IsFalse(rules.ValidateDimensions(new int[] { 5 }));
        }

        [TestMethod]
        public void InvalidDimensions_Negative()
        {
            var rules = new Validator();
            Assert.IsFalse(rules.ValidateDimensions(new int[] { -5, 5 }));
        }

        [TestMethod]
        public void InvalidDimensions_Zero()
        {
            var rules = new Validator();
            Assert.IsFalse(rules.ValidateDimensions(new int[] { 5, 0 }));
        }

        [TestMethod]
        public void InvalidDimensions_BoardTooSmall()
        {
            var rules = new Validator();
            Assert.IsFalse(rules.ValidateDimensions(new int[] { 4, 1 }));
        }

        [TestMethod]
        public void InvalidDimensions_BoardTooSmall2()
        {
            var rules = new Validator();
            Assert.IsFalse(rules.ValidateDimensions(new int[] { 3, 3 }));
        }
    }
}
