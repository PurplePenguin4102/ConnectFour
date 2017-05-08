using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConnectFour;
using System.Collections.Generic;

namespace ConnectFourTests.LineCheckTests
{
    [TestClass]
    public class HasFourInARow
    {
        [TestMethod]
        public void ContainsFourY()
        {
            LineCheck line = new LineCheck();
            line.Token = "y";
            var data = new List<string> { "o", "o", "y", "y", "y", "y", "o" };

            Assert.IsTrue(line.HasFourInARow(data));
        }

        [TestMethod]
        public void ContainsFourR()
        {
            LineCheck line = new LineCheck();
            line.Token = "r";
            var data = new List<string> { "o", "o", "r", "r", "r", "r", "o" };

            Assert.IsTrue(line.HasFourInARow(data));
        }

        [TestMethod]
        public void ContainsThreeY()
        {
            LineCheck line = new LineCheck();
            line.Token = "y";
            var data = new List<string> { "o", "o", "o", "y", "y", "y", "o" };

            Assert.IsFalse(line.HasFourInARow(data));
        }

        [TestMethod]
        public void ContainsThreeR()
        {
            LineCheck line = new LineCheck();
            line.Token = "r";
            var data = new List<string> { "o", "o", "o", "r", "r", "r", "o" };

            Assert.IsFalse(line.HasFourInARow(data));
        }

        [TestMethod]
        public void ContainsDefault()
        {
            LineCheck line = new LineCheck();
            line.Token = "y";
            var data = new List<string> { "o", "o", "o", "o", "o", "o", "o" };

            Assert.ThrowsException<ArgumentException>(() => line.HasFourInARow(data));
        }

        [TestMethod]
        public void WrongPlayerWins()
        {
            LineCheck line = new LineCheck();
            line.Token = "y";
            var data = new List<string> { "r", "r", "r", "r", "o", "o", "o" };

            Assert.ThrowsException<ArgumentException>(() => line.HasFourInARow(data));
        }

        [TestMethod]
        public void TooManyTokens()
        {
            LineCheck line = new LineCheck();
            line.Token = "y";
            var data = new List<string> { "o", "o", "y", "y", "y", "y", "o", "o", "o" };

            Assert.ThrowsException<ArgumentException>(() => line.HasFourInARow(data));
        }

        [TestMethod]
        public void FourAtStart()
        {
            LineCheck line = new LineCheck();
            line.Token = "r";
            var data = new List<string> { "r", "r", "r", "r", "y", "y", "o" };

            Assert.IsTrue(line.HasFourInARow(data));
        }

        [TestMethod]
        public void FourInMiddle()
        {
            LineCheck line = new LineCheck();
            line.Token = "y";
            var data = new List<string> { "o", "o", "y", "y", "y", "y", "o" };

            Assert.IsTrue(line.HasFourInARow(data));
        }

        [TestMethod]
        public void FourAtEnd()
        {
            LineCheck line = new LineCheck();
            line.Token = "r";
            var data = new List<string> { "o", "o", "y", "r", "r", "r", "r" };

            Assert.IsTrue(line.HasFourInARow(data));
        }

        [TestMethod]
        public void YRAlternating()
        {
            LineCheck line = new LineCheck();
            line.Token = "y";
            var data = new List<string> { "y", "r", "y", "r", "y", "r", "y" };

            Assert.IsFalse(line.HasFourInARow(data));
        }

        [TestMethod]
        public void OnlyFourTokensNoWin()
        {
            LineCheck line = new LineCheck();
            line.Token = "y";
            var data = new List<string> { "y", "r", "y", "r" };

            Assert.IsFalse(line.HasFourInARow(data));
        }

        [TestMethod]
        public void OnlyFourTokensWin()
        {
            LineCheck line = new LineCheck();
            line.Token = "y";
            var data = new List<string> { "y", "y", "y", "y" };

            Assert.IsTrue(line.HasFourInARow(data));
        }

        [TestMethod]
        public void Bug1Configuration()
        {
            LineCheck line = new LineCheck();
            line.Token = "y";

            // setup according to debugger was
            var data = new List<string> { "o", "y", "y", "y", "y" };

            // expected value
            Assert.IsTrue(line.HasFourInARow(data));
        }
    }
}
