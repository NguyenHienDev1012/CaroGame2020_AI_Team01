using System.Drawing;
using System.Windows.Forms;
using CaroGame2020_AI_Team01.Model;

namespace CaroGame2020_AI_Team01
{
    public partial class ShowScoreBoard : Form
    {
        public ShowScoreBoard(int[,] scoreBoard)
        {
            InitializeComponent();
            draw(scoreBoard);
        }

        private void draw(int[,] scoreBoard)
        {
            int location_old_x = 0;
            int location_old_y = 0;
            for (int i = 0; i < Cons.ROWS; i++)
            {
                for (int j = 0; j < Cons.COLUMNS; j++)
                {
                    Field field = new Field(70, Cons.F_HEIGHT);
                    field.Location = new Point(location_old_x, location_old_y);
                    field.Text = scoreBoard[i,j]+"";
                    if (i == (Cons.ROWS / 2 - 1) && j == (Cons.COLUMNS / 2 - 1))
                    {
                        field.BackColor = Color.Aqua;
                    }
                    location_old_x += 80;
                    pnlMain.Controls.Add(field);
                }

                location_old_x = 0;
                location_old_y += Cons.F_HEIGHT;
            }
        }
    }
}