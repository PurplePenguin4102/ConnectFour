using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConnectFour;

namespace ConnectFourTests.ValidatorTests
{
    [TestClass]
    public class ValidateMove
    {
        [TestMethod]
        public void ValidMove()
        {
            var rules = new Validator();
            Assert.IsTrue(rules.ValidateMove(new int[] { 1 }));
        }

        [TestMethod]
        public void InvalidMove_TooMany()
        {
            var rules = new Validator();
            Assert.IsFalse(rules.ValidateMove(new int[2] { 1, 2 }));
        }

        [TestMethod]
        public void InvalidMove_Negative()
        {
            var rules = new Validator();
            Assert.IsFalse(rules.ValidateMove(new int[1] { -1 }));
        }

        [TestMethod]
        public void InvalidMove_Zero()
        {
            var rules = new Validator();
            Assert.IsFalse(rules.ValidateMove(new int[1] { 0 }));
        }
    }
}
