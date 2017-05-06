using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectFour.Enums;
using ConnectFour.Exceptions;

namespace ConnectFour
{
    class TextParser
    {
        /// <summary>
        /// prompts the user for the gameboard dimensions. Return value should be the dimensions
        /// in rows/columns
        /// </summary>
        public Tuple<int, int> PromptDimensions()
        {
            Tuple<int, int> dimensions = null;
            string errorMsg = "> Invalid input, please enter two positive numbers (num1 num2)";
            string promptMsg = "> Please enter the board dimensions (number of rows, number of columns)";

            while (dimensions == null)
            {
                try
                {
                    int[] usrIn = Prompt(promptMsg);
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
                    Console.WriteLine(errorMsg);
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
            string errorMsg = $"> Please enter a single positive number within the board dimensions";
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
                    Console.WriteLine(errorMsg);
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
            string[] rawInput = Console.ReadLine().Trim().Split(' ');
            List<int> usrIn = new List<int>(rawInput.Length);

            foreach (var param in rawInput)
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
        /// Validates that the user input is two positive numbers
        /// </summary>
        private bool ValidateDimensions(int[] usrIn)
        {
            if (usrIn.Length == 2)
            {
                if (usrIn[0] >= 1 && usrIn[1] >= 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
