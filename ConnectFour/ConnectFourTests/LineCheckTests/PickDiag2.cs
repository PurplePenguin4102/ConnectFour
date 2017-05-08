using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConnectFour;
using System.Collections.Generic;
using System.Linq;

namespace ConnectFourTests.LineCheckTests
{
    [TestClass]
    public class PickDiag2
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
        public void GetDiagOne()
        {
            var output = new List<string> { "a" };
            var realOutput = line.PickDiag2(0, 0);
            Assert.IsTrue(realOutput.SequenceEqual(output));
        }

        [TestMethod]
        public void GetDiagTwo()
        {
            var output = new List<string> { "b", "f" };
            var realOutput = line.PickDiag2(1, 0);
            Assert.IsTrue(realOutput.SequenceEqual(output));
        }

        [TestMethod]
        public void GetDiagThree()
        {
            var output = new List<string> { "c", "g", "k" };
            var realOutput = line.PickDiag2(2, 0);
            Assert.IsTrue(realOutput.SequenceEqual(output));
        }

        [TestMethod]
        public void GetDiagFour()
        {
            var output = new List<string> { "d", "h", "l", "p" };
            var realOutput = line.PickDiag2(3, 0);
            Assert.IsTrue(realOutput.SequenceEqual(output));
        }

        [TestMethod]
        public void GetDiagFive()
        {
            var output = new List<string> { "i", "m", "q", "u" };
            var realOutput = line.PickDiag2(4, 0);
            Assert.IsTrue(realOutput.SequenceEqual(output));
        }

        [TestMethod]
        public void GetDiagSix()
        {
            var output = new List<string> { "t", "y" };
            var realOutput = line.PickDiag2(3, 4);
            Assert.IsTrue(realOutput.SequenceEqual(output));
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            line = null;
        }
    }
}
