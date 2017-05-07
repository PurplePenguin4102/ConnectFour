using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectFour.Enums;
using ConnectFour.Exceptions;

namespace ConnectFour
{
    class UserInterface
    {
        private string dimensionErrorMsg = "> Invalid input, please enter two positive numbers (num1 num2)";
        private string dimensionPromptMsg = "> Please enter the board dimensions (number of rows, number of columns) - minimum dimensions are 2x4";
        private string moveErrorMsg = $"> Please enter a single positive number within the board dimensions";
        private string goodbyeMsg = "See you next time!";
        private string boardRejectMsg = "> Please enter a single positive number within the board dimensions";

        /// <summary>
        /// prompts the user for the gameboard dimensions. Return value should be the dimensions
        /// in rows/columns
        /// </summary>
        public Tuple<int, int> PromptDimensions()
        {
            Tuple<int, int> dimensions = null;

            while (dimensions == null)
            {
                try
                {
                    int[] usrIn = Prompt(dimensionPromptMsg);
                    if (ValidateDimensions(usrIn))
                    {
                        // we now know usrIn contains 2 positive numbers
                        dimensions = new Tuple<int, int>(usrIn[0], usrIn[1]);
                    }
                    else
                    {
                        throw new UserInputException();
                    }
                }
                catch (UserInputException)
                {
                    Console.WriteLine(dimensionErrorMsg);
                }
            }
            return dimensions;
        }

        /// <summary>
        /// Prompts the user for their desired move. Returns a number indicating a column they wish to fill.
        /// Only returns if the user has entered a positive number, may not be a valid move according to game logic
        /// </summary>
        public int GetMove(Players whoseTurn)
        {
            string promptMsg = $"> {whoseTurn.ToString()}s turn";
            int move = 0;
            while (move == 0)
            {
                try
                {
                    int[] usrIn = Prompt(promptMsg);
                    if (usrIn.Length != 1 || usrIn[0] <= 0)
                    {
                        throw new UserInputException();
                    }
                }
                catch (UserInputException)
                {
                    Console.WriteLine(moveErrorMsg);
                }
            }
            return move;
        }

        /// <summary>
        /// Writes a message, grabs user input, returns it as an int array. Throws on error or if user doesn't
        /// provide space separated numbers.
        /// </summary>
        private int[] Prompt(string promptMsg)
        {
            Console.WriteLine(promptMsg);
            Console.Write("> ");
            string rawInput = CheckForExit();
            string[] tokens = rawInput.Split(' ');
            List<int> usrIn = new List<int>(tokens.Length);

            foreach (var param in tokens)
            {
                int temp;
                bool success = int.TryParse(param, out temp);
                if (!success)
                    throw new UserInputException();
                usrIn.Add(temp);
            }
            return usrIn.ToArray();
        }

        /// <summary>
        /// Reads the console input and checks it against an exit condition
        /// </summary>
        private string CheckForExit()
        {
            string usrIn = Console.ReadLine().ToLower().Trim();
            if (usrIn == "exit" || usrIn == "quit")
            {
                Console.WriteLine(goodbyeMsg);
                Environment.Exit(0);
            }
            return usrIn;
        }

        /// <summary>
        /// Validates that the user input is two positive numbers
        /// </summary>
        private bool ValidateDimensions(int[] usrIn)
        {
            if (usrIn.Length == 2)
            {
                /* I could use LINQ here, the query would be:
                 * 
                 * if (usrIn.All(dim => dim >= 1) && 
                       usrIn.Any(dim => dim >= 4) && 
                       usrIn.Aggregate((acc, dim) => dim * acc) >= 8) 
                 * 
                 * but I felt it was redundant to iterate the int[] for 2 dimensions
                 */
                if ((usrIn[0] >= 1 && usrIn[1] >= 1) && // all dimensions must be positive
                    (usrIn[0] >= 4 || usrIn[1] >= 4) && // at least one direction must be >= 4 for a win to be possible
                    (usrIn[0] * usrIn[1] >= 8)) // the minimum number of spaces must be 8 for a win to be possible
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Displays the current state of the game board to the user
        /// </summary>
        public void Print(GameBoard gameBoard)
        {
            Console.Write(gameBoard);
        }

        /// <summary>
        /// Displays the result of the player's turn, either printing the board or an error message
        /// </summary>
        public void PrintResult(MoveResult result, Players whoseTurn, GameBoard gameBoard)
        {
            switch (result)
            {
                case MoveResult.GameOver:
                    Console.WriteLine($"{gameBoard.Winner.ToString()} WINS !");
                    break;
                case MoveResult.Invalid:
                    Console.WriteLine(boardRejectMsg);
                    break;
                case MoveResult.Valid:
                    Print(gameBoard);
                    break;
                default:
                    //crash: logical error
                    throw new ArgumentOutOfRangeException($"Enum value {result} not supported");
            }
        }
    }
}
