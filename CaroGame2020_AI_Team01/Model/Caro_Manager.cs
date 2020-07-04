using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaroGame2020_AI_Team01.Model
{
    public class Caro_Manager
    {
        private OptionPlayer _optionPlayer = null;
        private Panel pnlBoard = null;
        private List<List<Field>> matrix_field = null;
        private List<Player> players = null;
        private int currentPlayer;

        public Caro_Manager(Panel pnlBoard, OptionPlayer _optionPlayer)
        {
            this._optionPlayer = _optionPlayer;
            this.pnlBoard = pnlBoard;
            players = new List<Player>()
            {
                new Player("ThanhTri", Image.FromFile(Cons.FULL_PATH + "o_color.png")),
                new Player("Nevir", Image.FromFile(Cons.FULL_PATH + "x_color.png"))
            };
            currentPlayer = 0; //mac dinh nguoi choi 0 choi truoc
            this._optionPlayer.PnlValue.BackgroundImage = players[currentPlayer].Mark;
            _optionPlayer.TbName.Text =  players[currentPlayer].Name;
        }


        public void DrawCaroBoard()
        {
            matrix_field = new List<List<Field>>();
            int location_old_x = 0;
            int location_old_y = 0;
            for (int i = 0; i < Cons.ROWS; i++)
            {
                matrix_field.Add(new List<Field>());
                for (int j = 0; j < Cons.COLUMNS; j++)
                {
                    Field field = new Field(Cons.F_HEIGHT, Cons.F_WIDTH);
                    field.Location = new Point(location_old_x, location_old_y);
                    field.BackgroundImageLayout = ImageLayout.Stretch;
                    field.Tag = i.ToString();
                    field.Click += field_Click;
                    location_old_x += Cons.F_WIDTH;
                    pnlBoard.Controls.Add(field);
                    matrix_field[i].Add(field);
                }

                location_old_x = 0;
                location_old_y += Cons.F_HEIGHT;
            }
        }

        private Point getLocationField(Field field)
        {
            int x = Convert.ToInt32(field.Tag);
            int y = matrix_field[x].IndexOf(field);
            Point point = new Point(x, y);
            return point;
        }

        private void changePlayer()
        {
            currentPlayer = currentPlayer == 0 ? 1 : 0;
            //Thay doi ten nguoi choi
            _optionPlayer.TbName.Text =  players[currentPlayer].Name;
            //Thay doi icon value
            _optionPlayer.PnlValue.BackgroundImage = players[currentPlayer].Mark;
        }

        private bool checkWinGame(Field field)
        {
            if (checkHorizontal(field) || checkVertical(field) || checkDiagonalPrimary(field) ||
                checkDiagonalSub(field))
            {
                return true;
            }

            return false;
        }

        private bool checkHorizontal(Field field) //ngang
        {
            Point location = getLocationField(field);
            int countLeft = 0;
            int countRight = 0;
            for (int y = location.Y - 1; y >= 0; y--) //tai vi tri do chay ve ben trai
            {
                if (matrix_field[location.X][y].BackgroundImage == matrix_field[location.X][location.Y].BackgroundImage)
                {
                    countLeft++;
                }
                else
                {
                    break;
                }
            }

            for (int y = location.Y + 1; y < Cons.COLUMNS; y++) //tai vi tri do chay ve ben phai
            {
                if (matrix_field[location.X][y].BackgroundImage == matrix_field[location.X][location.Y].BackgroundImage)
                {
                    countRight++;
                }
                else
                {
                    break;
                }
            }

            return countLeft + countRight >= Cons.RULE-1;
        }

        private bool checkVertical(Field field) //doc
        {
            Point location = getLocationField(field);
            int countTop = 0;
            int countBottom = 0;
            for (int x = location.X - 1; x >= 0; x--) //tai vi tri do chay len tren
            {
                if (matrix_field[x][location.Y].BackgroundImage == matrix_field[location.X][location.Y].BackgroundImage)
                {
                    countTop++;
                }
                else
                {
                    break;
                }
            }

            for (int x = location.X + 1; x < Cons.ROWS; x++) //tai vi tri do chay xuong duoi
            {
                if (matrix_field[x][location.Y].BackgroundImage == matrix_field[location.X][location.Y].BackgroundImage)
                {
                    countBottom++;
                }
                else
                {
                    break;
                }
            }

            return countTop + countBottom >= Cons.RULE-1;
        }

        private bool checkDiagonalPrimary(Field field) //cheo chinh
        {
            Point location = getLocationField(field);
            int countTop = 0;
            int countBottom = 0;
            for (int i = 1; i <= location.X; i++) //tai vi tri do chay len tren
            {
                if (location.X - i < 0 || location.Y - i < 0) break;
                if (matrix_field[location.X - i][location.Y - i].BackgroundImage ==
                    matrix_field[location.X][location.Y].BackgroundImage)
                {
                    countTop++;
                }
                else
                {
                    break;
                }
            }

            for (int i = 1; i < Cons.ROWS; i++) //tai vi tri do chay xuong duoi
            {
                if (location.X + i >= Cons.ROWS || location.Y + i >= Cons.COLUMNS) break;
                if (matrix_field[location.X + i][location.Y + i].BackgroundImage ==
                    matrix_field[location.X][location.Y].BackgroundImage)
                {
                    countBottom++;
                }
                else
                {
                    break;
                }
            }

            return countTop + countBottom >= Cons.RULE-1;
        }

        private bool checkDiagonalSub(Field field) //cheo phu
        {
            Point location = getLocationField(field);
            int countTop = 0;
            int countBottom = 0;
            for (int i = 1; i <= location.X; i++) //tai vi tri do chay len tren x-- y++
            {
                if (location.X - i < 0 || location.Y + i >= Cons.COLUMNS) break;
                if (matrix_field[location.X - i][location.Y + i].BackgroundImage ==
                    matrix_field[location.X][location.Y].BackgroundImage)
                {
                    countTop++;
                }
                else
                {
                    break;
                }
            }

            //
            for (int i = 1; i < Cons.ROWS; i++) //tai vi tri do chay xuong duoi x++ y--
            {
                if (location.X + i >= Cons.ROWS || location.Y - i < 0) break;
                if (matrix_field[location.X + i][location.Y - i].BackgroundImage ==
                    matrix_field[location.X][location.Y].BackgroundImage)
                {
                    countBottom++;
                }
                else
                {
                    break;
                }
            }

            return countTop + countBottom >= Cons.RULE-1;
        }

        private void EndGame(Player player)
        {
            MessageBox.Show(player.Name + " Win Game");
            return;
        }
        public void field_Click(Object sender, EventArgs e)
        {
            Field field = sender as Field;
            if (field.BackgroundImage == null)
            {
                field.BackgroundImage = players[currentPlayer].Mark;
                if (checkWinGame(field))
                {
                    EndGame(players[currentPlayer]);
                }
                else
                {
                changePlayer();
                }
            }

            
        }
    }
}