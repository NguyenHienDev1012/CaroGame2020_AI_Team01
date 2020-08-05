using System.Drawing;

namespace CaroGame2020_AI_Team01.Model
{
    public class ScoreBoard
    {
        public int row, column;
        public int[,] sBoard;
        public int scoreOfBoard = 0;

        public int[,] SBoard
        {
            get => sBoard;
            set => sBoard = value;
        }

        public ScoreBoard(int row, int column)
        {
            this.row = row;
            this.column = column;
            sBoard = new int[row, column];
        }

        public void resetBoard()
        {
            for (int r = 0; r < row; r++)
            for (int c = 0; c < column; c++)
                sBoard[r, c] = 0;
        }

        public void setPosition(int x, int y, int diem)
        {
            sBoard[x, y] += diem;
        }

        public Point MaxPos()
        {
            int Max = 0; // diem max 
            Point point = new Point();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (sBoard[i, j] > Max)
                    {
                        point.X = i;
                        point.Y = j;
                        Max = sBoard[i, j];
                    }
                }
            }

            if (Max == 0)
            {
                return new Point(-1, -1);
            }

            scoreOfBoard = Max;
            return point;
        }
    }
}