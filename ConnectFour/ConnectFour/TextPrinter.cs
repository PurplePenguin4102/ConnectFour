using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectFour.Enums;

namespace ConnectFour
{
    class TextPrinter
    {
        public void Print(GameBoard gameBoard)
        {
            Console.Write(gameBoard);
        }

        internal void PrintResult(MoveResult result, Players whoseTurn, GameBoard gameBoard)
        {
            throw new NotImplementedException();
        }
    }
}
