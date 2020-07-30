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
        private long[] AScore = {0, 8, 56, 392, 2477, 19208};

        private long[] DScore = {0, 4, 32, 325, 2048, 16384};

        //Matrix
        private List<List<Field>> matrix_field;

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
        }
        
        public Field MaxMove()
        {
            Field field = new Field();
            long Ascore = 0;
            long Dscore = 0;
            long MaxScore = 0;
            for (int x = 0; x < Cons.ROWS; x++)
            {
                for (int y = 0; y < Cons.COLUMNS; y++)
                {
                    if(matrix_field[x][y].Mark!=null) continue;
                    Ascore = AScoreSum(x, y);
                    Dscore = DScoreSum(x, y);
                    // MessageBox.Show((Ascore + "--" + Dscore));
                    long ScoreTMP = Ascore > Dscore ? Ascore : Dscore;
                    if (ScoreTMP >= MaxScore)
                    {
                        MaxScore = ScoreTMP;
                        field = new Field();
                        field.Mark = computerMark;
                        field.Position = new Point(x, y);
                    }
                }
            }

            return field;
        }

        private long AScoreSum(int x, int y) //Tong Diem Tan Cong
        {
            long S_Horizontal = 0;
            long S_Vertical = 0;
            long S_DiagonalPrimary = 0;
            long S_DiagonalSub = 0;
            long AScore = 0;

            int myArmy = 0, enemy = 0;

            // int toRight = 0, toLeft = 0, toTop = 0, toBot = 0, TopLeft = 0, TopRight = 0, BotLeft = 0, BotRight = 0;

            #region Horizontal

            //Hori toRight
            for (int i = y + 1; i < Cons.COLUMNS; i++)
            {
                if (matrix_field[x][i].Mark == computerMark)
                {
                    myArmy++;
                }
                else if (matrix_field[x][i].Mark == HumanMark)
                {
                    enemy++;
                    break;
                }
                else
                {
                    if (i + 1 < Cons.COLUMNS)
                    {
                        if (matrix_field[x][i].Mark == computerMark)
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
                if (matrix_field[x][i].Mark == computerMark)
                {
                    myArmy++;
                }
                else if (matrix_field[x][i].Mark == HumanMark)
                {
                    enemy++;
                    break;
                }
                else
                {
                    if (i - 1 >=0)
                    {
                        if (matrix_field[x][i].Mark == computerMark)
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
                if (matrix_field[i][y].Mark == computerMark)
                {
                    myArmy++;
                }
                else if (matrix_field[i][y].Mark == HumanMark)
                {
                    enemy++;
                    break;
                }
                else
                {
                    if (i - 1 >=0)
                    {
                        if (matrix_field[i][y].Mark == computerMark)
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
                if (matrix_field[i][y].Mark == computerMark)
                {
                    myArmy++;
                }
                else if (matrix_field[i][y].Mark == HumanMark)
                {
                    enemy++;
                    break;
                }
                else
                {
                    if (i + 1 <Cons.ROWS)
                    {
                        if (matrix_field[i][y].Mark == computerMark)
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
                if (matrix_field[x - i][y - i].Mark == computerMark)
                {
                    myArmy++;
                }

                if (matrix_field[x - i][y - i].Mark == computerMark)
                {
                    enemy++;
                    break;
                }
                else
                {
                    if (x - i >= 0 && y - i >= 0)
                    {
                        if (matrix_field[x - i][y - i].Mark == computerMark)
                        {
                            myArmy+=2;
                        }
                    }
                    break;
                }
            }

            //DiagonalPrimary BotRight
            for (int i = 1; i < Cons.ROWS; i++)
            {
                if (x + i >= Cons.ROWS || y + i >= Cons.COLUMNS) break;
                if (matrix_field[x + i][y + i].Mark == computerMark)
                {
                    myArmy++;
                }

                if (matrix_field[x + i][y + i].Mark == computerMark)
                {
                    enemy++;
                    break;
                }
                else
                {
                    if (x + i <Cons.ROWS && y + i <Cons.COLUMNS)
                    {
                        if (matrix_field[x + i][y + i].Mark == computerMark)
                        {
                            myArmy+=2;
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
                if (matrix_field[x - i][y + i].Mark == computerMark)
                {
                    myArmy++;
                }

                if (matrix_field[x - i][y + i].Mark == computerMark)
                {
                    enemy++;
                    break;
                }
                else
                {
                    if (x - i >= 0 && y + i < Cons.COLUMNS)
                    {
                        if (matrix_field[x - i][y + i].Mark == computerMark)
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
                if (matrix_field[x + i][y - i].Mark == computerMark)
                {
                    myArmy++;
                }

                if (matrix_field[x + i][y - i].Mark == computerMark)
                {
                    enemy++;
                    break;
                }
                else
                {
                    if (x + i < Cons.ROWS && y - i >= 0)
                    {
                        if (matrix_field[x + i][y - i].Mark == computerMark)
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

        private long DScoreSum(int x, int y) //Tong Diem Phong Ngu
        {
           long S_Horizontal = 0;
            long S_Vertical = 0;
            long S_DiagonalPrimary = 0;
            long S_DiagonalSub = 0;
            long AScore = 0;

            int myArmy = 0, enemy = 0;

            // int toRight = 0, toLeft = 0, toTop = 0, toBot = 0, TopLeft = 0, TopRight = 0, BotLeft = 0, BotRight = 0;

            #region Horizontal

            //Hori toRight
            for (int i = y + 1; i < Cons.COLUMNS; i++)
            {
                if (matrix_field[x][i].Mark == computerMark)
                {
                    myArmy++;
                    break;
                }
                else if (matrix_field[x][i].Mark == HumanMark)
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
                if (matrix_field[x][i].Mark == computerMark)
                {
                    myArmy++;
                    break;
                }
                else if (matrix_field[x][i].Mark == HumanMark)
                {
                    enemy++;
                   
                }
                else
                {
                    break;
                }
            }

            S_Horizontal += this.DScore[enemy];
            AScore = 0;
            myArmy = 0;
            enemy = 0;

            #endregion

            #region Vetical

            //Vertical toTop
            for (int i = x - 1; i >= 0; i--)
            {
                if (matrix_field[i][y].Mark == computerMark)
                {
                    myArmy++;
                    break;
                }
                else if (matrix_field[i][y].Mark == HumanMark)
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
                if (matrix_field[i][y].Mark == computerMark)
                {
                    myArmy++;
                    break;
                }
                else if (matrix_field[i][y].Mark == HumanMark)
                {
                    enemy++;
                }
                else
                {
                    break;
                }
            }

            S_Vertical += this.DScore[enemy];
            AScore = 0;
            myArmy = 0;
            enemy = 0;

            #endregion

            #region DiagonalPrimary

            //DiagonalPrimary TopLeft
            for (int i = 1; i <= x; i++)
            {
                if (x - i < 0 || y - i < 0) break;
                if (matrix_field[x - i][y - i].Mark == computerMark)
                {
                    myArmy++;
                    break;
                }

                if (matrix_field[x - i][y - i].Mark == computerMark)
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
                if (matrix_field[x + i][y + i].Mark == computerMark)
                {
                    myArmy++;
                    break;
                }

                if (matrix_field[x + i][y + i].Mark == computerMark)
                {
                    enemy++;
                }
                else
                {
                    break;
                }
            }

            S_DiagonalPrimary += this.DScore[enemy];
            AScore = 0;
            myArmy = 0;
            enemy = 0;

            #endregion

            #region DiagonalSub

            //DiagonalSub TopRight
            for (int i = 1; i <= x; i++)
            {
                if (x - i < 0 || y + i >= Cons.COLUMNS) break;
                if (matrix_field[x - i][y + i].Mark == computerMark)
                {
                    myArmy++;
                    break;
                }

                if (matrix_field[x - i][y + i].Mark == computerMark)
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
                if (matrix_field[x + i][y - i].Mark == computerMark)
                {
                    myArmy++;
                    break;
                }

                if (matrix_field[x + i][y - i].Mark == computerMark)
                {
                    enemy++;
                }
                else
                {
                    break;
                }
            }

            S_DiagonalSub += this.DScore[enemy];
            AScore = 0;
            myArmy = 0;
            enemy = 0;

            #endregion

            return S_Horizontal + S_Vertical + S_DiagonalPrimary + S_DiagonalSub;
        }
    }
}