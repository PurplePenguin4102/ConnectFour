using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    public class LineCheck
    {
        public int Rows { private get; set; }
        public int Cols { private get; set; }
        public string Token { private get; set; }
        public List<List<string>> Columns { private get; set; }

        /// <summary>
        /// Pick the \ direction for 4 in a row around col, row
        /// </summary>
        public List<string> PickDiag2(int col, int row)
        {
            List<string> tokens = new List<string>();
            for (int i = -3; i <= 3; i++)
            {
                // bounds check
                if (col + i < 0 || col + i >= Cols || row - i < 0 || row - i >= Rows)
                    continue;

                // gather tokens
                tokens.Add(Columns[col + i][row - i]);
            }

            return tokens;
        }

        /// <summary>
        /// Pick the / direction for 4 in a row around col, row
        /// </summary>
        public List<string> PickDiag1(int col, int row)
        {
            List<string> tokens = new List<string>();
            for (int i = -3; i <= 3; i++)
            {
                // bounds check
                if (col + i < 0 || col + i >= Cols || row + i < 0 || row + i >= Rows)
                    continue;

                // gather tokens
                tokens.Add(Columns[col + i][row + i]);
            }

            return tokens;
        }

        /// <summary>
        /// Pick the -- direction for 4 in a row around col, row
        /// </summary>
        public List<string> PickHoriz(int col, int row)
        {
            List<string> tokens = new List<string>();
            for (int i = -3; i <= 3; i++)
            {
                // bounds check
                if (col + i < 0 || col + i >= Cols)
                    continue;

                // gather tokens
                tokens.Add(Columns[col + i][row]);
            }

            return tokens;
        }

        /// <summary>
        /// Pick the | direction for 4 in a row around col, row
        /// </summary>
        public List<string> PickVert(int col, int row)
        {
            List<string> tokens = new List<string>();
            for (int i = -3; i <= 3; i++)
            {
                // bounds check
                if (row + i < 0 || row + i >= Rows)
                    continue;

                // gather tokens
                tokens.Add(Columns[col][row + i]);
            }
            
            return tokens;
        }

        /// <summary>
        /// check if the board is full
        /// </summary>
        public bool CheckDraw()
        {
            bool topRowContainsDefault =
                Columns.Select(col => col[Rows - 1])
                .Contains("o");

            return !topRowContainsDefault;
        }

        /// <summary>
        /// Checks whether or not there are 4 consecutive tokens in this list
        /// Only accepts token lists with 7 or less tokens
        /// </summary>
        public bool HasFourInARow(List<string> tokens)
        {
            if (tokens.Count > 7)
                throw new ArgumentException(); // crash; logical error

            string LastSeen = tokens[0];
            int count = 0;
            foreach (var tok in tokens)
            {
                if (tok == LastSeen)
                {
                    count++;
                    if (count == 4)
                    {
                        if (tok != Token)
                            throw new ArgumentException(); // crash : Logic error - enemy can't win on player's turn
                        return true;
                    }
                }
                else
                {
                    LastSeen = tok;
                    count = 1;
                }
            }
            return false;
        }
    }
}
