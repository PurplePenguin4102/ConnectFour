using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConnectFour;
using System.Collections.Generic;
using System.Linq;

namespace ConnectFourTests.LineCheckTests
{
    [TestClass]
    public class PickDirectionMaxLength
    {
        static LineCheck line;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testCtx)
        {
            line = new LineCheck()
            {
                Rows = 10,
                Cols = 10,
                Token = "x"
            };

            var data = new List<List<string>>
            {
                new List<string> { "o", "o", "o", "o", "o", "o", "o", "o", "o", "o" },
                new List<string> { "o", "d1", "o", "o", "h", "o", "o", "d2", "o", "o" },
                new List<string> { "o", "o", "o", "o", "o", "o", "o", "o", "o", "o" },
                new List<string> { "o", "o", "o", "o", "o", "o", "o", "o", "o", "o" },
                new List<string> { "o", "v", "o", "o", "x", "o", "o", "v", "o", "o" },
                new List<string> { "o", "o", "o", "o", "o", "o", "o", "o", "o", "o" },
                new List<string> { "o", "o", "o", "o", "o", "o", "o", "o", "o", "o" },
                new List<string> { "o", "d2", "o", "o", "h", "o", "o", "d1", "o", "o" },
                new List<string> { "o", "o", "o", "o", "o", "o", "o", "o", "o", "o" },
                new List<string> { "o", "o", "o", "o", "o", "o", "o", "o", "o", "o" }
            };

            line.Columns = data;
        }

        [TestMethod]
        public void PickHorizMax()
        {
            List<string> data = new List<string> { "h", "o", "o", "x", "o", "o", "h" };
            List<string> output = line.PickHoriz(4, 4);
            Assert.IsTrue(output.SequenceEqual(data));
        }

        [TestMethod]
        public void PickVertMax()
        {
            List<string> data = new List<string> { "v", "o", "o", "x", "o", "o", "v" };
            List<string> output = line.PickVert(4, 4);
            Assert.IsTrue(output.SequenceEqual(data));
        }

        [TestMethod]
        public void PickDiag1Max()
        {
            List<string> data = new List<string> { "d1", "o", "o", "x", "o", "o", "d1" };
            List<string> output = line.PickDiag1(4, 4);
            Assert.IsTrue(output.SequenceEqual(data));
        }

        [TestMethod]
        public void PickDiag2Max()
        {
            List<string> data = new List<string> { "d2", "o", "o", "x", "o", "o", "d2" };
            List<string> output = line.PickDiag2(4, 4);
            Assert.IsTrue(output.SequenceEqual(data));
        }



        [ClassCleanup]
        public static void ClassCleanup()
        {
            line = null;
        }
    }
}
