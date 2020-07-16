using System.Windows.Forms;

namespace CaroGame2020_AI_Team01
{
    public class OptionGame
    {
        private Panel pnlMode;
        private Button btnStart;
        private Button btnNewGame;

        public OptionGame(Panel pnlMode, Button btnStart, Button btnNewGame)
        {
            this.pnlMode = pnlMode;
            this.btnStart = btnStart;
            this.btnNewGame = btnNewGame;
        }

        public Panel PnlMode
        {
            get => pnlMode;
            set => pnlMode = value;
        }

        public Button BtnStart
        {
            get => btnStart;
            set => btnStart = value;
        }

        public Button BtnNewGame
        {
            get => btnNewGame;
            set => btnNewGame = value;
        }
    }
}