using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConnectFour;
using System.Collections.Generic;
using System.Linq;

namespace ConnectFourTests
{
    [TestClass]
    public class PickVert
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
        public void GetColumn1Of5AtZero()
        {
            var output = new List<string> { "a", "b", "c", "d" };
            var realOutput = line.PickVert(0, 0);
            Assert.IsTrue(realOutput.SequenceEqual(output));
        }

        [TestMethod]
        public void GetColumn1Of5AtTwo()
        {
            var output = new List<string> { "a", "b", "c", "d", "e" };
            var realOutput = line.PickVert(0, 2);
            Assert.IsTrue(realOutput.SequenceEqual(output));
        }

        [TestMethod]
        public void GetColumn1Of5AtFour()
        {
            var output = new List<string> { "b", "c", "d", "e" };
            var realOutput = line.PickVert(0, 4);
            Assert.IsTrue(realOutput.SequenceEqual(output));
        }

        [TestMethod]
        public void GetColumn2Of5()
        {
            var output = new List<string> { "f", "g", "h", "i" };
            var realOutput = line.PickVert(1, 0);
            Assert.IsTrue(realOutput.SequenceEqual(output));
        }

        [TestMethod]
        public void GetColumn3Of5()
        {
            var output = new List<string> { "k", "l", "m", "n" };
            var realOutput = line.PickVert(2, 0);
            Assert.IsTrue(realOutput.SequenceEqual(output));
        }

        [TestMethod]
        public void GetColumn4Of5()
        {
            var output = new List<string> { "p", "q", "r", "s" };
            var realOutput = line.PickVert(3, 0);
            Assert.IsTrue(realOutput.SequenceEqual(output));
        }

        [TestMethod]
        public void GetColumn5Of5()
        {
            var output = new List<string> { "u", "v", "x", "y" };
            var realOutput = line.PickVert(4, 0);
            Assert.IsTrue(realOutput.SequenceEqual(output));
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            line = null;
        }
    }
}
