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
    public class UserInterface
    {
        private string dimensionErrorMsg = "> Invalid input, please enter two positive numbers (num1 num2) - minimum dimensions are 2x4";
        private string dimensionPromptMsg = "> Please enter the board dimensions (number of rows, number of columns)";
        private string moveErrorMsg = $"> Please enter a single positive number within the board dimensions";
        private string goodbyeMsg = "See you next time!";
        private string boardRejectMsg = "> Please enter a single positive number within the board dimensions";
        public IInputRetriever Input { private get; set; } = new Input();
        public IOutputSender Output { private get; set; } = new Output();
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
                    Output.Send(dimensionErrorMsg, true);
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
            string promptMsg = $"> {whoseTurn.ToString()}s turn:";
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
                    Output.Send(moveErrorMsg, true);
                }
            }
            return move;
        }

        /// <summary>
        /// Displays the current state of the game board to the user
        /// </summary>
        public string Print(GameBoard gameBoard)
        {
            return Output.Send(gameBoard.ToString(), false);
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
                    return Output.Send($"> {gameBoard.Winner.ToString()} WINS !", true);
                case MoveResult.Invalid:
                    return Output.Send(boardRejectMsg, true);
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
            Output.Send(promptMsg, true);
            Output.Send("> ", false);
            var textParser = new TextParser();

            string input = textParser.Clean(Input.Get());

            if (rules.CheckForExit(input))
            {
                Output.Send(goodbyeMsg, true);
                Environment.Exit(0);
            }

            string[] tokens = textParser.GetTokens(input); 
            return textParser.ParseTokens(tokens);
        }
    }
}
