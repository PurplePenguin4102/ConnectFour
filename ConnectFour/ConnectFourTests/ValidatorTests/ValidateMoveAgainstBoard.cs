using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConnectFour;
using System.Collections.Generic;

namespace ConnectFourTests.ValidatorTests
{
    [TestClass]
    public class ValidateMoveAgainstBoard
    {
        /* out of scope : 
         * Negative move or move = 0
         * invalid boards - boards only contain "o" "y" and "r" and are filled from index 0
         */

        [TestMethod]
        public void ValidMove1()
        {
            var board = new List<List<string>>()
            {
                new List<string> { "o", "o", "o"},
                new List<string> { "o", "o", "o"},
                new List<string> { "o", "o", "o"}
            };
            var rules = new Validator();
            int move = 1;

            Assert.IsTrue(rules.ValidateMoveAgainstBoard(move, board));
        }

        [TestMethod]
        public void ValidMove2()
        {
            var board = new List<List<string>>()
            {
                new List<string> { "o", "o", "o"},
                new List<string> { "o", "o", "o"},
                new List<string> { "o", "o", "o"}
            };
            var rules = new Validator();
            int move = 2;

            Assert.IsTrue(rules.ValidateMoveAgainstBoard(move, board));
        }

        [TestMethod]
        public void ValidMove3()
        {
            var board = new List<List<string>>()
            {
                new List<string> { "o", "o", "o"},
                new List<string> { "o", "o", "o"},
                new List<string> { "o", "o", "o"}
            };
            var rules = new Validator();
            int move = 3;

            Assert.IsTrue(rules.ValidateMoveAgainstBoard(move, board));
        }

        [TestMethod]
        public void InvalidMove_RowFull()
        {
            var board = new List<List<string>>()
            {
                new List<string> { "o", "o", "o"},
                new List<string> { "y", "y", "y"},
                new List<string> { "o", "o", "o"}
            };
            var rules = new Validator();
            int move = 2;

            Assert.IsFalse(rules.ValidateMoveAgainstBoard(move, board));
        }

        [TestMethod]
        public void InvalidMove_NoSuchColumn()
        {
            var board = new List<List<string>>()
            {
                new List<string> { "o", "o", "o"},
                new List<string> { "o", "o", "o"},
                new List<string> { "o", "o", "o"}
            };
            var rules = new Validator();
            int move = 4;

            Assert.IsFalse(rules.ValidateMoveAgainstBoard(move, board));
        }
    }
}
