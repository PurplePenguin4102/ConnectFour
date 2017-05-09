using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConnectFour;
using ConnectFour.Enums;

namespace ConnectFourTests.GameBoardTests
{
    [TestClass]
    public class TryModifyBoard
    {
        [TestMethod]
        public void AddToEmpty_RedTurn()
        {
            var board = new GameBoard(2, 2);
            board.TryModifyBoard(1, Players.Red);
            var expected = @"o o 
r o 
";
            Assert.AreEqual(board.ToString(), expected);
        }

        [TestMethod]
        public void AddToEmpty_YellowTurn()
        {
            var board = new GameBoard(2, 2);
            board.TryModifyBoard(1, Players.Yellow);
            var expected = @"o o 
y o 
";
            Assert.AreEqual(board.ToString(), expected);
        }

        [TestMethod]
        public void AddToPopulated_YellowTurn()
        {
            var board = new GameBoard(2, 2);
            board.TryModifyBoard(1, Players.Yellow);
            board.TryModifyBoard(1, Players.Yellow);
            var expected = @"y o 
y o 
";
            Assert.AreEqual(board.ToString(), expected);
        }

        [TestMethod]
        public void AddToPopulated_RedTurn()
        {
            var board = new GameBoard(2, 2);
            board.TryModifyBoard(1, Players.Yellow);
            board.TryModifyBoard(1, Players.Red);
            var expected = @"r o 
y o 
";
            Assert.AreEqual(board.ToString(), expected);
        }

        [TestMethod]
        public void AddToFull_YellowTurn()
        {
            var board = new GameBoard(2, 2);
            board.TryModifyBoard(1, Players.Red);
            board.TryModifyBoard(1, Players.Red);
            Assert.AreEqual(board.TryModifyBoard(1, Players.Yellow), MoveResult.Invalid);
        }

        [TestMethod]
        public void AddToFull_RedTurn()
        {
            var board = new GameBoard(2, 2);
            board.TryModifyBoard(1, Players.Red);
            board.TryModifyBoard(1, Players.Red);
            Assert.AreEqual(board.TryModifyBoard(1, Players.Red), MoveResult.Invalid);
        }

        [TestMethod]
        public void AddToInvalid_RedTurn()
        {
            var board = new GameBoard(2, 2);
            Assert.AreEqual(board.TryModifyBoard(3, Players.Red), MoveResult.Invalid);
        }

        [TestMethod]
        public void AddToHalfPopulated_RedTurn()
        {
            var board = new GameBoard(5, 5);
            board.TryModifyBoard(1, Players.Red);
            board.TryModifyBoard(2, Players.Red);
            board.TryModifyBoard(2, Players.Red);
            board.TryModifyBoard(3, Players.Red);
            board.TryModifyBoard(3, Players.Red);
            board.TryModifyBoard(3, Players.Red);
            board.TryModifyBoard(1, Players.Yellow);
            board.TryModifyBoard(1, Players.Yellow);
            board.TryModifyBoard(4, Players.Yellow);
            board.TryModifyBoard(4, Players.Yellow);
            board.TryModifyBoard(4, Players.Yellow);
            string expected = @"o o o o o 
r o o o o 
y o r y o 
y r r y o 
r r r y o 
";
            // action
            board.TryModifyBoard(1, Players.Red);
            Assert.AreEqual(board.ToString(), expected);
        }

        [TestMethod]
        public void AddToHaldPopulated_YellowTurn()
        {
            var board = new GameBoard(5, 5);
            board.TryModifyBoard(1, Players.Red);
            board.TryModifyBoard(2, Players.Red);
            board.TryModifyBoard(2, Players.Red);
            board.TryModifyBoard(3, Players.Red);
            board.TryModifyBoard(3, Players.Red);
            board.TryModifyBoard(3, Players.Red);
            board.TryModifyBoard(1, Players.Yellow);
            board.TryModifyBoard(1, Players.Yellow);
            board.TryModifyBoard(4, Players.Yellow);
            board.TryModifyBoard(4, Players.Yellow);
            board.TryModifyBoard(4, Players.Yellow);
            string expected = @"o o o o o 
o o o o o 
y o r y o 
y r r y o 
r r r y y 
";
            // action
            board.TryModifyBoard(5, Players.Yellow);
            Assert.AreEqual(board.ToString(), expected);
        }

        [TestMethod]
        public void WinningMoveHoriz_YellowTurn()
        {
            var board = new GameBoard(5, 5);
            board.TryModifyBoard(1, Players.Red);
            board.TryModifyBoard(2, Players.Red);
            board.TryModifyBoard(2, Players.Red);
            board.TryModifyBoard(2, Players.Red);
            board.TryModifyBoard(3, Players.Red);
            board.TryModifyBoard(3, Players.Red);
            board.TryModifyBoard(3, Players.Red);
            board.TryModifyBoard(1, Players.Yellow);
            board.TryModifyBoard(1, Players.Yellow);
            board.TryModifyBoard(4, Players.Yellow);
            board.TryModifyBoard(4, Players.Red);
            board.TryModifyBoard(4, Players.Yellow);
            string expected = @"o o o o o 
y y y y o 
y r r y o 
y r r r o 
r r r y o 
";
            // action
            board.TryModifyBoard(1, Players.Yellow);
            board.TryModifyBoard(2, Players.Yellow);
            board.TryModifyBoard(3, Players.Yellow);
            Assert.AreEqual(board.TryModifyBoard(4, Players.Yellow), MoveResult.GameOver);
            Assert.AreEqual(board.Winner, Players.Yellow);
            Assert.AreEqual(board.ToString(), expected);
        }

        [TestMethod]
        public void WinningMoveHoriz_RedTurn()
        {
            var board = new GameBoard(5, 5);
            board.TryModifyBoard(1, Players.Yellow);
            board.TryModifyBoard(2, Players.Red);
            board.TryModifyBoard(2, Players.Red);
            board.TryModifyBoard(2, Players.Yellow);
            board.TryModifyBoard(3, Players.Red);
            board.TryModifyBoard(3, Players.Yellow);
            board.TryModifyBoard(3, Players.Red);
            board.TryModifyBoard(1, Players.Yellow);
            board.TryModifyBoard(1, Players.Yellow);
            board.TryModifyBoard(4, Players.Yellow);
            board.TryModifyBoard(4, Players.Red);
            board.TryModifyBoard(4, Players.Yellow);
            string expected = @"o o o o o 
r r r r o 
y y r y o 
y r y r o 
y r r y o 
";
            // action
            board.TryModifyBoard(1, Players.Red);
            board.TryModifyBoard(2, Players.Red);
            board.TryModifyBoard(3, Players.Red);
            Assert.AreEqual(board.TryModifyBoard(4, Players.Red), MoveResult.GameOver);
            Assert.AreEqual(board.Winner, Players.Red);
            Assert.AreEqual(board.ToString(), expected);
        }

        [TestMethod]
        public void WinningMoveVert_YellowTurn()
        {
            var board = new GameBoard(5, 5);
            board.TryModifyBoard(1, Players.Yellow);
            board.TryModifyBoard(1, Players.Yellow);
            board.TryModifyBoard(1, Players.Yellow);
            board.TryModifyBoard(2, Players.Red);
            board.TryModifyBoard(2, Players.Red);
            board.TryModifyBoard(2, Players.Red);
            string expected = @"o o o o o 
y o o o o 
y r o o o 
y r o o o 
y r o o o 
";
            Assert.AreEqual(board.TryModifyBoard(1, Players.Yellow), MoveResult.GameOver);
            Assert.AreEqual(board.Winner, Players.Yellow);
            Assert.AreEqual(board.ToString(), expected);
        }

        [TestMethod]
        public void WinningMoveDiag1_YellowTurn()
        {
            var board = new GameBoard(5, 5);
            board.TryModifyBoard(1, Players.Yellow);
            board.TryModifyBoard(2, Players.Yellow);
            board.TryModifyBoard(2, Players.Yellow);
            board.TryModifyBoard(3, Players.Red);
            board.TryModifyBoard(3, Players.Red);
            board.TryModifyBoard(4, Players.Red);
            board.TryModifyBoard(4, Players.Red);
            board.TryModifyBoard(4, Players.Red);
            board.TryModifyBoard(4, Players.Yellow);
            string expected = @"o o o o o 
o o o y o 
o o y r o 
o y r r o 
y y r r o 
";
            Assert.AreEqual(board.TryModifyBoard(3, Players.Yellow), MoveResult.GameOver);
            Assert.AreEqual(board.Winner, Players.Yellow);
            Assert.AreEqual(board.ToString(), expected);
        }

        [TestMethod]
        public void WinningMoveDiag2_RedTurn()
        {
            var board = new GameBoard(5, 5);
            board.TryModifyBoard(4, Players.Red);
            board.TryModifyBoard(3, Players.Yellow);
            board.TryModifyBoard(2, Players.Yellow);
            board.TryModifyBoard(2, Players.Yellow);
            board.TryModifyBoard(2, Players.Red);
            board.TryModifyBoard(1, Players.Yellow);
            board.TryModifyBoard(1, Players.Yellow);
            board.TryModifyBoard(1, Players.Yellow);
            board.TryModifyBoard(1, Players.Red);
            string expected = @"o o o o o 
r o o o o 
y r o o o 
y y r o o 
y y y r o 
";
            Assert.AreEqual(board.TryModifyBoard(3, Players.Red), MoveResult.GameOver);
            Assert.AreEqual(board.Winner, Players.Red);
            Assert.AreEqual(board.ToString(), expected);
        }

        [TestMethod]
        public void WinningMove_Draw()
        {
            var board = new GameBoard(5, 5);
            board.TryModifyBoard(5, Players.Red);
            board.TryModifyBoard(5, Players.Yellow);
            board.TryModifyBoard(5, Players.Red);
            board.TryModifyBoard(5, Players.Yellow);
            board.TryModifyBoard(5, Players.Red);

            board.TryModifyBoard(4, Players.Yellow);
            board.TryModifyBoard(4, Players.Red);
            board.TryModifyBoard(4, Players.Yellow);
            board.TryModifyBoard(4, Players.Red);
            board.TryModifyBoard(4, Players.Yellow);

            board.TryModifyBoard(3, Players.Yellow);
            board.TryModifyBoard(3, Players.Red);
            board.TryModifyBoard(3, Players.Yellow);
            board.TryModifyBoard(3, Players.Red);
            board.TryModifyBoard(3, Players.Yellow);

            board.TryModifyBoard(2, Players.Red);
            board.TryModifyBoard(2, Players.Yellow);
            board.TryModifyBoard(2, Players.Red);
            board.TryModifyBoard(2, Players.Yellow);
            board.TryModifyBoard(2, Players.Red);

            board.TryModifyBoard(1, Players.Yellow);
            board.TryModifyBoard(1, Players.Red);
            board.TryModifyBoard(1, Players.Yellow);
            board.TryModifyBoard(1, Players.Red);

            string expected = @"y r y y r 
r y r r y 
y r y y r 
r y r r y 
y r y y r 
";
            Assert.AreEqual(board.TryModifyBoard(1, Players.Yellow), MoveResult.GameOver);
            Assert.AreEqual(board.Winner, Players.Nobody);
            Assert.AreEqual(board.ToString(), expected);
        }

        [TestMethod]
        public void WinningMove_FinalMoveWins()
        {
            var board = new GameBoard(5, 5);
            board.TryModifyBoard(5, Players.Red);
            board.TryModifyBoard(5, Players.Yellow);
            board.TryModifyBoard(5, Players.Red);
            board.TryModifyBoard(5, Players.Yellow);
            board.TryModifyBoard(5, Players.Red);

            board.TryModifyBoard(4, Players.Yellow);
            board.TryModifyBoard(4, Players.Red);
            board.TryModifyBoard(4, Players.Yellow);
            board.TryModifyBoard(4, Players.Red);
            board.TryModifyBoard(4, Players.Yellow);

            board.TryModifyBoard(3, Players.Yellow);
            board.TryModifyBoard(3, Players.Red);
            board.TryModifyBoard(3, Players.Yellow);
            board.TryModifyBoard(3, Players.Red);
            board.TryModifyBoard(3, Players.Yellow);

            board.TryModifyBoard(2, Players.Red);
            board.TryModifyBoard(2, Players.Yellow);
            board.TryModifyBoard(2, Players.Red);
            board.TryModifyBoard(2, Players.Yellow);
            board.TryModifyBoard(2, Players.Red);

            board.TryModifyBoard(1, Players.Red);
            board.TryModifyBoard(1, Players.Yellow);
            board.TryModifyBoard(1, Players.Yellow);
            board.TryModifyBoard(1, Players.Yellow);

            string expected = @"y r y y r 
y y r r y 
y r y y r 
y y r r y 
r r y y r 
";
            Assert.AreEqual(board.TryModifyBoard(1, Players.Yellow), MoveResult.GameOver);
            Assert.AreEqual(board.Winner, Players.Yellow);
            Assert.AreEqual(board.ToString(), expected);
        }
    }
}
