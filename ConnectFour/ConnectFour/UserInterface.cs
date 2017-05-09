using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectFour.Enums;
using ConnectFour.Exceptions;
using ConnectFour.InputOutput;

namespace ConnectFour
{
    class UserInterface
    {
        private string dimensionErrorMsg = "> Invalid input, please enter two positive numbers (num1 num2)";
        private string dimensionPromptMsg = "> Please enter the board dimensions (number of rows, number of columns) - minimum dimensions are 2x4";
        private string moveErrorMsg = $"> Please enter a single positive number within the board dimensions";
        private string goodbyeMsg = "See you next time!";
        private string boardRejectMsg = "> Please enter a single positive number within the board dimensions";
        private Input input = new Input();
        private Output output = new Output();
        private Validator rules = new Validator();

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
                    if (rules.ValidateDimensions(usrIn))
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
                    output.Send(dimensionErrorMsg);
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
                    if (rules.ValidateMove(usrIn))
                    {
                        move = usrIn[0];
                    }
                    else
                    {
                        throw new UserInputException();
                    }
                }
                catch (UserInputException)
                {
                    output.Send(moveErrorMsg);
                }
            }
            return move;
        }

        /// <summary>
        /// Displays the current state of the game board to the user
        /// </summary>
        public string Print(GameBoard gameBoard)
        {
            return output.Send(gameBoard.ToString(), true);
        }

        /// <summary>
        /// Displays the result of the player's turn, either printing the board or an error message
        /// </summary>
        public string PrintResult(MoveResult result, Players whoseTurn, GameBoard gameBoard)
        {
            switch (result)
            {
                case MoveResult.GameOver:
                    Print(gameBoard);
                    return output.Send($"{gameBoard.Winner.ToString()} WINS !");
                case MoveResult.Invalid:
                    return output.Send(boardRejectMsg);
                case MoveResult.Valid:
                    return Print(gameBoard);
                default:
                    //crash: logical error
                    throw new ArgumentOutOfRangeException($"Enum value {result} not supported");
            }
        }

        /// <summary>
        /// Writes a message, grabs user input, returns it as an int array. Throws on error or if user doesn't
        /// provide space separated numbers.
        /// </summary>
        private int[] Prompt(string promptMsg)
        {
            output.Send(promptMsg);
            output.Send("> ", true);
            string inputRes = input.Get().ToLower().Trim();

            if (rules.CheckForExit(inputRes));
            {
                output.Send(goodbyeMsg);
                Environment.Exit(0);
            }
            string[] tokens = inputRes.Split(' ');
            int[] usrIn = rules.ParseTokens(tokens);

            return usrIn.ToArray();
        }
    }
}
