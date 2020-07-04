using System.Windows.Forms;
using CaroGame2020_AI_Team01.Model;

namespace CaroGame2020_AI_Team01
{
    public partial class Caro_Game : Form
    {
        private Caro_Manager _caroManager;
        private OptionPlayer _optionPlayer;

        public Caro_Game()
        {
            InitializeComponent();
            _optionPlayer = new OptionPlayer(pnlValue,tbName,btnUndo);
            _caroManager = new Caro_Manager(pnlBoard,_optionPlayer);
            _caroManager.DrawCaroBoard();
        }
    }
}