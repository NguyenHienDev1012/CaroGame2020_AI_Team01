using System;
using System.Windows.Forms;
using CaroGame2020_AI_Team01.Model;

namespace CaroGame2020_AI_Team01
{
    public partial class Caro_Game : Form
    {
        private Caro_Manager _caroManager;
        private OptionPlayer _optionPlayer;
        private OptionGame _optionGame;
        private TimeCoolDown timeCoolDownModel;

        public Caro_Game()
        {
            InitializeComponent();
            timeCoolDownModel=new TimeCoolDown(timeCoolDown, pgbCoolDown);
            _optionGame = new OptionGame(pnlMode,btnStart,btnNew);
            _optionPlayer = new OptionPlayer(pnlValue,tbName,btnUndo);
            _caroManager = new Caro_Manager(pnlBoard,_optionPlayer,_optionGame, timeCoolDownModel);
            _caroManager.DrawCaroBoard();
            TimePlayer();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TimePlayer()
        {
            pgbCoolDown.Step = Cons.COOL_DOWN_STEP;
            pgbCoolDown.Maximum = Cons.COOL_DOWN_TIME;
            timeCoolDown.Interval = Cons.COOL_DOWN_INTERVAL;
            pgbCoolDown.Value =0;
        }
        
    }
}