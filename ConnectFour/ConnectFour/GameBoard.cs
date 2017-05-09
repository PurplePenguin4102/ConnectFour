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
        public Players? Winner { get; set; } = null;
        private Validator rules = new Validator();

        /// <summary>
        /// creates an empty gameboard of the specified dimensions
        /// </summary>
        public GameBoard(int rows, int cols)
        {
            if (rows < 0 || cols < 0)
                throw new ArgumentException(); // logical error, crash

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
            if (!rules.ValidateMoveAgainstBoard(move, columns))
                return MoveResult.Invalid;

            int col = move - 1;
            string token = whoseTurn == Players.Yellow ? "y" : "r";
            int ind = columns[col].IndexOf("o");
            columns[col][ind] = token;

            // set the winner
            return DetectGameEnd(col, ind, whoseTurn) ? MoveResult.GameOver : MoveResult.Valid;
        }

        /// <summary>
        /// Detects the victory condition of connect 4, if there are 4 in a row horizontally, 
        /// vertically or along a diagonal. Game is also over if no more moves can be made
        /// </summary>
        private bool DetectGameEnd(int col, int row, Players whoseTurn)
        {
            // set up line for use this iteration
            var line = new LineCheck()
            {
                Rows = rows,
                Cols = cols,
                Columns = columns,
                Token = columns[col][row]
            };

            // grab all directions around token
            var possibleWinDirections = new List<List<string>>
            {
                line.PickVert(col, row),
                line.PickHoriz(col, row),
                line.PickDiag1(col, row),
                line.PickDiag2(col, row)
            };

            // test victory condition
            if (possibleWinDirections.Any(tokens => line.HasFourInARow(tokens)))
            {
                Winner = whoseTurn;
                return true;
            }

            // test for draw
            if (line.CheckDraw())
            {
                Winner = Players.Nobody;
                return true;
            }
            return false;
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
