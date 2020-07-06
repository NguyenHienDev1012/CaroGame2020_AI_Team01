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
        private OptionGame _optionGame = null;
        private TimeCoolDown timeCoolDown = null;
        private bool isEndGame = false;
        private Stack<Field> undo = null;

        public Caro_Manager(Panel pnlBoard, OptionPlayer _optionPlayer, OptionGame _optionGame,
            TimeCoolDown timeCoolDown)
        {
            this._optionGame = _optionGame;
            this._optionPlayer = _optionPlayer;
            this.pnlBoard = pnlBoard;
            this.pnlBoard.Enabled = false;
            this._optionGame.NewGame.Enabled = false;
            this.timeCoolDown = timeCoolDown;
            this.undo = new Stack<Field>();
            _optionGame.Start.Click += start_Click;
            _optionGame.NewGame.Click += newGame_Click;
            _optionPlayer.BtnUndo.Click += Undo_Click;
            timeCoolDown.MyTimeCoolDown.Tick += timeCoolDown_Tick;
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

        private int getMode()
        {
            int result = 0;
            foreach (RadioButton rdb in _optionGame.PnlMode.Controls)
            {
                if (rdb != null)
                {
                    if (rdb.Checked)
                    {
                        result = _optionGame.PnlMode.Controls.IndexOf(rdb);
                    }
                }
            }

            return result;
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
            _optionPlayer.TbName.Text = players[currentPlayer].Name;
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

            return countLeft + countRight >= Cons.RULE - 1;
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

            return countTop + countBottom >= Cons.RULE - 1;
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

            return countTop + countBottom >= Cons.RULE - 1;
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

            return countTop + countBottom >= Cons.RULE - 1;
        }

        private void EndGame(Player player)
        {
            isEndGame = true;
            timeCoolDown.PgbCoolDown.Value = 0;
            timeCoolDown.MyTimeCoolDown.Stop();
            MessageBox.Show(player.Name + " Win Game");
            ActiveOption();
            this._optionGame.NewGame.Enabled = true;
        }

        private void ActiveOption()
        {
            pnlBoard.Enabled = !pnlBoard.Enabled;
            _optionGame.Start.Enabled = !_optionGame.Start.Enabled;
            _optionGame.NewGame.Enabled = !_optionGame.NewGame.Enabled;
            _optionGame.PnlMode.Enabled = !_optionGame.PnlMode.Enabled;
            _optionPlayer.BtnUndo.Enabled = false;
        }


        public void field_Click(Object sender, EventArgs e)
        {
            Field field = sender as Field;
            if (field.BackgroundImage == null)
            {
                field.BackgroundImage = players[currentPlayer].Mark;
                timeCoolDown.PgbCoolDown.Value = 0;
                timeCoolDown.MyTimeCoolDown.Start();
                undo.Push(field);
                _optionPlayer.BtnUndo.Enabled = true;
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

        public void start_Click(Object sender, EventArgs e)
        {
            int mode = getMode();
            players = new List<Player>();
            string player1;
            string player2;
            if (Cons.MODE[mode].Equals("1 vs 1"))
            {
                FormInputNamePlayer f_Input = new FormInputNamePlayer();
                f_Input.ShowDialog();
                player1 = f_Input.Player1;
                player2 = f_Input.Player2;
                if (player1 != null && player2 != null)
                {
                    players.Add(new Player(player1, Cons.MARK[0]));
                    players.Add(new Player(player2, Cons.MARK[1]));
                    currentPlayer = 0;
                    _optionPlayer.TbName.Text = players[currentPlayer].Name;
                    _optionPlayer.PnlValue.BackgroundImage = Cons.MARK[currentPlayer];
                    timeCoolDown.MyTimeCoolDown.Start();
                    ActiveOption();
                }
            }
            else if (Cons.MODE[mode].Equals("AI"))
            {
            }
            else
            {
            }

            if (isEndGame)
            {
                newGame();
                _optionGame.NewGame.Enabled = true;
                isEndGame = false;
            }
        }

        public void newGame_Click(Object sender, EventArgs e)
        {
            newGame();
            ActiveOption();
            isEndGame = false;
        }

        private void newGame()
        {
            timeCoolDown.PgbCoolDown.Value = 0;
            timeCoolDown.MyTimeCoolDown.Stop();
            pnlBoard.Controls.Clear();
            matrix_field = new List<List<Field>>();
            DrawCaroBoard();
        }

        private void timeCoolDown_Tick(object sender, EventArgs e)
        {
            timeCoolDown.PgbCoolDown.PerformStep();
            if (timeCoolDown.PgbCoolDown.Value >= timeCoolDown.PgbCoolDown.Maximum)
            {
                timeCoolDown.MyTimeCoolDown.Stop();
                EndGame(players[currentPlayer == 0 ? 1 : 0]);
            }
        }

        private void Undo_Click(Object sender, EventArgs e)
        {
            if (undo.Count != 0)
            {
                Field field = undo.Pop();
                Point location = getLocationField(field);
                field.BackgroundImage = null;
                currentPlayer = currentPlayer == 0 ? 1 : 0;
                _optionPlayer.BtnUndo.Enabled = false;
            }
        }
    }
}