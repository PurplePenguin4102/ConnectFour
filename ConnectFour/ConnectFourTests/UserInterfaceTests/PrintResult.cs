using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConnectFour;
using ConnectFour.Enums;
using System;

namespace ConnectFourTests.UserInterfaceTests
{
    [TestClass]
    public class PrintResult
    {
        [TestMethod]
        public void ValidMove()
        {
            var ui = new UserInterface();
            ui.Input = new MockInput();
            ui.Output = new MockOutput();
            var board = new GameBoard(505, 234);

            Assert.AreEqual(ui.PrintResult(MoveResult.Valid, Players.Yellow, board), board.ToString());
        }

        [TestMethod]
        public void InvalidMove()
        {
            var ui = new UserInterface();
            ui.Input = new MockInput();
            ui.Output = new MockOutput();
            var board = new GameBoard(505, 234);

            Assert.AreEqual(ui.PrintResult(MoveResult.Invalid, Players.Yellow, board), "> Please enter a single positive number within the board dimensions");
        }

        [TestMethod]
        public void GameOver_YellowWins()
        {
            var ui = new UserInterface();
            ui.Input = new MockInput();
            ui.Output = new MockOutput();
            var board = new GameBoard(505, 234)
            {
                Winner = Players.Yellow
            };
            Assert.AreEqual(ui.PrintResult(MoveResult.GameOver, Players.Yellow, board), "> Yellow WINS !");
        }

        [TestMethod]
        public void GameOver_RedWins()
        {
            var ui = new UserInterface();
            ui.Input = new MockInput();
            ui.Output = new MockOutput();
            var board = new GameBoard(505, 234)
            {
                Winner = Players.Red
            };

            Assert.AreEqual(ui.PrintResult(MoveResult.GameOver, Players.Red, board), "> Red WINS !");
        }

        [TestMethod]
        public void GameOver_Draw()
        {
            var ui = new UserInterface();
            ui.Input = new MockInput();
            ui.Output = new MockOutput();
            var board = new GameBoard(505, 234)
            {
                Winner = Players.Nobody
            };

            Assert.AreEqual(ui.PrintResult(MoveResult.GameOver, Players.Nobody, board), "> Nobody WINS !");
        }

        [TestMethod]
        public void BadMoveResult()
        {
            var ui = new UserInterface();
            ui.Input = new MockInput();
            ui.Output = new MockOutput();
            var board = new GameBoard(505, 234);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ui.PrintResult((MoveResult) 5, Players.Nobody, board));
        }
    }
}
