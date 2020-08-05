using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CaroGame2020_AI_Team01.Model
{
    public class AI
    {
        //Dept
        private int depth = 5;

        //Mark
        private Image computerMark = Cons.MARK[0]; //o

        private Image HumanMark = Cons.MARK[1]; //x

        private Image MyArmy = null;

        private Image Enemy = null;

        private Point goPoint;
        private int _x;
        private int _y;

        //Score
        private int[] AScore = {0, 8, 56, 392, 2477, 19208,19208,19208,19208};

        private int[] DScore = {0, 4, 32, 325, 2048, 16384,16384,16384,16384};

        //Matrix
        private List<List<Field>> matrix_field;

        //ScoreBoard
        private ScoreBoard sBoard;

        public ScoreBoard SBoard
        {
            get => sBoard;
            set => sBoard = value;
        }

        public List<List<Field>> MatrixField
        {
            get => matrix_field;
            set => matrix_field = value;
        }

        public AI()
        {
        }

        public AI(List<List<Field>> matrixField)
        {
            matrix_field = matrixField;
            sBoard = new ScoreBoard(Cons.ROWS, Cons.COLUMNS);
        }

        public Field AIBestMove(List<List<Field>> stateBoard, int depth, bool isMaximingPlayer)
        {
            minimax(depth, stateBoard, isMaximingPlayer);
            return new Field(goPoint,computerMark);
            
        }
        public List<List<Field>> copyList(List<List<Field>> stateBoard)
        {
            List<List<Field>> newBoard = new List<List<Field>>();
            for (int i = 0; i < Cons.ROWS; i++)
            {
                List<Field> fields = new List<Field>();
                for (int j = 0; j < Cons.COLUMNS; j++)
                {
                    fields.Add(new Field(stateBoard[i][j].Position,stateBoard[i][j].Mark));
                }

                newBoard.Add(fields);
            }

            return newBoard;
        }

        public int minimax(int depth, List<List<Field>> stateBoard, bool isMaximingPlayer)
        {
            if (depth == 0)
            {
                return Heurustic(stateBoard, isMaximingPlayer);
            }
            if (isMaximingPlayer)
            {
                int temp = int.MinValue;
                for (int i = 0; i < Cons.ROWS; i++)
                {
                    for (int j = 0; j < Cons.COLUMNS; j++)
                    {
                        if (stateBoard[i][j].Mark == null)
                        {
                            List<List<Field>> newBoard =  copyList(stateBoard);
                            newBoard[i][j].Mark = computerMark;
                            _x = i;
                            _y = j;
                            int value = minimax(depth - 1, newBoard, false);
                            temp = Math.Max(temp, value);
                            if (temp < value)
                            {
                                temp = value;
                            goPoint = new Point(i, j);
                            }
                        }
                    }
                }

                return temp;
            }
            else
            {
                int temp = int.MaxValue;
                for (int i = 0; i < Cons.ROWS; i++)
                {
                    for (int j = 0; j < Cons.COLUMNS; j++)
                    {
                        if (stateBoard[i][j].Mark == null)
                        {
                            List<List<Field>> newBoard = copyList(stateBoard);
                            newBoard[i][j].Mark = HumanMark;
                            _x = i;
                            _y = j;
                            int value = minimax(depth - 1, newBoard, true);
                            if (temp > value)
                            {
                                temp = value;
                            }
                        }
                    }
                }

                return temp;
            }
        }

        #region Heuristic

        public int Heurustic(List<List<Field>> stateBoard, bool isMaximingPlayer)
        {
            this.matrix_field = stateBoard;
            if (isMaximingPlayer)
            {
                this.MyArmy = computerMark;
                this.Enemy = HumanMark;
            }
            else
            {
                this.MyArmy = HumanMark;
                this.Enemy = computerMark;
            }

            int Ascore = 0;
            int Dscore = 0;
            int MaxScore = 0;
            // for (int x = 0; x < Cons.ROWS; x++)
            // {
            //     for (int y = 0; y < Cons.COLUMNS; y++)
            //     {
                    // if (matrix_field[_x][_y].Mark != null) continue;
                    Ascore = AScoreSum(_x, _y);
                    Dscore = DScoreSum(_x, _y);
                    // MessageBox.Show((Ascore + "--" + Dscore));
                    int ScoreTMP = Ascore > Dscore ? Ascore : Dscore;
                    if (ScoreTMP >= MaxScore)
                    {
                        MaxScore = ScoreTMP;
                    }
            //     }
            // }

            return MaxScore;
        }

        #endregion

        #region MaxMove

        public Field MaxMove()
        {
            Field field = new Field();
            // int Ascore = 0;
            // int Dscore = 0;
            // int MaxScore = 0;
            // for (int x = 0; x < Cons.ROWS; x++)
            // {
            //     for (int y = 0; y < Cons.COLUMNS; y++)
            //     {
            //         if (matrix_field[x][y].Mark != null) continue;
            //         Ascore = AScoreSum(x, y);
            //         Dscore = DScoreSum(x, y);
            //         // MessageBox.Show((Ascore + "--" + Dscore));
            //         int ScoreTMP = Ascore > Dscore ? Ascore : Dscore;
            //         if (ScoreTMP >= MaxScore)
            //         {
            //             MaxScore = ScoreTMP;
            //             // sBoard.SBoard[x, y] = MaxScore;
            //             field = new Field();
            //             field.Mark = computerMark;
            //             field.Position = new Point(x, y);
            //         }
            //     }
            // }

            return field;
        }

        private int AScoreSum(int x, int y) //Tong Diem Tan Cong
        {
            int S_Horizontal = 0;
            int S_Vertical = 0;
            int S_DiagonalPrimary = 0;
            int S_DiagonalSub = 0;
            int AScore = 0;

            int myArmy = 0, enemy = 0;

            // int toRight = 0, toLeft = 0, toTop = 0, toBot = 0, TopLeft = 0, TopRight = 0, BotLeft = 0, BotRight = 0;

            #region Horizontal

            //Hori toRight
            for (int i = y + 1; i < Cons.COLUMNS; i++)
            {
                if (matrix_field[x][i].Mark == this.MyArmy)
                {
                    myArmy++;
                }
                else if (matrix_field[x][i].Mark == this.Enemy)
                {
                    enemy++;
                    break;
                }
                else
                {
                    if (i + 1 < Cons.COLUMNS)
                    {
                        if (matrix_field[x][i].Mark == this.MyArmy)
                        {
                            myArmy += 2;
                        }
                    }

                    break;
                }
            }

            //Hori toLeft
            for (int i = y - 1; i >= 0; i--)
            {
                if (matrix_field[x][i].Mark == this.MyArmy)
                {
                    myArmy++;
                }
                else if (matrix_field[x][i].Mark == this.Enemy)
                {
                    enemy++;
                    break;
                }
                else
                {
                    if (i - 1 >= 0)
                    {
                        if (matrix_field[x][i].Mark == this.MyArmy)
                        {
                            myArmy += 2;
                        }
                    }

                    break;
                }
            }

            if (myArmy >= 4)
            {
                AScore = this.AScore[5];
            }

            if (enemy == 2) return 0;
            AScore -= this.DScore[enemy];
            S_Horizontal += this.AScore[myArmy] + AScore;
            AScore = 0;
            myArmy = 0;
            enemy = 0;

            #endregion

            #region Vetical

            //Vertical toTop
            for (int i = x - 1; i >= 0; i--)
            {
                if (matrix_field[i][y].Mark == this.MyArmy)
                {
                    myArmy++;
                }
                else if (matrix_field[i][y].Mark == this.Enemy)
                {
                    enemy++;
                    break;
                }
                else
                {
                    if (i - 1 >= 0)
                    {
                        if (matrix_field[i][y].Mark == this.MyArmy)
                        {
                            myArmy += 2;
                        }
                    }

                    break;
                }
            }

            //Vertical toBot
            for (int i = x + 1; i < Cons.ROWS; i++)
            {
                if (matrix_field[i][y].Mark == this.MyArmy)
                {
                    myArmy++;
                }
                else if (matrix_field[i][y].Mark == this.Enemy)
                {
                    enemy++;
                    break;
                }
                else
                {
                    if (i + 1 < Cons.ROWS)
                    {
                        if (matrix_field[i][y].Mark == this.MyArmy)
                        {
                            myArmy += 2;
                        }
                    }

                    break;
                }
            }

            if (myArmy >= 4)
            {
                AScore = this.AScore[5];
            }

            if (enemy == 2) return 0;
            AScore -= this.DScore[enemy];
            S_Vertical += this.AScore[myArmy] + AScore;
            AScore = 0;
            myArmy = 0;
            enemy = 0;

            #endregion

            #region DiagonalPrimary

            //DiagonalPrimary TopLeft
            for (int i = 1; i <= x; i++)
            {
                if (x - i < 0 || y - i < 0) break;
                if (matrix_field[x - i][y - i].Mark == this.MyArmy)
                {
                    myArmy++;
                }

                if (matrix_field[x - i][y - i].Mark == this.Enemy)
                {
                    enemy++;
                    break;
                }
                else
                {
                    if (x - i >= 0 && y - i >= 0)
                    {
                        if (matrix_field[x - i][y - i].Mark == this.MyArmy)
                        {
                            myArmy += 2;
                        }
                    }

                    break;
                }
            }

            //DiagonalPrimary BotRight
            for (int i = 1; i < Cons.ROWS; i++)
            {
                if (x + i >= Cons.ROWS || y + i >= Cons.COLUMNS) break;
                if (matrix_field[x + i][y + i].Mark == this.MyArmy)
                {
                    myArmy++;
                }

                if (matrix_field[x + i][y + i].Mark == this.Enemy)
                {
                    enemy++;
                    break;
                }
                else
                {
                    if (x + i < Cons.ROWS && y + i < Cons.COLUMNS)
                    {
                        if (matrix_field[x + i][y + i].Mark == this.MyArmy)
                        {
                            myArmy += 2;
                        }
                    }

                    break;
                }
            }

            if (myArmy >= 4)
            {
                AScore = this.AScore[5];
            }

            if (enemy == 2) return 0;
            AScore -= this.DScore[enemy];
            S_DiagonalPrimary += this.AScore[myArmy] + AScore;
            AScore = 0;
            myArmy = 0;
            enemy = 0;

            #endregion

            #region DiagonalSub

            //DiagonalSub TopRight
            for (int i = 1; i <= x; i++)
            {
                if (x - i < 0 || y + i >= Cons.COLUMNS) break;
                if (matrix_field[x - i][y + i].Mark == this.MyArmy)
                {
                    myArmy++;
                }

                if (matrix_field[x - i][y + i].Mark == this.Enemy)
                {
                    enemy++;
                    break;
                }
                else
                {
                    if (x - i >= 0 && y + i < Cons.COLUMNS)
                    {
                        if (matrix_field[x - i][y + i].Mark == this.MyArmy)
                        {
                            myArmy += 2;
                        }
                    }

                    break;
                }
            }

            //DiagonalSub BotLeft
            for (int i = 1; i < Cons.ROWS; i++)
            {
                if (x + i >= Cons.ROWS || y - i < 0) break;
                if (matrix_field[x + i][y - i].Mark == this.MyArmy)
                {
                    myArmy++;
                }

                if (matrix_field[x + i][y - i].Mark == this.Enemy)
                {
                    enemy++;
                    break;
                }
                else
                {
                    if (x + i < Cons.ROWS && y - i >= 0)
                    {
                        if (matrix_field[x + i][y - i].Mark == this.MyArmy)
                        {
                            myArmy += 2;
                        }
                    }

                    break;
                }
            }

            if (myArmy >= 4)
            {
                AScore = this.AScore[5];
            }

            if (enemy == 2) return 0;
            AScore -= this.DScore[enemy];
            S_DiagonalSub += this.AScore[myArmy] + AScore;
            AScore = 0;
            myArmy = 0;
            enemy = 0;

            #endregion

            return S_Horizontal + S_Vertical + S_DiagonalPrimary + S_DiagonalSub;
        }

        private int DScoreSum(int x, int y) //Tong Diem Phong Ngu
        {
            int S_Horizontal = 0;
            int S_Vertical = 0;
            int S_DiagonalPrimary = 0;
            int S_DiagonalSub = 0;
            // int AScore = 0;
            int myArmy = 0, enemy = 0;

            // int toRight = 0, toLeft = 0, toTop = 0, toBot = 0, TopLeft = 0, TopRight = 0, BotLeft = 0, BotRight = 0;

            #region Horizontal

            //Hori toRight
            for (int i = y + 1; i < Cons.COLUMNS; i++)
            {
                if (matrix_field[x][i].Mark == this.MyArmy)
                {
                    myArmy++;
                    break;
                }
                else if (matrix_field[x][i].Mark == this.Enemy)
                {
                    enemy++;
                }
                else
                {
                    break;
                }
            }

            //Hori toLeft
            for (int i = y - 1; i >= 0; i--)
            {
                if (matrix_field[x][i].Mark == this.MyArmy)
                {
                    myArmy++;
                    break;
                }
                else if (matrix_field[x][i].Mark == this.Enemy)
                {
                    enemy++;
                }
                else
                {
                    break;
                }
            }

            S_Horizontal += this.DScore[enemy];
            myArmy = 0;
            enemy = 0;

            #endregion

            #region Vetical

            //Vertical toTop
            for (int i = x - 1; i >= 0; i--)
            {
                if (matrix_field[i][y].Mark == this.MyArmy)
                {
                    myArmy++;
                    break;
                }
                else if (matrix_field[i][y].Mark == this.Enemy)
                {
                    enemy++;
                }
                else
                {
                    break;
                }
            }

            //Vertical toBot
            for (int i = x + 1; i < Cons.ROWS; i++)
            {
                if (matrix_field[i][y].Mark == this.MyArmy)
                {
                    myArmy++;
                    break;
                }
                else if (matrix_field[i][y].Mark == this.Enemy)
                {
                    enemy++;
                }
                else
                {
                    break;
                }
            }

            S_Vertical += this.DScore[enemy];
            myArmy = 0;
            enemy = 0;

            #endregion

            #region DiagonalPrimary

            //DiagonalPrimary TopLeft
            for (int i = 1; i <= x; i++)
            {
                if (x - i < 0 || y - i < 0) break;
                if (matrix_field[x - i][y - i].Mark == this.MyArmy)
                {
                    myArmy++;
                    break;
                }

                if (matrix_field[x - i][y - i].Mark == this.Enemy)
                {
                    enemy++;
                }
                else
                {
                    break;
                }
            }

            //DiagonalPrimary BotRight
            for (int i = 1; i < Cons.ROWS; i++)
            {
                if (x + i >= Cons.ROWS || y + i >= Cons.COLUMNS) break;
                if (matrix_field[x + i][y + i].Mark == this.MyArmy)
                {
                    myArmy++;
                    break;
                }

                if (matrix_field[x + i][y + i].Mark == this.Enemy)
                {
                    enemy++;
                }
                else
                {
                    break;
                }
            }

            S_DiagonalPrimary += this.DScore[enemy];
            myArmy = 0;
            enemy = 0;

            #endregion

            #region DiagonalSub

            //DiagonalSub TopRight
            for (int i = 1; i <= x; i++)
            {
                if (x - i < 0 || y + i >= Cons.COLUMNS) break;
                if (matrix_field[x - i][y + i].Mark == this.MyArmy)
                {
                    myArmy++;
                    break;
                }

                if (matrix_field[x - i][y + i].Mark == this.Enemy)
                {
                    enemy++;
                }
                else
                {
                    break;
                }
            }

            //DiagonalSub BotLeft
            for (int i = 1; i < Cons.ROWS; i++)
            {
                if (x + i >= Cons.ROWS || y - i < 0) break;
                if (matrix_field[x + i][y - i].Mark == this.MyArmy)
                {
                    myArmy++;
                    break;
                }

                if (matrix_field[x + i][y - i].Mark == this.Enemy)
                {
                    enemy++;
                }
                else
                {
                    break;
                }
            }

            S_DiagonalSub += this.DScore[enemy];
            myArmy = 0;
            enemy = 0;

            #endregion

            return S_Horizontal + S_Vertical + S_DiagonalPrimary + S_DiagonalSub;
        }

        #endregion
    }
}