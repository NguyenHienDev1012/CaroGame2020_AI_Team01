using System.Windows.Forms;

namespace CaroGame2020_AI_Team01
{
    public class OptionPlayer
    {
        private Panel pnlValue;
        private TextBox tbName;
        private Button btnUndo;

        public OptionPlayer(Panel pnlValue, TextBox tbName, Button btnUndo)
        {
            this.pnlValue = pnlValue;
            this.tbName = tbName;
            this.btnUndo = btnUndo;
        }

        public OptionPlayer()
        {
        }

        public Panel PnlValue
        {
            get => pnlValue;
            set => pnlValue = value;
        }

        public TextBox TbName
        {
            get => tbName;
            set => tbName = value;
        }

        public Button BtnUndo
        {
            get => btnUndo;
            set => btnUndo = value;
        }
    }
}