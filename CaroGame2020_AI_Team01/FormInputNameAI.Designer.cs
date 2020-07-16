using System.ComponentModel;

namespace CaroGame2020_AI_Team01
{
    partial class FormInputNameAI
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
            System.Windows.Forms.Button btn_ok;
            System.Windows.Forms.Button btn_cancel;
            this.label1 = new System.Windows.Forms.Label();
            this.tb_player = new System.Windows.Forms.TextBox();
            btn_ok = new System.Windows.Forms.Button();
            btn_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_ok
            // 
            btn_ok.BackColor = System.Drawing.Color.Teal;
            btn_ok.Font = new System.Drawing.Font("Bell MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            btn_ok.ForeColor = System.Drawing.SystemColors.Control;
            btn_ok.Location = new System.Drawing.Point(259, 75);
            btn_ok.Name = "btn_ok";
            btn_ok.Size = new System.Drawing.Size(42, 27);
            btn_ok.TabIndex = 2;
            btn_ok.Text = "OK";
            btn_ok.UseVisualStyleBackColor = false;
            btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_cancel
            // 
            btn_cancel.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (192)))), ((int) (((byte) (64)))), ((int) (((byte) (0)))));
            btn_cancel.Font = new System.Drawing.Font("Bell MT", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            btn_cancel.ForeColor = System.Drawing.SystemColors.Control;
            btn_cancel.Location = new System.Drawing.Point(178, 75);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.Size = new System.Drawing.Size(63, 27);
            btn_cancel.TabIndex = 3;
            btn_cancel.Text = "Cancel";
            btn_cancel.UseVisualStyleBackColor = false;
            btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bell MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.Location = new System.Drawing.Point(25, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Player Name";
            // 
            // tb_player
            // 
            this.tb_player.Font = new System.Drawing.Font("Bell MT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.tb_player.Location = new System.Drawing.Point(131, 28);
            this.tb_player.Name = "tb_player";
            this.tb_player.Size = new System.Drawing.Size(170, 29);
            this.tb_player.TabIndex = 1;
            // 
            // FormInputNameAI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 125);
            this.ControlBox = false;
            this.Controls.Add(btn_cancel);
            this.Controls.Add(btn_ok);
            this.Controls.Add(this.tb_player);
            this.Controls.Add(this.label1);
            this.Name = "FormInputNameAI";
            this.Text = "Enter Player Name";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_player;

        #endregion
    }
}