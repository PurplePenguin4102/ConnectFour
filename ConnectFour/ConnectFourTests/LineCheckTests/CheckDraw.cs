using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConnectFour;
using System.Collections.Generic;
using System.Linq;

namespace ConnectFourTests.LineCheckTests
{
    [TestClass]
    public class CheckDraw
    {
        /* out of scope : win condition on board is out of scope */
        [TestMethod]
        public void EmptyBoard()
        {
            var line = new LineCheck()
            {
                Rows = 5,
                Cols = 5,
                Token = "x"
            };

            var data = new List<List<string>>
            {
                new List<string> { "o", "o", "o", "o", "o" },
                new List<string> { "o", "o", "o", "o", "o" },
                new List<string> { "o", "o", "o", "o", "o" },
                new List<string> { "o", "o", "o", "o", "o" },
                new List<string> { "o", "o", "o", "o", "o" }
            };

            line.Columns = data;

            Assert.IsFalse(line.CheckDraw());
        }

        [TestMethod]
        public void FullBoardY()
        {
            var line = new LineCheck()
            {
                Rows = 5,
                Cols = 5,
                Token = "x"
            };

            var data = new List<List<string>>
            {
                new List<string> { "y", "y", "y", "y", "y" },
                new List<string> { "y", "y", "y", "y", "y" },
                new List<string> { "y", "y", "y", "y", "y" },
                new List<string> { "y", "y", "y", "y", "y" },
                new List<string> { "y", "y", "y", "y", "y" }
            };

            line.Columns = data;

            Assert.IsTrue(line.CheckDraw());
        }

        [TestMethod]
        public void FullBoardR()
        {
            var line = new LineCheck()
            {
                Rows = 5,
                Cols = 5,
                Token = "x"
            };

            var data = new List<List<string>>
            {
                new List<string> { "r", "r", "r", "r", "r" },
                new List<string> { "r", "r", "r", "r", "r" },
                new List<string> { "r", "r", "r", "r", "r" },
                new List<string> { "r", "r", "r", "r", "r" },
                new List<string> { "r", "r", "r", "r", "r" }
            };

            line.Columns = data;

            Assert.IsTrue(line.CheckDraw());
        }

        [TestMethod]
        public void FullAlternate()
        {
            var line = new LineCheck()
            {
                Rows = 5,
                Cols = 5,
                Token = "x"
            };

            var data = new List<List<string>>
            {
                new List<string> { "y", "r", "y", "r", "y" },
                new List<string> { "r", "y", "r", "y", "r" },
                new List<string> { "y", "r", "y", "r", "y" },
                new List<string> { "r", "y", "r", "y", "r" },
                new List<string> { "y", "r", "y", "r", "y" }
            };

            line.Columns = data;

            Assert.IsTrue(line.CheckDraw());
        }
    }
}
