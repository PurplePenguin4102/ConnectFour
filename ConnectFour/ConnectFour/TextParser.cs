using ConnectFour.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConnectFour
{
    public class TextParser
    {
        /// <summary>
        /// tokenises the user's input into a string array
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string[] GetTokens(string input)
        {
            List<string> lst = new List<string>();
            foreach (var match in Regex.Matches(input, @"(\S+)"))
            {
                lst.Add(match.ToString());
            }

            return lst.ToArray();
        }

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

        public string Clean(string v)
        {
            return v.ToLower().Trim();
        }
    }
}
