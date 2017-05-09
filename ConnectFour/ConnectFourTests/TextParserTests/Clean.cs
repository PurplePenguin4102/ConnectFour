using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConnectFour;
using System;
using System.Linq;
using ConnectFour.Exceptions;

namespace ConnectFourTests.TextParserTests
{
    [TestClass]
    public class Clean
    {
        [TestMethod]
        public void ExtraSpaceAndCapitals()
        {
            var inp = "  helLo  ";
            var tp = new TextParser();
            Assert.AreEqual("hello", tp.Clean(inp));
        }
    }
}
