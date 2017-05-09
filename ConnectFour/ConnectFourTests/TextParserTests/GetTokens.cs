using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConnectFour;
using System;
using System.Linq;
using ConnectFour.Exceptions;

namespace ConnectFourTests.TextParserTests
{
    [TestClass]
    public class GetTokens
    {
        /* out of scope : leading and trailing white spaces, capital letters */

        [TestMethod]
        public void GetSpaceSeparatedNumbers()
        {
            TextParser tp = new TextParser();
            var inp = "4 5 5 6 7";
            Assert.IsTrue(tp.GetTokens(inp).SequenceEqual(new string[] { "4", "5", "5", "6", "7"}));
        }

        [TestMethod]
        public void GetSpaceSeparatedGibberish()
        {
            TextParser tp = new TextParser();
            var inp = "asdf fs f 6 7";
            Assert.IsTrue(tp.GetTokens(inp).SequenceEqual(new string[] { "asdf", "fs", "f", "6", "7" }));
        }

        [TestMethod]
        public void GetTabSeparatedGibberish()
        {
            TextParser tp = new TextParser();
            var inp = "asdf\tfs f 6 7";
            Assert.IsTrue(tp.GetTokens(inp).SequenceEqual(new string[] { "asdf", "fs", "f", "6", "7" }));
        }

        [TestMethod]
        public void GetTabSeparatedNumbers()
        {
            TextParser tp = new TextParser();
            var inp = "4\t5\t5\t6\t7";
            Assert.IsTrue(tp.GetTokens(inp).SequenceEqual(new string[] { "4", "5", "5", "6", "7" }));
        }

        [TestMethod]
        public void GetSpaceAndTabSeparatedNumbers()
        {
            TextParser tp = new TextParser();
            var inp = "4 \t5\t 5\t 6 \t7";
            Assert.IsTrue(tp.GetTokens(inp).SequenceEqual(new string[] { "4", "5", "5", "6", "7" }));
        }

        [TestMethod]
        public void GetMultiSpaceSeparatedNumbers()
        {
            TextParser tp = new TextParser();
            var inp = "4  5  5  6  7";
            Assert.IsTrue(tp.GetTokens(inp).SequenceEqual(new string[] { "4", "5", "5", "6", "7" }));
        }
    }
}
