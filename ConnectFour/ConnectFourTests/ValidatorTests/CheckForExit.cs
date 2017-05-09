using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConnectFour;

namespace ConnectFourTests.ValidatorTests
{
    [TestClass]
    public class CheckForExit
    {
        /* out of scope : capital letters and whitespace */

        [TestMethod]
        public void UserSentExit()
        {
            var rules = new Validator();
            Assert.IsTrue(rules.CheckForExit("exit"));
        }

        [TestMethod]
        public void UserSentQuit()
        {
            var rules = new Validator();
            Assert.IsTrue(rules.CheckForExit("quit"));
        }

        [TestMethod]
        public void UserSentOtherInput()
        {
            var rules = new Validator();
            Assert.IsFalse(rules.CheckForExit("adsjoadgi"));
        }

        [TestMethod]
        public void UserSentOtherInput2()
        {
            var rules = new Validator();
            Assert.IsFalse(rules.CheckForExit("5 5"));
        }
    }
}
