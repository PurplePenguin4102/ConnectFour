using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConnectFour;
using System.Collections.Generic;
using System.Linq;

namespace ConnectFourTests.LineCheckTests
{
    [TestClass]
    public class PickHoriz
    {
        static LineCheck line;

        [ClassInitialize]
        public static void ClassInit(TestContext testCtx)
        {
            line = new LineCheck()
            {
                Rows = 5,
                Cols = 5,
                Token = "x"
            };

            var data = new List<List<string>>
            {
                new List<string> { "a", "b", "c", "d", "e" },
                new List<string> { "f", "g", "h", "i", "j" },
                new List<string> { "k", "l", "m", "n", "o" },
                new List<string> { "p", "q", "r", "s", "t" },
                new List<string> { "u", "v", "x", "y", "z" }
            };

            line.Columns = data;
        }

        [TestMethod]
        public void GetRow1Of5AtZero()
        {
            var output = new List<string> { "a", "f", "k", "p" };
            var realOutput = line.PickHoriz(0, 0);
            Assert.IsTrue(realOutput.SequenceEqual(output));
        }

        [TestMethod]
        public void GetRow1Of5AtTwo()
        {
            var output = new List<string> { "a", "f", "k", "p", "u" };
            var realOutput = line.PickHoriz(2, 0);
            Assert.IsTrue(realOutput.SequenceEqual(output));
        }

        [TestMethod]
        public void GetRow1Of5AtFour()
        {
            var output = new List<string> { "f", "k", "p", "u" };
            var realOutput = line.PickHoriz(4, 0);
            Assert.IsTrue(realOutput.SequenceEqual(output));
        }

        [TestMethod]
        public void GetRow2Of5()
        {
            var output = new List<string> { "b", "g", "l", "q" };
            var realOutput = line.PickHoriz(0, 1);
            Assert.IsTrue(realOutput.SequenceEqual(output));
        }

        [TestMethod]
        public void GetRow3Of5()
        {
            var output = new List<string> { "c", "h", "m", "r" };
            var realOutput = line.PickHoriz(0, 2);
            Assert.IsTrue(realOutput.SequenceEqual(output));
        }

        [TestMethod]
        public void GetRow4Of5()
        {
            var output = new List<string> { "d", "i", "n", "s" };
            var realOutput = line.PickHoriz(0, 3);
            Assert.IsTrue(realOutput.SequenceEqual(output));
        }

        [TestMethod]
        public void GetRow5Of5()
        {
            var output = new List<string> { "e", "j", "o", "t" };
            var realOutput = line.PickHoriz(0, 4);
            Assert.IsTrue(realOutput.SequenceEqual(output));
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            line = null;
        }
    }
}
