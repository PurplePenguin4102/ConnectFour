using System;
using ConnectFour.Enums;

namespace ConnectFour
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInterface user = new UserInterface();

            Tuple<int, int> dimensions = user.PromptDimensions();
            GameBoard gameBoard = new GameBoard(dimensions.Item1, dimensions.Item2);
            user.Print(gameBoard);
            MoveResult result = MoveResult.Invalid;
            Players whoseTurn = Players.Yellow;

            while (result != MoveResult.GameOver)
            {
                int move = user.GetMove(whoseTurn);
                result = gameBoard.TryModifyBoard(move, whoseTurn);
                user.PrintResult(result, whoseTurn, gameBoard);
                if (result == MoveResult.Valid)
                {
                    whoseTurn = whoseTurn == Players.Yellow ? Players.Red : Players.Yellow;
                }
            }
            Console.ReadKey();
        }
    }
}
