using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectFour.Enums;

namespace ConnectFour
{
    public class GameBoard
    {
        private List<List<string>> columns = null;
        private int rows = 0;
        private int cols = 0;
        public Players? Winner { get; private set; } = null;

        /// <summary>
        /// creates an empty gameboard of the specified dimensions
        /// </summary>
        public GameBoard(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            columns = new List<List<string>>();
            for (int i = 0; i < cols; i++)
            {
                List<string> column = new List<string>();
                for (int j = 0; j < rows; j++)
                {
                    column.Add("o");
                }
                columns.Add(column);
            }
        }

        /// <summary>
        /// Attempts to modify the board according to the player's wishes. If it fails then
        /// MoveResult is set to Invalid. If it detecte a victory then MoveResult is set to
        /// GameOver
        /// </summary>
        public MoveResult TryModifyBoard(int move, Players whoseTurn)
        {
            int col = move - 1;
            #region ValidityCheck
            if (move > cols)
                return MoveResult.Invalid;
            List<string> columnToModify = columns[col];
            if (!columnToModify.Any((ele) => ele == "o"))
                return MoveResult.Invalid;
            #endregion

            string token = whoseTurn == Players.Yellow ? "y" : "r";
            int ind = columnToModify.IndexOf("o");
            columns[col][ind] = token;

            // set the winner
            MoveResult retVal = DetectGameEnd(col, ind) ? MoveResult.GameOver : MoveResult.Valid;
            if (retVal == MoveResult.GameOver && Winner != Players.Nobody)
                Winner = whoseTurn;

            return retVal;
        }

        /// <summary>
        /// Detects the victory condition of connect 4, if there are 4 in a row horizontally, 
        /// vertically or along a diagonal. Game is also over if no more moves can be made
        /// </summary>
        private bool DetectGameEnd(int col, int row)
        {
            if (CheckVert(col, row) || CheckHoriz(col, row) || CheckDiag1(col, row) || CheckDiag2(col, row))
            {
                return true;
            }

            return CheckDraw(rows);
        }

        /// <summary>
        /// check the \ direction for 4 in a row
        /// </summary>
        private bool CheckDiag2(int col, int row)
        {
            string token = columns[col][row];
            List<string> tokens = new List<string>();
            for (int i = -3; i <= 3; i++)
            {
                // bounds check
                if (col + i < 0 || col + i >= cols || row - i < 0 || row - i >= rows)
                    continue;

                // gather tokens
                tokens.Add(columns[col + i][row - i]);
            }

            // win condition
            return HasFourInARow(tokens, token);
        }

        /// <summary>
        /// check the / direction for 4 in a row
        /// </summary>
        private bool CheckDiag1(int col, int row)
        {
            string token = columns[col][row];
            List<string> tokens = new List<string>();
            for (int i = -3; i <= 3; i++)
            {
                // bounds check
                if (col + i < 0 || col + i >= cols || row + i < 0 || row + i >= rows)
                    continue;

                // gather tokens
                tokens.Add(columns[col + i][row + i]);
            }

            // win condition
            return HasFourInARow(tokens, token);
        }

        /// <summary>
        /// check the -- direction for 4 in a row
        /// </summary>
        private bool CheckHoriz(int col, int row)
        {
            string token = columns[col][row];
            List<string> tokens = new List<string>();
            for (int i = -3; i <= 3; i++)
            {
                // bounds check
                if (col + i < 0 || col + i >= cols)
                    continue;

                // gather tokens
                tokens.Add(columns[col + i][row]);
            }

            // win condition
            return HasFourInARow(tokens, token);
        }

        /// <summary>
        /// check the | direction for 4 in a row
        /// </summary>
        private bool CheckVert(int col, int row)
        {
            string token = columns[col][row];
            List<string> tokens = new List<string>();
            for (int i = -3; i <= 3; i++)
            {
                // bounds check
                if (row + i < 0 || row + i >= rows)
                    continue;

                // gather tokens
                tokens.Add(columns[col][row + i]);
            }

            // win condition
            return HasFourInARow(tokens, token);
        }

        /// <summary>
        /// Checks whether or not there are 4 consecutive tokens in this list
        /// </summary>
        private bool HasFourInARow(List<string> tokens, string token)
        {
            string LastSeen = tokens[0];
            int count = 0;
            foreach (var tok in tokens)
            {
                if (tok == LastSeen)
                {
                    count++;
                    if (count == 4)
                    {
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

        /// <summary>
        /// check if the board is full
        /// </summary>
        private bool CheckDraw(int rows)
        {
            foreach (var column in columns)
            {
                if (column[rows - 1] == "o")
                    return false;
            }
            Winner = Players.Nobody;
            return true;
        }

        /// <summary>
        /// a gameboard's printable string goes from the top row (last) to the bottom (first)
        /// </summary>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = rows - 1; i >= 0; i--)
            {
                foreach (var column in columns)
                {
                    sb.Append($"{column[i]} ");
                }
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }
    }
}
