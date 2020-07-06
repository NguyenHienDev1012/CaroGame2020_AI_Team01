using System.Windows.Forms;

namespace CaroGame2020_AI_Team01
{
    public class OptionGame
    {
        private Panel pnlMode;
        private Button start;
        private Button newGame;

        public OptionGame(Panel pnlMode, Button start, Button newGame)
        {
            this.pnlMode = pnlMode;
            this.start = start;
            this.newGame = newGame;
        }

        public Panel PnlMode
        {
            get => pnlMode;
            set => pnlMode = value;
        }

        public Button Start
        {
            get => start;
            set => start = value;
        }

        public Button NewGame
        {
            get => newGame;
            set => newGame = value;
        }
    }
}