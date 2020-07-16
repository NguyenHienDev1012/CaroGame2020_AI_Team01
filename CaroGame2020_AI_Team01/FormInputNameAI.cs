using System;
using System.Windows.Forms;

namespace CaroGame2020_AI_Team01
{
    public partial class FormInputNameAI : Form
    {
        private string player;

        public string Player
        {
            get => player;
            set => player = value;
        }

        public FormInputNameAI()
        {
            InitializeComponent();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            player= tb_player.Text;
            
            if (player.Length==0)
            {
                MessageBox.Show("Please enter player name!!!","Warning!",MessageBoxButtons.RetryCancel);
            }
            else
            {
                this.Close(); 
            }
        }
    }
}