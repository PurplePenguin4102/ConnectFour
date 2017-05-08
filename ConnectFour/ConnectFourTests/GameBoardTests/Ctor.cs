using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConnectFour;

namespace ConnectFourTests.GameBoardTests
{
    [TestClass]
    public class Ctor
    {
        [TestMethod]
        public void FiveByFive_Valid()
        {
            string data = @"o o o o o 
o o o o o 
o o o o o 
o o o o o 
o o o o o 
";
            GameBoard gb = new GameBoard(5, 5);
            string str = gb.ToString();
            Assert.AreEqual(data, str);
        }

        [TestMethod]
        public void FourByTwo_Valid()
        {
            string data = @"o o 
o o 
o o 
o o 
";
            GameBoard gb = new GameBoard(4, 2);
            string str = gb.ToString();
            Assert.AreEqual(data, str);
        }

        [TestMethod]
        public void TwoByfour_Valid()
        {
            string data = @"o o o o 
o o o o 
";
            GameBoard gb = new GameBoard(2, 4);
            string str = gb.ToString();
            Assert.AreEqual(data, str);
        }

        [TestMethod]
        public void NegativeDimensionY_Invalid()
        {
            Assert.ThrowsException<ArgumentException>(() => new GameBoard(-1, 1));
        }

        [TestMethod]
        public void NegativeDimensionX_Invalid()
        {
            Assert.ThrowsException<ArgumentException>(() => new GameBoard(1, -1));
        }
    }
}
