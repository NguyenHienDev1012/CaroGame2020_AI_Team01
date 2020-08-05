using System.ComponentModel;

namespace CaroGame2020_AI_Team01
{
    partial class ShowScoreBoard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.AutoSize = true;
            this.pnlMain.Location = new System.Drawing.Point(1, 2);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(678, 525);
            this.pnlMain.TabIndex = 0;
            // 
            // ShowScoreBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(682, 528);
            this.Controls.Add(this.pnlMain);
            this.Name = "ShowScoreBoard";
            this.Text = "ShowScoreBoard";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel pnlMain;

        #endregion
    }
}