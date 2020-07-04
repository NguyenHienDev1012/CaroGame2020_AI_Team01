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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Caro_Game));
            this.pnlOption = new System.Windows.Forms.Panel();
            this.pnlPlayer = new System.Windows.Forms.Panel();
            this.pnlValue = new System.Windows.Forms.Panel();
            this.lbUndo = new System.Windows.Forms.Label();
            this.btnUndo = new System.Windows.Forms.Button();
            this.pgbCoolDown = new System.Windows.Forms.ProgressBar();
            this.tbName = new System.Windows.Forms.TextBox();
            this.pnlStart = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rb_lan = new System.Windows.Forms.RadioButton();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.rbAI = new System.Windows.Forms.RadioButton();
            this.rbSolo = new System.Windows.Forms.RadioButton();
            this.pnlBoard = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlOption.SuspendLayout();
            this.pnlPlayer.SuspendLayout();
            this.pnlStart.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.pnlPlayer.Controls.Add(this.lbUndo);
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
            // lbUndo
            // 
            resources.ApplyResources(this.lbUndo, "lbUndo");
            this.lbUndo.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (128)))), ((int) (((byte) (128)))), ((int) (((byte) (255)))));
            this.lbUndo.Name = "lbUndo";
            // 
            // btnUndo
            // 
            resources.ApplyResources(this.btnUndo, "btnUndo");
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
            this.pnlStart.Controls.Add(this.panel1);
            resources.ApplyResources(this.pnlStart, "pnlStart");
            this.pnlStart.Name = "pnlStart";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.rb_lan);
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.rbAI);
            this.panel1.Controls.Add(this.rbSolo);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // rb_lan
            // 
            resources.ApplyResources(this.rb_lan, "rb_lan");
            this.rb_lan.ForeColor = System.Drawing.Color.Green;
            this.rb_lan.Name = "rb_lan";
            this.rb_lan.UseVisualStyleBackColor = true;
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
            // 
            // btnStart
            // 
            resources.ApplyResources(this.btnStart, "btnStart");
            this.btnStart.ForeColor = System.Drawing.Color.Blue;
            this.btnStart.Name = "btnStart";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // rbAI
            // 
            resources.ApplyResources(this.rbAI, "rbAI");
            this.rbAI.ForeColor = System.Drawing.Color.Red;
            this.rbAI.Name = "rbAI";
            this.rbAI.UseVisualStyleBackColor = true;
            // 
            // rbSolo
            // 
            resources.ApplyResources(this.rbSolo, "rbSolo");
            this.rbSolo.Checked = true;
            this.rbSolo.Name = "rbSolo";
            this.rbSolo.TabStop = true;
            this.rbSolo.UseVisualStyleBackColor = true;
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
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Caro_Game";
            this.pnlOption.ResumeLayout(false);
            this.pnlPlayer.ResumeLayout(false);
            this.pnlPlayer.PerformLayout();
            this.pnlStart.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Label lbUndo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ProgressBar pgbCoolDown;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlBoard;
        private System.Windows.Forms.Panel pnlOption;
        private System.Windows.Forms.Panel pnlPlayer;
        private System.Windows.Forms.Panel pnlStart;
        private System.Windows.Forms.Panel pnlValue;
        private System.Windows.Forms.RadioButton rb_lan;
        private System.Windows.Forms.RadioButton rbAI;
        private System.Windows.Forms.RadioButton rbSolo;
        private System.Windows.Forms.TextBox tbName;

        #endregion
    }
}