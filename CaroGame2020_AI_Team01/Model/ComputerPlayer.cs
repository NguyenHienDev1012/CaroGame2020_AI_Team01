using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace CaroGame2020_AI_Team01.Model
{
    public class ComputerPlayer
    {
        BoardState boardState; // trang thai cua ban co
        public int[] goPoint = new int[2]; // Luu vi tri max

        public int[] AScore = {0, 4, 27, 256, 1458}; // Mang diem tan cong
        public int[] DScore = {0, 2, 9, 99, 769}; // Mang diem phong ngu


        public ComputerPlayer(BoardState board)
        {
            this.boardState = board;
        }

        // ham luong gia
        public int Heuristic(BoardState boardState)
        {
            int row, col;
            int ePC, eHuman;
            boardState.EvalBoard.resetBoard(); // reset toan bo diem trang thai cua toan bo o co 
            // Duyet theo hang
            for (row = 0; row < boardState.rows; row++)
            for (col = 0; col < boardState.columns - 4; col++)
            {
                ePC = 0;
                eHuman = 0;
                for (int i = 0; i < 5; i++)
                {
                    if (boardState.getPosition(row, col + i) == Cons.MARK[1]) // neu quan do la cua human
                        eHuman++;
                    if (boardState.getPosition(row, col + i) == Cons.MARK[0]) // neu quan do la cua pc
                        ePC++;
                }

                // trong vong 5 o khong co quan dich
                if (eHuman * ePC == 0 && eHuman != ePC)
                    for (int i = 0; i < 5; i++)
                    {
                        if (boardState.getPosition(row, col + i) == null)
                        {
                            // neu o chua danh
                            if (eHuman == 0) // ePC khac 0
                                boardState.EvalBoard.EBoard[row, col + i] += AScore[ePC]; // cho diem tan cong
                            else if (ePC == 0) // eHuman khac 0
                                boardState.EvalBoard.EBoard[row, col + i] += DScore[eHuman]; // cho diem phong ngu	
                            if (eHuman == 4 || ePC == 4)
                                boardState.EvalBoard.EBoard[row, col + i] *= 2;
                        }
                    }
            }

            // Duyet theo cot
            for (col = 0; col < boardState.columns; col++)
            for (row = 0; row < boardState.rows - 4; row++)
            {
                ePC = 0;
                eHuman = 0;
                for (int i = 0; i < 5; i++)
                {
                    if (boardState.getPosition(row + i, col) == Cons.MARK[1])
                        eHuman++;
                    if (boardState.getPosition(row + i, col) == Cons.MARK[0])
                        ePC++;
                }

                if (eHuman * ePC == null && eHuman != ePC)
                    for (int i = 0; i < 5; i++)
                    {
                        if (boardState.getPosition(row + i, col) == null) // Neu o chua duoc danh
                        {
                            if (eHuman == 0)
                                boardState.EvalBoard.EBoard[row + i, col] += AScore[ePC];
                            else if (ePC == 0)
                                boardState.EvalBoard.EBoard[row + i, col] += DScore[eHuman];
                            if (eHuman == 4 || ePC == 4)
                                boardState.EvalBoard.EBoard[row + i, col] *= 2;
                        }
                    }
            }

            // Duyet theo duong cheo xuong
            for (col = 0; col < boardState.columns - 4; col++)
            for (row = 0; row < boardState.rows - 4; row++)
            {
                ePC = 0;
                eHuman = 0;
                for (int i = 0; i < 5; i++)
                {
                    if (boardState.getPosition(row + i, col + i) == Cons.MARK[1])
                        eHuman++;
                    if (boardState.getPosition(row + i, col + i) == Cons.MARK[0])
                        ePC++;
                }

                if (eHuman * ePC == 0 && eHuman != ePC)
                    for (int i = 0; i < 5; i++)
                    {
                        if (boardState.getPosition(row + i, col + i) == null) // Neu o chua duoc danh
                        {
                            if (eHuman == 0)
                                boardState.EvalBoard.EBoard[row + i, col + i] += AScore[ePC];
                            else if (ePC == 0)
                                boardState.EvalBoard.EBoard[row + i, col + i] += DScore[eHuman];
                            if (eHuman == 4 || ePC == 4)
                                boardState.EvalBoard.EBoard[row + i, col + i] *= 2;
                        }
                    }
            }

            // Duyet theo duong cheo len
            for (row = 4; row < boardState.rows; row++)
            for (col = 0; col < boardState.columns - 4; col++)
            {
                ePC = 0; // so quan PC
                eHuman = 0; // so quan Human
                for (int i = 0; i < 5; i++)
                {
                    if (boardState.getPosition(row - i, col + i) == Cons.MARK[1]) // neu la human
                        eHuman++; // tang so quan human
                    if (boardState.getPosition(row - i, col + i) == Cons.MARK[0]) // neu la PC
                        ePC++; // tang so quan PC
                }

                if (eHuman * ePC == 0 && eHuman != ePC)
                    for (int i = 0; i < 5; i++)
                    {
                        if (boardState.getPosition(row - i, col + i) == null)
                        {
                            // neu o chua duoc danh
                            if (eHuman == 0)
                                boardState.EvalBoard.EBoard[row - i, col + i] += AScore[ePC];
                            else if (ePC == 0)
                                boardState.EvalBoard.EBoard[row - i, col + i] += DScore[eHuman];
                            if (eHuman == 4 || ePC == 4)
                                boardState.EvalBoard.EBoard[row - i, col + i] *= 2;
                        }
                    }
            }

            goPoint = boardState.EvalBoard.MaxPos();
            return boardState.EvalBoard.maxScore;
        }


        // tinh toan nuoc di
        public Field AI()
        {
            // Minimax(boardState, 1, true);
            Heuristic(boardState);

            return new Field(new Point(goPoint[0], goPoint[1]), Cons.MARK[0]);
        }

        public int Minimax(BoardState boardState, int depth, bool isMaxPlayer)
        {
            // int values = Heuristic(boardState);
            if (depth == 0)
            {
                return Heuristic(boardState);
            }

            if (isMaxPlayer)
            {
                int v = Int32.MinValue;
                // List<int[]> bestMove = boardState.EvalBoard.listMove();
                // for (int i = 0; i < bestMove.Count; i++)
                // {
                //     int[] point = bestMove[i];
                //     boardState.setPosition(point[0],point[1], Cons.MARK[0]);
                //     // int value =  Minimax(boardState, depth - 1, false);
                //     v = Math.Max(v, Minimax(boardState, depth - 1, false));
                //     boardState.setPosition(point[0], point[1], null); // Reset -> backtracking
                //     if (boardState.checkEnd(point[0], point[1]) == 0)
                //     {
                //         goPoint = point;
                //         return v;
                //     }

                // if (value > v)
                // {
                //     goPoint = point;
                //     v = value;
                // }
                // }
                for (int i = 0; i < Cons.ROWS; i++)
                {
                    for (int j = 0; j < Cons.COLUMNS; j++)
                    {
                        if (boardState.matrix_field[i][j].Mark == null)
                        {
                            boardState.setPosition(i, j, Cons.MARK[0]); // PC
                            int value = Minimax(boardState, depth - 1, false);
                            if (value > v)
                            {
                                goPoint[0] = i;
                                goPoint[1] = j;
                                v = value;
                            }

                            boardState.setPosition(i, j, null); // Reset -> backtracking
                            // if (boardState.checkEnd(i, j) == 0)
                            // {
                            //     goPoint[0] = i;
                            //     goPoint[1] = j;
                            //     return v; // Neu PC win
                            // }
                        }
                    }
                }

                return v;
            }
            else
            {
                int v = Int32.MaxValue;
                // List<int[]> bestMove = boardState.EvalBoard.listMove();
                // for (int i = 0; i < bestMove.Count; i++)
                // {
                //     int[] point = bestMove[i];
                //     boardState.setPosition(point[0],point[1], Cons.MARK[1]);
                //     v = Math.Min(v, Minimax(boardState, depth - 1, true));
                //     boardState.setPosition(point[0], point[1], null); // Reset -> backtracking
                //     if (boardState.checkEnd(point[0],point[1]) == 1) return v; // Neu Human win
                // }
                for (int i = 0; i < Cons.ROWS; i++)
                {
                    for (int j = 0; j < Cons.COLUMNS; j++)
                    {
                        if (boardState.matrix_field[i][j].Mark == null)
                        {
                            boardState.setPosition(i, j, Cons.MARK[1]); // HUMAN
                            v = Math.Min(v, Minimax(boardState, depth - 1, true));
                            boardState.setPosition(i, j, null); // Reset -> backtracking
                            // if (boardState.checkEnd(i, j) == 1) return v; // Neu Human win
                        }
                    }
                }

                return v;
            }
        }
    }
}