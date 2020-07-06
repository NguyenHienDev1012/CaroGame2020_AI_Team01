using System;
using System.Windows.Forms;

namespace CaroGame2020_AI_Team01
{
    public partial class FormInputNamePlayer : Form
    {
        private string player1;
        private string player2;

        public string Player1
        {
            get => player1;
            set => player1 = value;
        }

        public string Player2
        {
            get => player2;
            set => player2 = value;
        }

        public FormInputNamePlayer()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Player1= tbPlayer1.Text;
            Player2 = tbPlayer2.Text;
            
            if (Player1.Length==0 || Player2.Length==0)
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