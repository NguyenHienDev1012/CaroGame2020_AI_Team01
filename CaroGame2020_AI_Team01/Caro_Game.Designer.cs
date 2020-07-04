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
            this.pnlOption = new System.Windows.Forms.Panel();
            this.pnlPlayer = new System.Windows.Forms.Panel();
            this.pnlValue = new System.Windows.Forms.Panel();
            this.lbUndo = new System.Windows.Forms.Label();
            this.btnUndo = new System.Windows.Forms.Button();
            this.pgbCoolDown = new System.Windows.Forms.ProgressBar();
            this.tbName = new System.Windows.Forms.TextBox();
            this.pnlStart = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.pnlOption.Location = new System.Drawing.Point(492, 199);
            this.pnlOption.Name = "pnlOption";
            this.pnlOption.Size = new System.Drawing.Size(301, 233);
            this.pnlOption.TabIndex = 2;
            // 
            // pnlPlayer
            // 
            this.pnlPlayer.BackColor = System.Drawing.SystemColors.Control;
            this.pnlPlayer.Controls.Add(this.pnlValue);
            this.pnlPlayer.Controls.Add(this.lbUndo);
            this.pnlPlayer.Controls.Add(this.btnUndo);
            this.pnlPlayer.Controls.Add(this.pgbCoolDown);
            this.pnlPlayer.Controls.Add(this.tbName);
            this.pnlPlayer.Location = new System.Drawing.Point(3, 111);
            this.pnlPlayer.Name = "pnlPlayer";
            this.pnlPlayer.Size = new System.Drawing.Size(295, 119);
            this.pnlPlayer.TabIndex = 1;
            // 
            // pnlValue
            // 
            this.pnlValue.BackColor = System.Drawing.SystemColors.Control;
            this.pnlValue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlValue.Location = new System.Drawing.Point(156, 3);
            this.pnlValue.Name = "pnlValue";
            this.pnlValue.Size = new System.Drawing.Size(136, 113);
            this.pnlValue.TabIndex = 4;
            // 
            // lbUndo
            // 
            this.lbUndo.AutoSize = true;
            this.lbUndo.Font = new System.Drawing.Font("Bell MT", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lbUndo.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (128)))), ((int) (((byte) (128)))), ((int) (((byte) (255)))));
            this.lbUndo.Location = new System.Drawing.Point(37, 91);
            this.lbUndo.Name = "lbUndo";
            this.lbUndo.Size = new System.Drawing.Size(39, 17);
            this.lbUndo.TabIndex = 3;
            this.lbUndo.Text = "Undo";
            // 
            // btnUndo
            // 
            this.btnUndo.Location = new System.Drawing.Point(80, 81);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(42, 32);
            this.btnUndo.TabIndex = 2;
            this.btnUndo.UseVisualStyleBackColor = true;
            // 
            // pgbCoolDown
            // 
            this.pgbCoolDown.Location = new System.Drawing.Point(9, 49);
            this.pgbCoolDown.Name = "pgbCoolDown";
            this.pgbCoolDown.Size = new System.Drawing.Size(140, 26);
            this.pgbCoolDown.TabIndex = 1;
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("Bell MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.tbName.Location = new System.Drawing.Point(9, 13);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(141, 26);
            this.tbName.TabIndex = 0;
            // 
            // pnlStart
            // 
            this.pnlStart.BackColor = System.Drawing.SystemColors.Control;
            this.pnlStart.Controls.Add(this.btnExit);
            this.pnlStart.Controls.Add(this.btnNew);
            this.pnlStart.Controls.Add(this.panel1);
            this.pnlStart.Location = new System.Drawing.Point(3, 3);
            this.pnlStart.Name = "pnlStart";
            this.pnlStart.Size = new System.Drawing.Size(295, 102);
            this.pnlStart.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Bell MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btnExit.Location = new System.Drawing.Point(213, 51);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(67, 40);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "EXIT";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Bell MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btnNew.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (0)))), ((int) (((byte) (192)))), ((int) (((byte) (0)))));
            this.btnNew.Location = new System.Drawing.Point(213, 10);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(67, 40);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "NEW";
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.rbAI);
            this.panel1.Controls.Add(this.rbSolo);
            this.panel1.Location = new System.Drawing.Point(9, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(187, 81);
            this.panel1.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Bell MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btnStart.ForeColor = System.Drawing.Color.Blue;
            this.btnStart.Location = new System.Drawing.Point(61, 46);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(67, 32);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // rbAI
            // 
            this.rbAI.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.rbAI.Font = new System.Drawing.Font("Bell MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.rbAI.ForeColor = System.Drawing.Color.Red;
            this.rbAI.Location = new System.Drawing.Point(112, 5);
            this.rbAI.Name = "rbAI";
            this.rbAI.Size = new System.Drawing.Size(58, 35);
            this.rbAI.TabIndex = 1;
            this.rbAI.Text = "AI";
            this.rbAI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbAI.UseVisualStyleBackColor = true;
            // 
            // rbSolo
            // 
            this.rbSolo.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.rbSolo.Checked = true;
            this.rbSolo.Font = new System.Drawing.Font("Bell MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.rbSolo.Location = new System.Drawing.Point(15, 3);
            this.rbSolo.Name = "rbSolo";
            this.rbSolo.Size = new System.Drawing.Size(58, 37);
            this.rbSolo.TabIndex = 0;
            this.rbSolo.TabStop = true;
            this.rbSolo.Text = "1 vs 1";
            this.rbSolo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbSolo.UseVisualStyleBackColor = true;
            // 
            // pnlBoard
            // 
            this.pnlBoard.Location = new System.Drawing.Point(8, 11);
            this.pnlBoard.Name = "pnlBoard";
            this.pnlBoard.Size = new System.Drawing.Size(480, 421);
            this.pnlBoard.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::CaroGame2020_AI_Team01.Properties.Resources.icon_large;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(492, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(298, 187);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // Caro_Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 439);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pnlBoard);
            this.Controls.Add(this.pnlOption);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Caro_Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CARO GAME";
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
        private System.Windows.Forms.RadioButton rbAI;
        private System.Windows.Forms.RadioButton rbSolo;
        private System.Windows.Forms.TextBox tbName;

        #endregion
    }
}