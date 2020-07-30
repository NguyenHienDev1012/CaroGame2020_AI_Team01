using System.Drawing;
using System.Net.Mime;
using System.Windows.Forms;

namespace CaroGame2020_AI_Team01
{
    partial class Caro_Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Caro_Game));
            this.pnlOption = new System.Windows.Forms.Panel();
            this.pnlPlayer = new System.Windows.Forms.Panel();
            this.pnlValue = new System.Windows.Forms.Panel();
            this.btnUndo = new System.Windows.Forms.Button();
            this.pgbCoolDown = new System.Windows.Forms.ProgressBar();
            this.tbName = new System.Windows.Forms.TextBox();
            this.pnlStart = new System.Windows.Forms.Panel();
            this.pnlOptionGame = new System.Windows.Forms.Panel();
            this.pnlMode = new System.Windows.Forms.Panel();
            this.rbSolo = new System.Windows.Forms.RadioButton();
            this.rbAI = new System.Windows.Forms.RadioButton();
            this.rbLan = new System.Windows.Forms.RadioButton();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.pnlBoard = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timeCoolDown = new System.Windows.Forms.Timer(this.components);
            this.pnlOption.SuspendLayout();
            this.pnlPlayer.SuspendLayout();
            this.pnlStart.SuspendLayout();
            this.pnlOptionGame.SuspendLayout();
            this.pnlMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlOption
            // 
            this.pnlOption.BackColor = System.Drawing.SystemColors.Control;
            this.pnlOption.Controls.Add(this.pnlPlayer);
            this.pnlOption.Controls.Add(this.pnlStart);
            resources.ApplyResources(this.pnlOption, "pnlOption");
            this.pnlOption.Name = "pnlOption";
            // 
            // pnlPlayer
            // 
            this.pnlPlayer.BackColor = System.Drawing.SystemColors.Control;
            this.pnlPlayer.Controls.Add(this.pnlValue);
            this.pnlPlayer.Controls.Add(this.btnUndo);
            this.pnlPlayer.Controls.Add(this.pgbCoolDown);
            this.pnlPlayer.Controls.Add(this.tbName);
            resources.ApplyResources(this.pnlPlayer, "pnlPlayer");
            this.pnlPlayer.Name = "pnlPlayer";
            // 
            // pnlValue
            // 
            this.pnlValue.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.pnlValue, "pnlValue");
            this.pnlValue.Name = "pnlValue";
            // 
            // btnUndo
            // 
            resources.ApplyResources(this.btnUndo, "btnUndo");
            this.btnUndo.ForeColor = System.Drawing.Color.Teal;
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.UseVisualStyleBackColor = true;
            // 
            // pgbCoolDown
            // 
            resources.ApplyResources(this.pgbCoolDown, "pgbCoolDown");
            this.pgbCoolDown.Name = "pgbCoolDown";
            // 
            // tbName
            // 
            resources.ApplyResources(this.tbName, "tbName");
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            // 
            // pnlStart
            // 
            this.pnlStart.BackColor = System.Drawing.SystemColors.Control;
            this.pnlStart.Controls.Add(this.pnlOptionGame);
            resources.ApplyResources(this.pnlStart, "pnlStart");
            this.pnlStart.Name = "pnlStart";
            // 
            // pnlOptionGame
            // 
            this.pnlOptionGame.BackColor = System.Drawing.SystemColors.Control;
            this.pnlOptionGame.Controls.Add(this.pnlMode);
            this.pnlOptionGame.Controls.Add(this.btnNew);
            this.pnlOptionGame.Controls.Add(this.btnExit);
            this.pnlOptionGame.Controls.Add(this.btnStart);
            resources.ApplyResources(this.pnlOptionGame, "pnlOptionGame");
            this.pnlOptionGame.Name = "pnlOptionGame";
            // 
            // pnlMode
            // 
            this.pnlMode.Controls.Add(this.rbSolo);
            this.pnlMode.Controls.Add(this.rbAI);
            this.pnlMode.Controls.Add(this.rbLan);
            resources.ApplyResources(this.pnlMode, "pnlMode");
            this.pnlMode.Name = "pnlMode";
            // 
            // rbSolo
            // 
            resources.ApplyResources(this.rbSolo, "rbSolo");
            this.rbSolo.Checked = true;
            this.rbSolo.Name = "rbSolo";
            this.rbSolo.TabStop = true;
            this.rbSolo.UseVisualStyleBackColor = true;
            // 
            // rbAI
            // 
            resources.ApplyResources(this.rbAI, "rbAI");
            this.rbAI.ForeColor = System.Drawing.Color.Red;
            this.rbAI.Name = "rbAI";
            this.rbAI.UseVisualStyleBackColor = true;
            // 
            // rbLan
            // 
            resources.ApplyResources(this.rbLan, "rbLan");
            this.rbLan.ForeColor = System.Drawing.Color.Green;
            this.rbLan.Name = "rbLan";
            this.rbLan.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            resources.ApplyResources(this.btnNew, "btnNew");
            this.btnNew.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (192)))), ((int) (((byte) (0)))));
            this.btnNew.Name = "btnNew";
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            resources.ApplyResources(this.btnExit, "btnExit");
            this.btnExit.Name = "btnExit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnStart
            // 
            resources.ApplyResources(this.btnStart, "btnStart");
            this.btnStart.ForeColor = System.Drawing.Color.Blue;
            this.btnStart.Name = "btnStart";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // pnlBoard
            // 
            resources.ApplyResources(this.pnlBoard, "pnlBoard");
            this.pnlBoard.Name = "pnlBoard";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::CaroGame2020_AI_Team01.Properties.Resources.icon_large;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // Caro_Game
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pnlBoard);
            this.Controls.Add(this.pnlOption);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Caro_Game";
            this.pnlOption.ResumeLayout(false);
            this.pnlPlayer.ResumeLayout(false);
            this.pnlPlayer.PerformLayout();
            this.pnlStart.ResumeLayout(false);
            this.pnlOptionGame.ResumeLayout(false);
            this.pnlMode.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.ProgressBar pgbCoolDown;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlBoard;
        private System.Windows.Forms.Panel pnlMode;
        private System.Windows.Forms.Panel pnlOption;
        private System.Windows.Forms.Panel pnlOptionGame;
        private System.Windows.Forms.Panel pnlPlayer;
        private System.Windows.Forms.Panel pnlStart;
        private System.Windows.Forms.Panel pnlValue;
        private System.Windows.Forms.RadioButton rbAI;
        private System.Windows.Forms.RadioButton rbLan;
        private System.Windows.Forms.RadioButton rbSolo;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Timer timeCoolDown;

        #endregion
    }
}