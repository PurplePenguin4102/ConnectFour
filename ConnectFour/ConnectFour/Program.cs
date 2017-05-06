using System;
using ConnectFour.Enums;

namespace ConnectFour
{
    class Program
    {
        static void Main(string[] args)
        {
            TextParser parser = new TextParser();
            TextPrinter printer = new TextPrinter();

            Tuple<int, int> dimensions = parser.PromptDimensions();
            GameBoard gameBoard = new GameBoard(dimensions.Item1, dimensions.Item2);
            printer.Print(gameBoard);
            MoveResult result = MoveResult.Invalid;
            Players whoseTurn = Players.Yellow;

            while (result != MoveResult.GameOver)
            {
                int move = parser.GetMove(whoseTurn);
                result = gameBoard.TryModifyBoard(move, whoseTurn);
                printer.PrintResult(result, whoseTurn, gameBoard);
                if (result == MoveResult.Valid)
                {
                    whoseTurn = whoseTurn == Players.Yellow ? Players.Red : Players.Yellow;
                }
            }
        }
    }
}
