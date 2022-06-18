namespace Battleship
{
    partial class BtlShip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BtlShip));
            this.PlnGame = new System.Windows.Forms.Panel();
            this.PlnGame2 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // PlnGame
            // 
            this.PlnGame.BackColor = System.Drawing.SystemColors.Highlight;
            this.PlnGame.Location = new System.Drawing.Point(12, 12);
            this.PlnGame.Name = "PlnGame";
            this.PlnGame.Size = new System.Drawing.Size(500, 450);
            this.PlnGame.TabIndex = 0;
            this.PlnGame.Paint += new System.Windows.Forms.PaintEventHandler(this.PlnGame_Paint);
            // 
            // PlnGame2
            // 
            this.PlnGame2.BackColor = System.Drawing.SystemColors.Highlight;
            this.PlnGame2.Location = new System.Drawing.Point(530, 12);
            this.PlnGame2.Name = "PlnGame2";
            this.PlnGame2.Size = new System.Drawing.Size(274, 213);
            this.PlnGame2.TabIndex = 1;
            // 
            // BtlShip
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(1042, 477);
            this.Controls.Add(this.PlnGame2);
            this.Controls.Add(this.PlnGame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BtlShip";
            this.Text = "Battleship";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BtlShip_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PlnGame;
        private System.Windows.Forms.Panel PlnGame2;
    }
}

