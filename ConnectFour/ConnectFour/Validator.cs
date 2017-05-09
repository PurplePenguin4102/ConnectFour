using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectFour.Exceptions;

namespace ConnectFour
{
    public class Validator
    {
        /// <summary>
        /// Parses the tokens into integers, may throw a UserInputException
        /// </summary>
        public int[] ParseTokens(string[] tokens)
        {
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
        public bool CheckForExit(string input)
        {
            return (input == "exit" || input == "quit");
        }

        /// <summary>
        /// Validates that the user input is two positive numbers
        /// </summary>
        public bool ValidateDimensions(int[] usrIn)
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
        /// Validates the move against the board as it is
        /// </summary>
        public bool ValidateMoveAgainstBoard(int move, List<List<string>> columns)
        {
            if (move > columns.Count)
                return false;
            List<string> columnToModify = columns[move - 1];
            if (!columnToModify.Any((ele) => ele == "o"))
                return false;
            return true;
        }

        /// <summary>
        /// Does basic validation on a user's move without knowing about game board
        /// </summary>
        public bool ValidateMove(int[] usrIn)
        {
            return usrIn.Length == 1 && usrIn[0] > 0;
        }
    }
}
