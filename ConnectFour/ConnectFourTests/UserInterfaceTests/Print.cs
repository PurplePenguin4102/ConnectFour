using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConnectFour;

namespace ConnectFourTests.UserInterfaceTests
{
    [TestClass]
    public class Print
    {
        [TestMethod]
        public void GivesBackGameboardToString()
        {
            var ui = new UserInterface();
            ui.Input = new MockInput();
            ui.Output = new MockOutput();
            var board = new GameBoard(505, 234);

            Assert.AreEqual(ui.Print(board), board.ToString());
        }
    }
}
