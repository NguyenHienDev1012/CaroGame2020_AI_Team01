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
        private OptionGame _optionGame = null;
        private List<List<Field>> matrix_field = null;
        private List<Player> players = null;
        private TimeCoolDown timeCoolDown = null;
        private Stack<Field> undo = null;
        private Panel pnlBoard = null;
        private int currentPlayer;
        private bool isEndGame = false;
        string player1;
        string player2;
        private int mode = 0; // 0: 11, 1:AI
        BoardState boardState = new BoardState(Cons.ROWS,Cons.COLUMNS);

        public Caro_Manager(Panel pnlBoard, OptionPlayer _optionPlayer, OptionGame _optionGame,
            TimeCoolDown timeCoolDown)
        {
            this._optionGame = _optionGame;
            this._optionPlayer = _optionPlayer;
            this.pnlBoard = pnlBoard;
            this.pnlBoard.Enabled = false;
            this.undo = new Stack<Field>();
            _optionGame.BtnStart.Click += start_Click;
            this._optionGame.BtnNewGame.Enabled = false;
            _optionGame.BtnNewGame.Click += newGame_Click;
            _optionPlayer.BtnUndo.Click += Undo_Click;
            this.timeCoolDown = timeCoolDown;
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
                    Field field = new Field(Cons.F_WIDTH, Cons.F_HEIGHT);
                    field.Location = new Point(location_old_x, location_old_y);
                    field.Click += field_Click;
                    location_old_x += Cons.F_WIDTH;
                    pnlBoard.Controls.Add(field);
                    matrix_field[i].Add(field);
                    field.Position = getLocationField(field, i);
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

        private Point getLocationField(Field field, int row)
        {
            int y = matrix_field[row].IndexOf(field);
            return new Point(row, y);
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
            int countLeft = 0;
            int countRight = 0;
            for (int y = field.Position.Y - 1; y >= 0; y--) //tai vi tri do chay ve ben trai
            {
                if (matrix_field[field.Position.X][y].Mark == matrix_field[field.Position.X][field.Position.Y].Mark)
                {
                    countLeft++;
                }
                else
                {
                    break;
                }
            }

            for (int y = field.Position.Y + 1; y < Cons.COLUMNS; y++) //tai vi tri do chay ve ben phai
            {
                if (matrix_field[field.Position.X][y].Mark == matrix_field[field.Position.X][field.Position.Y].Mark)
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
            int countTop = 0;
            int countBottom = 0;
            for (int x = field.Position.X - 1; x >= 0; x--) //tai vi tri do chay len tren
            {
                if (matrix_field[x][field.Position.Y].Mark == matrix_field[field.Position.X][field.Position.Y].Mark)
                {
                    countTop++;
                }
                else
                {
                    break;
                }
            }

            for (int x = field.Position.X + 1; x < Cons.ROWS; x++) //tai vi tri do chay xuong duoi
            {
                if (matrix_field[x][field.Position.Y].Mark == matrix_field[field.Position.X][field.Position.Y].Mark)
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
            int countTop = 0;
            int countBottom = 0;
            for (int i = 1; i <= field.Position.X; i++) //tai vi tri do chay len tren
            {
                if (field.Position.X - i < 0 || field.Position.Y - i < 0) break;
                if (matrix_field[field.Position.X - i][field.Position.Y - i].Mark ==
                    matrix_field[field.Position.X][field.Position.Y].Mark)
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
                if (field.Position.X + i >= Cons.ROWS || field.Position.Y + i >= Cons.COLUMNS) break;
                if (matrix_field[field.Position.X + i][field.Position.Y + i].Mark ==
                    matrix_field[field.Position.X][field.Position.Y].Mark)
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
            int countTop = 0;
            int countBottom = 0;
            for (int i = 1; i <= field.Position.X; i++) //tai vi tri do chay len tren x-- y++
            {
                if (field.Position.X - i < 0 || field.Position.Y + i >= Cons.COLUMNS) break;
                if (matrix_field[field.Position.X - i][field.Position.Y + i].Mark ==
                    matrix_field[field.Position.X][field.Position.Y].Mark)
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
                if (field.Position.X + i >= Cons.ROWS || field.Position.Y - i < 0) break;
                if (matrix_field[field.Position.X + i][field.Position.Y - i].Mark ==
                    matrix_field[field.Position.X][field.Position.Y].Mark)
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
            ActiveOption(false);
            this._optionGame.BtnNewGame.Enabled = true;
        }

        private void ActiveOption(bool ToF)
        {
            // pnlBoard.Enabled = !pnlBoard.Enabled;
            // _optionGame.BtnStart.Enabled = !_optionGame.BtnStart.Enabled;
            // _optionGame.BtnNewGame.Enabled = !_optionGame.BtnNewGame.Enabled;
            // _optionGame.PnlMode.Enabled = !_optionGame.PnlMode.Enabled;
            pnlBoard.Enabled = !pnlBoard.Enabled;
            _optionGame.BtnNewGame.Enabled = !_optionGame.BtnNewGame.Enabled;
            _optionGame.BtnStart.Enabled = ToF;
            _optionGame.PnlMode.Enabled = ToF;
            _optionPlayer.BtnUndo.Enabled = false;
        }


        public void field_Click(Object sender, EventArgs e)
        {
            if (players == null || players.Count == 0) return;
            Field field = sender as Field;
            if (field.Mark == null)
            {
                if (Cons.MODE[getMode()].Equals("1 vs 1"))
                {
                    field.Mark = (players[currentPlayer].Mark);
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
                else if (Cons.MODE[getMode()].Equals("AI"))
                {
                    if (currentPlayer == 1)
                    {
                        field.Mark = (players[currentPlayer].Mark);
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
                            ComputerPlay();
                        }
                    }
                }
            }
        }

        public int[,] convertToInt()
        {
            int[,] rs = new int[Cons.ROWS, Cons.COLUMNS];
            for (int i = 0; i < Cons.ROWS; i++)
            {
                for (int j = 0; j < Cons.COLUMNS; j++)
                {
                    if (matrix_field[i][j].Mark == Cons.MARK[0])
                    {
                        rs[i, j] = 2;
                    }
                    else if (matrix_field[i][j].Mark == Cons.MARK[1])
                    {
                        rs[i, j] = 1;
                    }
                    else
                    {
                        rs[i, j] = 0;
                    }
                }
            }
            return rs;
        }

        private void ComputerPlay()
        {
            boardState.BoardArr = convertToInt();
            ComputerPlayer c= new ComputerPlayer(boardState);
            Field fi = c.AI();
            // AI com = new AI();
            // Field fi = com.AIBestMove(matrix_field, 1, true);
            matrix_field[fi.Position.X][fi.Position.Y].Mark = fi.Mark;
            if (checkWinGame(fi))
            {
                EndGame(players[currentPlayer]);
            }
            else
            {
                changePlayer();
            }
        }

        public void start_Click(Object sender, EventArgs e)
        {
            int mode = getMode();
            currentPlayer = 0;
            if (Cons.MODE[mode].Equals("1 vs 1"))
            {
                mode = 0;
                players = new List<Player>();
                FormInputNamePlayerSolo f_Input = new FormInputNamePlayerSolo();
                f_Input.ShowDialog();
                player1 = f_Input.Player1;
                player2 = f_Input.Player2;
                if (player1 != null && player2 != null)
                {
                    players.Add(new Player(player1, Cons.MARK[0]));
                    players.Add(new Player(player2, Cons.MARK[1]));
                    _optionPlayer.TbName.Text = players[currentPlayer].Name;
                    _optionPlayer.PnlValue.BackgroundImage = Cons.MARK[currentPlayer];
                    timeCoolDown.MyTimeCoolDown.Start();
                    ActiveOption(false);
                }
            }
            else if (Cons.MODE[mode].Equals("AI"))
            {
                mode = 1;
                // 0 COM / 1 Player
                FormInputNameAI f_input = new FormInputNameAI();
                f_input.ShowDialog();
                player2 = f_input.Player;
                if (player2 != null)
                {
                    setFirstAI();
                }
            }
            else
            {
                MessageBox.Show("Chưa làm LAN");
            }

            if (isEndGame)
            {
                newGame();
                _optionGame.BtnNewGame.Enabled = true;
                isEndGame = false;
            }
        }

        public void newGame_Click(Object sender, EventArgs e)
        {
            ActiveOption(true);
            isEndGame = false;
            newGame();
        }

        private void newGame()
        {
            currentPlayer = 0;
            timeCoolDown.PgbCoolDown.Value = 0;
            timeCoolDown.MyTimeCoolDown.Stop();
            pnlBoard.Controls.Clear();
            matrix_field = new List<List<Field>>();
            DrawCaroBoard();
            if (mode == 1)
            {
                setFirstAI();
            }
        }

        private void setFirstAI()
        {
            players = new List<Player>();
            player1 = "Computer";
            if (player2 == null) player2 = "AI";
            int x = Cons.ROWS / 2 - 1;
            int y = Cons.COLUMNS / 2 - 1;
            matrix_field[x][y].Mark = Cons.MARK[0];
            currentPlayer = 1;
            players.Add(new Player(player1, Cons.MARK[0]));
            players.Add(new Player(player2, Cons.MARK[1]));
            _optionPlayer.TbName.Text = players[currentPlayer].Name;
            _optionPlayer.PnlValue.BackgroundImage = Cons.MARK[currentPlayer];
            timeCoolDown.MyTimeCoolDown.Start();
            ActiveOption(false);
            pnlBoard.Enabled = true;
        }

        private void timeCoolDown_Tick(object sender, EventArgs e)
        {
            // timeCoolDown.PgbCoolDown.PerformStep();
            // if (timeCoolDown.PgbCoolDown.Value >= timeCoolDown.PgbCoolDown.Maximum)
            // {
            //     timeCoolDown.MyTimeCoolDown.Stop();
            //     EndGame(players[currentPlayer == 0 ? 1 : 0]);
            // }
        }

        private void Undo_Click(Object sender, EventArgs e)
        {
            if (undo.Count != 0)
            {
                Field field = undo.Pop();
                field.Mark = null;
                currentPlayer = currentPlayer == 0 ? 1 : 0;
                _optionPlayer.BtnUndo.Enabled = false;
            }
        }
    }
}