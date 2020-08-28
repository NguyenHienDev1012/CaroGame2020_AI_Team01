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

        //Score
        private int[] AScore = {0, 4, 27, 256, 1458};
        private int[] DScore = {0, 2, 9, 99, 769};

        private int _x = 0, _y = 0;

        private int[] goPoint = new int[2];

        //Matrix
        private List<List<Field>> matrix_field;

        public List<List<Field>> MatrixField
        {
            get => matrix_field;
            set => matrix_field = value;
        }

        public AI(List<List<Field>> matrixField)
        {
            matrix_field = matrixField;
        }

        public int[,] GetBoardMatrix(List<List<Field>> matrix_field)
        {
            int[,] board = new int[Cons.ROWS, Cons.COLUMNS];
            for (int i = 0; i < matrix_field.Count; i++)
            {
                for (int j = 0; j < matrix_field[i].Count; j++)
                {
                    if (matrix_field[i][j].Mark == computerMark)
                    {
                        board[i, j] = 1;
                    }
                    else if (matrix_field[i][j].Mark == HumanMark)
                    {
                        board[i, j] = 2;
                    }
                }
            }

            return board;
        }

        public List<int[]> GetPossibleMoves(int[,] boardState)
        {
            List<int[]> rs = new List<int[]>();
            int[] point = new int[2];
            for (int i = 0; i < Cons.ROWS; i++)
            {
                for (int j = 0; j < Cons.COLUMNS; j++)
                {
                    if (boardState[i, j] == 1 || boardState[i, j] == 2)
                    {
                        if (i - 1 > 0 && j - 1 > 0 && boardState[i - 1, j - 1] == 0)
                        {
                            point = new int[2];
                            point[0] = i - 1;
                            point[1] = j - 1;
                            rs.Add(point);
                        }

                        if (i - 1 > 0 && boardState[i - 1, j] == 0)
                        {
                            point = new int[2];
                            point[0] = i - 1;
                            point[1] = j;
                            rs.Add(point);
                        }

                        if (i - 1 > 0 && j + 1 < Cons.COLUMNS && boardState[i - 1, j + 1] == 0)
                        {
                            point = new int[2];
                            point[0] = i - 1;
                            point[1] = j + 1;
                            rs.Add(point);
                        }

                        if (j - 1 > 0 && boardState[i, j - 1] == 0)
                        {
                            point = new int[2];
                            point[0] = i;
                            point[1] = j - 1;
                            rs.Add(point);
                        }

                        if (i + 1 < Cons.ROWS && j - 1 > 0 && boardState[i + 1, j - 1] == 0)
                        {
                            point = new int[2];
                            point[0] = i + 1;
                            point[1] = j - 1;
                            rs.Add(point);
                        }

                        if (i + 1 < Cons.ROWS && boardState[i + 1, j] == 0)
                        {
                            point = new int[2];
                            point[0] = i + 1;
                            point[1] = j;
                            rs.Add(point);
                        }

                        if (i + 1 < Cons.ROWS && j + 1 < Cons.COLUMNS && boardState[i + 1, j + 1] == 0)
                        {
                            point = new int[2];
                            point[0] = i + 1;
                            point[1] = j + 1;
                            rs.Add(point);
                        }

                        if (j + 1 < Cons.COLUMNS && boardState[i, j + 1] == 0)
                        {
                            point = new int[2];
                            point[0] = i;
                            point[1] = j + 1;
                            rs.Add(point);
                        }
                    }
                }
            }

            return rs;
        }

        public Field MaxMove()
        {
            int[,] boardState = GetBoardMatrix(this.matrix_field);
            int a = Minimax(3, boardState, 0, 0, true);
            return new Field(new Point(goPoint[0], goPoint[1]), computerMark);
        }

        public int Minimax(int depth, int[,] boardState, int x, int y, bool isMaxPlayer)
        {
            if (depth == 0)
            {
                return Heuristic(boardState, x, y,!isMaxPlayer);
            }

            List<int[]> possibleMoves = GetPossibleMoves(boardState);
            if (possibleMoves.Count == 0) return 0;
            if (isMaxPlayer)
            {
                int maxscore = Int32.MinValue;
                for (int i = 0; i < possibleMoves.Count; i++)
                {
                    int[] move = possibleMoves[i];
                    if (boardState[move[0], move[1]] == 0)
                    {
                        boardState[move[0], move[1]] = 1;
                        // _x = i;_y = j;
                        int value = Minimax(depth - 1, boardState, move[0], move[1], false);
                        boardState[move[0], move[1]] = 0;
                        if (value > maxscore)
                        {
                            maxscore = value;
                            goPoint = new int[2];
                            goPoint = move;
                        }
                    }
                }

                return maxscore;
            }
            else
            {
                int maxscore = Int32.MaxValue;
                for (int i = 0; i < possibleMoves.Count; i++)
                {
                    int[] move = possibleMoves[i];
                    if (boardState[move[0], move[1]] == 0)
                    {
                        boardState[move[0], move[1]] = 2;
                        maxscore = Math.Min(maxscore, Minimax(depth - 1, boardState, move[0], move[1], true));
                        // int value = Minimax(depth - 1, boardState,move[0], move[1], true);
                        boardState[move[0], move[1]] = 0;
                        // if (maxscore > value)
                        // {
                        //     maxscore = value;
                        //     goPoint = move;
                        // }
                    }
                }

                return maxscore;
            }
        }

        public int Heuristic(int[,] boardState, int row, int column,bool isMaxplayer)
        {
            int Atack = AScoreSum(boardState, row, column, isMaxplayer);
            int Defense = DScoreSum(boardState, row, column, isMaxplayer);
            return Atack >= Defense ? Atack : Defense;
        }

        private int AScoreSum(int[,] boardState, int x, int y,bool isMaxplayer) //Tong Diem Tan Cong
        {
            int valuePlayerMax = isMaxplayer ? 1 : 2;
            int valuePlayerMin = valuePlayerMax == 1 ? 2 : 1;
            int S_Horizontal = 0;
            int S_Vertical = 0;
            int S_DiagonalPrimary = 0;
            int S_DiagonalSub = 0;
            int myArmy = 0, enemy = 0;

            // int toRight = 0, toLeft = 0, toTop = 0, toBot = 0, TopLeft = 0, TopRight = 0, BotLeft = 0, BotRight = 0;

            #region Horizontal

            //Hori toRight
            for (int i = y + 1; i < y + 5; i++)
            {
                if (i == Cons.COLUMNS) break;
                if (boardState[x, i] == valuePlayerMax)
                {
                    myArmy++;
                }
                else if (boardState[x, i] == valuePlayerMin)
                {
                    enemy++;
                    break;
                }
                else
                {
                    break;
                }
            }

            //Hori toLeft
            for (int i = y - 1; i > y - 5; i--)
            {
                if (i < 0) break;
                if (boardState[x, i] == valuePlayerMax)
                {
                    myArmy++;
                }
                else if (boardState[x, i] == 2)
                {
                    enemy++;
                    break;
                }
                else
                {
                    break;
                }
            }

            if (enemy == valuePlayerMin) return 0;
            if (myArmy == 4)
            {
                return this.AScore[myArmy] * 2;
            }

            if (myArmy > 4) myArmy = 4;
            S_Horizontal = this.AScore[myArmy];
            myArmy = enemy = 0;

            #endregion

            #region Vetical

            //Vertical toTop
            for (int i = x - 1; i > x - 5; i--)
            {
                if (i < 0) break;
                if (boardState[i, y] == valuePlayerMax)
                {
                    myArmy++;
                }
                else if (boardState[i, y] == valuePlayerMin)
                {
                    enemy++;
                    break;
                }
                else
                {
                    break;
                }
            }

            //Vertical toBot
            for (int i = x + 1; i < x + 5; i++)
            {
                if (i == Cons.ROWS) break;
                if (boardState[i, y] == valuePlayerMax)
                {
                    myArmy++;
                }
                else if (boardState[i, y] == valuePlayerMin)
                {
                    enemy++;
                    break;
                }
                else
                {
                    break;
                }
            }

            if (enemy == 2) return 0;
            if (myArmy == 4)
            {
                return this.AScore[myArmy] * 2;
            }

            if (myArmy > 4) myArmy = 4;
            S_Vertical = this.AScore[myArmy];
            myArmy = enemy = 0;

            #endregion

            #region DiagonalPrimary

            //DiagonalPrimary TopLeft
            for (int i = 1; i < 5; i++)
            {
                if (x - i < 0 || y - i < 0) break;
                if (boardState[x - i, y - i] == valuePlayerMax)
                {
                    myArmy++;
                }

                if (boardState[x - i, y - i] == valuePlayerMin)
                {
                    enemy++;
                    break;
                }
                else
                {
                    break;
                }
            }

            //DiagonalPrimary BotRight
            for (int i = 1; i < 5; i++)
            {
                if (x + i >= Cons.ROWS || y + i >= Cons.COLUMNS) break;
                if (boardState[x + i, y + i] == valuePlayerMax)
                {
                    myArmy++;
                }

                if (boardState[x + i, y + i] == valuePlayerMin)
                {
                    enemy++;
                    break;
                }
                else
                {
                    break;
                }
            }

            if (enemy == 2) return 0;
            if (myArmy == 4)
            {
                return this.AScore[myArmy] * 2;
            }

            if (myArmy > 4) myArmy = 4;
            S_DiagonalPrimary = this.AScore[myArmy];
            myArmy = enemy = 0;

            #endregion

            #region DiagonalSub

            //DiagonalSub TopRight
            for (int i = 1; i < 5; i++)
            {
                if (x - i < 0 || y + i >= Cons.COLUMNS) break;
                if (boardState[x - i, y + i] == valuePlayerMax)
                {
                    myArmy++;
                }

                if (boardState[x - i, y + i] == valuePlayerMin)
                {
                    enemy++;
                    break;
                }
                else
                {
                    break;
                }
            }

            //DiagonalSub BotLeft
            for (int i = 1; i < 5; i++)
            {
                if (x + i >= Cons.ROWS || y - i < 0) break;
                if (boardState[x + i, y - i] == valuePlayerMax)
                {
                    myArmy++;
                }

                if (boardState[x + i, y - i] == valuePlayerMin)
                {
                    enemy++;
                    break;
                }
                else
                {
                    break;
                }
            }

            if (enemy == 2) return 0;
            if (myArmy >= 4)
            {
                return this.AScore[4] * 2;
            }

            if (myArmy > 4) myArmy = 4;
            S_DiagonalSub = this.AScore[myArmy];

            #endregion

            return S_Horizontal + S_Vertical + S_DiagonalPrimary + S_DiagonalSub;
        }

        private int DScoreSum(int[,] boardState, int x, int y,bool isMaxplayer) //Tong Diem Phong Ngu
        {
            int valuePlayerMax = isMaxplayer ? 1 : 2;
            int valuePlayerMin = valuePlayerMax == 1 ? 2 : 1;
            int S_Horizontal = 0;
            int S_Vertical = 0;
            int S_DiagonalPrimary = 0;
            int S_DiagonalSub = 0;
            int myArmy = 0, enemy = 0;

            // int toRight = 0, toLeft = 0, toTop = 0, toBot = 0, TopLeft = 0, TopRight = 0, BotLeft = 0, BotRight = 0;

            #region Horizontal

            //Hori toRight
            for (int i = y + 1; i < y + 5; i++)
            {
                if (i == Cons.COLUMNS) break;
                if (boardState[x, i] == valuePlayerMax)
                {
                    myArmy++;
                    break;
                }
                else if (boardState[x, i] == valuePlayerMin)
                {
                    enemy++;
                }
                else
                {
                    break;
                }
            }

            //Hori toLeft
            for (int i = y - 1; i > y - 5; i--)
            {
                if (i < 0) break;
                if (boardState[x, i] == valuePlayerMax)
                {
                    myArmy++;
                    break;
                }
                else if (boardState[x, i] == valuePlayerMin)
                {
                    enemy++;
                }
                else
                {
                    break;
                }
            }

            if (myArmy == 2) return 0;
            if (enemy > 3)
            {
                return this.DScore[4] * 2;
            }

            S_Horizontal = this.DScore[enemy] - this.AScore[myArmy];
            myArmy = enemy = 0;

            #endregion

            #region Vetical

            //Vertical toTop
            for (int i = x - 1; i > x - 5; i--)
            {
                if (i < 0) break;
                if (boardState[i, y] == valuePlayerMax)
                {
                    myArmy++;
                    break;
                }
                else if (boardState[i, y] == valuePlayerMin)
                {
                    enemy++;
                }
                else
                {
                    break;
                }
            }

            //Vertical toBot
            for (int i = x + 1; i < x + 5; i++)
            {
                if (i == Cons.ROWS) break;
                if (boardState[i, y] == valuePlayerMax)
                {
                    myArmy++;
                    break;
                }
                else if (boardState[i, y] == valuePlayerMin)
                {
                    enemy++;
                }
                else
                {
                    break;
                }
            }

            if (myArmy == 2) return 0;
            if (enemy > 3)
            {
                return this.DScore[4] * 2;
            }

            S_Vertical = this.DScore[enemy] - this.AScore[myArmy];
            myArmy = enemy = 0;

            #endregion

            #region DiagonalPrimary

            //DiagonalPrimary TopLeft
            for (int i = 1; i < 5; i++)
            {
                if (x - i < 0 || y - i < 0) break;
                if (boardState[x - i, y - i] == valuePlayerMax)
                {
                    myArmy++;
                    break;
                }

                if (boardState[x - i, y - i] == valuePlayerMin)
                {
                    enemy++;
                }
                else
                {
                    break;
                }
            }

            //DiagonalPrimary BotRight
            for (int i = 1; i < 5; i++)
            {
                if (x + i >= Cons.ROWS || y + i >= Cons.COLUMNS) break;
                if (boardState[x + i, y + i] == valuePlayerMax)
                {
                    myArmy++;
                    break;
                }

                if (boardState[x + i, y + i] == valuePlayerMin)
                {
                    enemy++;
                }
                else
                {
                    break;
                }
            }

            if (myArmy == 2) return 0;
            if (enemy > 3)
            {
                return this.DScore[4] * 2;
            }

            S_DiagonalPrimary = this.DScore[enemy] - this.AScore[myArmy];
            myArmy = enemy = 0;

            #endregion

            #region DiagonalSub

            //DiagonalSub TopRight
            for (int i = 1; i < 5; i++)
            {
                if (x - i < 0 || y + i >= Cons.COLUMNS) break;
                if (boardState[x - i, y + i] == valuePlayerMax)
                {
                    myArmy++;
                    break;
                }

                if (boardState[x - i, y + i] == valuePlayerMin)
                {
                    enemy++;
                }
                else
                {
                    break;
                }
            }

            //DiagonalSub BotLeft
            for (int i = 1; i < 5; i++)
            {
                if (x + i >= Cons.ROWS || y - i < 0) break;
                if (boardState[x + i, y - i] == valuePlayerMax)
                {
                    myArmy++;
                    break;
                }

                if (boardState[x + i, y - i] == valuePlayerMin)
                {
                    enemy++;
                }
                else
                {
                    break;
                }
            }

            if (myArmy == 2) return 0;
            if (enemy > 3)
            {
                return this.DScore[4] * 2;
            }

            S_DiagonalSub = this.DScore[enemy] - this.AScore[myArmy];

            #endregion

            return S_Horizontal + S_Vertical + S_DiagonalPrimary + S_DiagonalSub;
        }
    }
}