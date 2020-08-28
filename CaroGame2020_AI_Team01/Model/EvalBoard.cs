using System.Collections.Generic;
using System.Drawing;

namespace CaroGame2020_AI_Team01.Model
{
    public class EvalBoard
    {
        public int rows, columns;
        public int[,] EBoard; // Mang luu tat ca diem
        public int maxScore = 0; // Diem max hien tai

        public EvalBoard(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            EBoard = new int[rows, columns];
        }

        public void resetBoard()
        {
            for (int r = 0; r < rows; r++)
            for (int c = 0; c < columns; c++)
                EBoard[r, c] = 0;
            // EBoard = new int[rows, columns];
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
            maxScore = Max;
            return p;
        }

        public List<int[]> listMove()
        {
            List<int[]> rs = new List<int[]>();
            for (int i = 0; i <5; i++)
            {
                int[] point = MaxPos();
                if(point==null) break;
                rs.Add(point);
                EBoard[rs[i][0],rs[i][1]] = 0;
            }

            return rs;
        }
    }
}