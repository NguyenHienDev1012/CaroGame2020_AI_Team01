using System.Drawing;

namespace CaroGame2020_AI_Team01.Model
{
    public class EvalBoard
    {
        public int rows, columns;
        public int[,] EBoard;
        public int evaluationBoard = 0;

        public EvalBoard(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            EBoard = new int[rows, columns];
            // ResetBoard();
        }

        public void resetBoard()
        {
            for (int r = 0; r < rows; r++)
            for (int c = 0; c < columns; c++)
                EBoard[r, c] = 0;
        }

        public void setPosition(int x, int y, int diem)
        {
            EBoard[x, y] = diem;
        }

        public int[] MaxPos()
        {
            int Max = 0; // diem max 
            int[] p = new int[2];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (EBoard[i, j] > Max)
                    {
                        p[0] = i;
                        p[1] = j;
                        Max = EBoard[i, j];
                    }
                }
            }

            if (Max == 0)
            {
                return null;
            }

            evaluationBoard = Max;
            return p;
        }
    }
}