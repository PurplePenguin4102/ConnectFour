using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConnectFour;
using System;
using System.Linq;
using ConnectFour.Exceptions;

namespace ConnectFourTests.ValidatorTests
{
    [TestClass]
    public class ParseTokens
    {
        [TestMethod]
        public void TokensAreIntegers()
        {
            string[] tokens = new string[] { "1", "2", "3" };
            int[] output = new int[] { 1, 2, 3};
            var rules = new Validator();
            Assert.IsTrue(rules.ParseTokens(tokens).SequenceEqual(output));
        }

        [TestMethod]
        public void TokensAreNotIntegers()
        {
            string[] tokens = new string[] { "qasd", "2", "3" };
            var rules = new Validator();
            Assert.ThrowsException<UserInputException>(() => rules.ParseTokens(tokens));
        }

        [TestMethod]
        public void TokensAreNegativeIntegers()
        {
            string[] tokens = new string[] { "-1", "2", "3" };
            int[] output = new int[] { -1, 2, 3 };
            var rules = new Validator();
            Assert.IsTrue(rules.ParseTokens(tokens).SequenceEqual(output));
        }

        [TestMethod]
        public void TokensAreFloats()
        {
            string[] tokens = new string[] { "1", "2.2", "3" };
            var rules = new Validator();
            Assert.ThrowsException<UserInputException>(() => rules.ParseTokens(tokens));
        }

        [TestMethod]
        public void TokensContainZero()
        {
            string[] tokens = new string[] { "0", "2", "3" };
            int[] output = new int[] { 0, 2, 3 };
            var rules = new Validator();
            Assert.IsTrue(rules.ParseTokens(tokens).SequenceEqual(output));
        }

        [TestMethod]
        public void TokensContainwhitespace()
        {
            string[] tokens = new string[] { "1  ", "  2", "\t3" };
            int[] output = new int[] { 1, 2, 3 };
            var rules = new Validator();
            Assert.IsTrue(rules.ParseTokens(tokens).SequenceEqual(output));
        }
    }
}
