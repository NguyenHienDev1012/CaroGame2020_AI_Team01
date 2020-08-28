using System.Collections.Generic;
using System.Drawing;

namespace CaroGame2020_AI_Team01.Model
{
    public class BoardState
    {
        // Mang luu lai cac trang thai cac quan co
        public List<List<Field>> matrix_field { get; set; }
        public EvalBoard EvalBoard; // Bang Diem danh gia toan bo bang co

        // chieu rong cua ban co
        public int rows;

        // chieu cao cua ban co
        public int columns;

        // khoi tao
        public BoardState(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            EvalBoard = new EvalBoard(rows, columns);
        }

        public BoardState(EvalBoard evalBoard, int rows, int columns, List<List<Field>> matrixField)
        {
            EvalBoard = evalBoard;
            this.rows = rows;
            this.columns = columns;
            matrix_field = matrixField;
        }

        // reset ban co
        public void resetBoard()
        {
            matrix_field.Clear();
        }

        // Check chien thang
        public int checkEnd(int row, int col)
        {
            int r = 0, c = 0;
            int i;
            bool human, pc;
            // Check hang ngang
            while (c < columns - 4)
            {
                human = true;
                pc = true;
                for (i = 0; i < 5; i++)
                {
                    if (matrix_field[row][c + i].Mark != Cons.MARK[1])
                        human = false;
                    if (matrix_field[row][c + i].Mark != Cons.MARK[0])
                        pc = false;
                }

                if (human)
                    return 1;
                if (pc)
                    return 0;
                c++;
            }

            // Check  hang doc
            while (r < rows - 4)
            {
                human = true;
                pc = true;
                for (i = 0; i < 5; i++)
                {
                    if (matrix_field[r + i][col].Mark != Cons.MARK[1])
                        human = false;
                    if (matrix_field[r + i][col].Mark != Cons.MARK[0])
                        pc = false;
                }

                if (human)
                    return 1;
                if (pc)
                    return 0;
                r++;
            }

            // Check duong cheo xuong
            r = row;
            c = col;
            while (r < rows - 4 && c < columns - 4)
            {
                human = true;
                pc = true;
                for (i = 0; i < 5; i++)
                {
                    if (matrix_field[r + i][c + i].Mark != Cons.MARK[1])
                        human = false;
                    if (matrix_field[r + i][c + i].Mark != Cons.MARK[0])
                        pc = false;
                }

                if (human)
                    return 1;
                if (pc)
                    return 0;
                r++;
                c++;
            }

            // Check duong cheo len
            r = row;
            c = col;
            while (r >= 4 && c < rows - 4)
            {
                human = true;
                pc = true;
                for (i = 0; i < 5; i++)
                {
                    if (matrix_field[r - i][c + i].Mark != Cons.MARK[1])
                        human = false;
                    if (matrix_field[r - i][c + i].Mark != Cons.MARK[0])
                        pc = false;
                }

                if (human)
                    return 1;
                if (pc)
                    return 0;
                r--;
                c++;
            }

            return 0;
        }

        // Lay trang thai cua quan co tai 1 toa do xac dinh
        public Image getPosition(int x, int y)
        {
            return matrix_field[x][y].Mark;
        }

        // set trang thai cho 1 quan co xac dinh
        public void setPosition(int x, int y, Image player)
        {
            matrix_field[x][y].Mark = player;
        }
    }
}