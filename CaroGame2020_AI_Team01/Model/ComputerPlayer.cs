using System;
using System.Collections.Generic;
using System.Drawing;

namespace CaroGame2020_AI_Team01.Model
{
    public class ComputerPlayer
    {
        EvalBoard eBoard; // diem cua trang thai ban co 
        BoardState boardState; // trang thai cua ban co
        int playerFlag = 2; // danh dau la computer player
        int _x, _y; // toa do nuoc di

        public static int maxDepth = 6; // do sau toi da
        public static int maxMove = 4; // so o tiep theo dem xet toi da

        public int[] AScore = {0, 4, 27, 256, 1458}; // Mang diem tan cong 0,4,28,256,2308
        public int[] DScore = {0, 2, 9, 99, 769}; // Mang diem phong ngu 0,1,9,85,769

        //public int[] AScore = { 0, 9, 54, 169, 1458 };  // Mang diem tan cong
        //public int[] DScore = {0, 3, 27, 99, 729};// Mang diem phong ngu
        public bool cWin = false;
        public int[] goPoint;

        public ComputerPlayer(BoardState board)
        {
            this.boardState = board;
            this.eBoard = new EvalBoard(board.rows, board.columns);
        }

        // ham luong gia
        public void evalChessBoard( EvalBoard eBoard)
        {
            int row, col;
            int ePC, eHuman;
            eBoard.resetBoard(); // reset toan bo diem trang thai cua toan bo o co 
            // Duyet theo hang
            for (row = 0; row < eBoard.rows; row++)
            for (col = 0; col < eBoard.columns - 4; col++)
            {
                ePC = 0;
                eHuman = 0;
                for (int i = 0; i < 5; i++)
                {
                    if (boardState.getPosition(row, col + i) == 1) // neu quan do la cua human
                        eHuman++;
                    if (boardState.getPosition(row, col + i) == 2) // neu quan do la cua pc
                        ePC++;
                }

                // trong vong 5 o khong co quan dich
                if (eHuman * ePC == 0 && eHuman != ePC)
                    for (int i = 0; i < 5; i++)
                    {
                        if (boardState.getPosition(row, col + i) == 0)
                        {
                            // neu o chua danh
                            if (eHuman == 0) // ePC khac 0
                                    eBoard.EBoard[row, col + i] += AScore[ePC]; // cho diem tan cong
                            if (ePC == 0) // eHuman khac 0
                                    eBoard.EBoard[row, col + i] += DScore[eHuman]; // cho diem phong ngu	
                            if (eHuman == 4 || ePC == 4)
                                eBoard.EBoard[row, col + i] *= 2;
                        }
                    }
            }

            // Duyet theo cot
            for (col = 0; col < eBoard.columns; col++)
            for (row = 0; row < eBoard.rows - 4; row++)
            {
                ePC = 0;
                eHuman = 0;
                for (int i = 0; i < 5; i++)
                {
                    if (boardState.getPosition(row + i, col) == 1)
                        eHuman++;
                    if (boardState.getPosition(row + i, col) == 2)
                        ePC++;
                }

                if (eHuman * ePC == 0 && eHuman != ePC)
                    for (int i = 0; i < 5; i++)
                    {
                        if (boardState.getPosition(row + i, col) == 0) // Neu o chua duoc danh
                        {
                            if (eHuman == 0)
                                    eBoard.EBoard[row + i, col] += AScore[ePC];
                            if (ePC == 0)
                                    eBoard.EBoard[row + i, col] += DScore[eHuman];
                            if (eHuman == 4 || ePC == 4)
                                eBoard.EBoard[row + i, col] *= 2;
                        }
                    }
            }

            // Duyet theo duong cheo xuong
            for (col = 0; col < eBoard.columns - 4; col++)
            for (row = 0; row < eBoard.rows - 4; row++)
            {
                ePC = 0;
                eHuman = 0;
                for (int i = 0; i < 5; i++)
                {
                    if (boardState.getPosition(row + i, col + i) == 1)
                        eHuman++;
                    if (boardState.getPosition(row + i, col + i) == 2)
                        ePC++;
                }

                if (eHuman * ePC == 0 && eHuman != ePC)
                    for (int i = 0; i < 5; i++)
                    {
                        if (boardState.getPosition(row + i, col + i) == 0) // Neu o chua duoc danh
                        {
                            if (eHuman == 0)
                                    eBoard.EBoard[row + i, col + i] += AScore[ePC];
                            if (ePC == 0)
                                    eBoard.EBoard[row + i, col + i] += DScore[eHuman];
                            if (eHuman == 4 || ePC == 4)
                                eBoard.EBoard[row + i, col + i] *= 2;
                        }
                    }
            }

            // Duyet theo duong cheo len
            for (row = 4; row < eBoard.rows; row++)
            for (col = 0; col < eBoard.columns - 4; col++)
            {
                ePC = 0; // so quan PC
                eHuman = 0; // so quan Human
                for (int i = 0; i < 5; i++)
                {
                    if (boardState.getPosition(row - i, col + i) == 1) // neu la human
                        eHuman++; // tang so quan human
                    if (boardState.getPosition(row - i, col + i) == 2) // neu la PC
                        ePC++; // tang so quan PC
                }

                if (eHuman * ePC == 0 && eHuman != ePC)
                    for (int i = 0; i < 5; i++)
                    {
                        if (boardState.getPosition(row - i, col + i) == 0)
                        {
                            // neu o chua duoc danh
                            if (eHuman == 0)
                                    eBoard.EBoard[row - i, col + i] += AScore[ePC];
                            if (ePC == 0)
                                    eBoard.EBoard[row - i, col + i] += DScore[eHuman];
                            if (eHuman == 4 || ePC == 4)
                                eBoard.EBoard[row - i, col + i] *= 2;
                        }
                    }
            }
        }

       // thuat toan alpha-beta
        public void alphaBeta(int alpha, int beta, int depth)
        {
                maxValue(boardState, alpha, beta, depth);
        }

        private int maxValue(BoardState state, int alpha, int beta, int depth)
        {
            if (depth >= maxDepth)
            {
                eBoard.MaxPos(); // tinh toa do co diem cao nhat
                int value = eBoard.evaluationBoard; // gia tri max hien tai
                return value;
            }

            evalChessBoard(eBoard); // danh gia diem voi nguoi choi hien tai la PC
            List<int[]> list = new List<int[]>(); // list cac nut con
            for (int i = 0; i < maxMove; i++)
            {
                int[] node = eBoard.MaxPos();
                if (node == null)
                    break;
                list.Add(node);
                eBoard.EBoard[node[0], node[1]] = 0;
            }

            int v = int.MaxValue;
            for (int i = 0; i < list.Count; i++)
            {
                int[] com = list[i];
                state.setPosition(com[0], com[1], 2);
                v = Math.Max(v, minValue(state, alpha, beta, depth + 1));
                state.setPosition(com[0], com[1], 0);
                if (v >= beta || state.checkEnd(com[0], com[1]) == 2)
                {
                    goPoint = com;
                    return v;
                }

                alpha = Math.Max(alpha, v);
            }

            return v;
        }

        private int minValue(BoardState state, int alpha, int beta, int depth)
        {
            eBoard.MaxPos();
            int value = eBoard.evaluationBoard;
            if (depth >= maxDepth)
            {
                return value;
            }

            List<int[]> list = new List<int[]>(); // list cac nut con
            for (int i = 0; i < maxMove; i++)
            {
                int[] node = eBoard.MaxPos();
                if (node == null)
                    break;
                list.Add(node);
                eBoard.EBoard[node[0], node[1]] = 0;
            }

            int v = int.MaxValue;
            for (int i = 0; i < list.Count; i++)
            {
                int[] com = list[i];
                state.setPosition(com[0], com[1], 1);
                v = Math.Min(v, maxValue(state, alpha, beta, depth + 1));
                state.setPosition(com[0], com[1], 0);
                if (v <= alpha || state.checkEnd(com[0], com[1]) == 1)
                {
                    return v;
                }

                beta = Math.Min(beta, v);
            }

            return v;
        }


        // tinh toan nuoc di
        public Field AI()
        {
            alphaBeta(0, 1, 2);
            int[] temp = goPoint;
            if (temp != null)
            {
                _x = temp[0];
                _y = temp[1];
            }

            return new Field(new Point(_x, _y), Cons.MARK[0]);
        }
    }
}