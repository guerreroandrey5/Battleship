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
            this.PlnGame = new System.Windows.Forms.PictureBox();
            this.PlnGame2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PlnGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlnGame2)).BeginInit();
            this.SuspendLayout();
            // 
            // PlnGame
            // 
            this.PlnGame.Location = new System.Drawing.Point(12, 12);
            this.PlnGame.Name = "PlnGame";
            this.PlnGame.Size = new System.Drawing.Size(500, 500);
            this.PlnGame.TabIndex = 5;
            this.PlnGame.TabStop = false;
            // 
            // PlnGame2
            // 
            this.PlnGame2.Location = new System.Drawing.Point(821, 12);
            this.PlnGame2.Name = "PlnGame2";
            this.PlnGame2.Size = new System.Drawing.Size(300, 300);
            this.PlnGame2.TabIndex = 6;
            this.PlnGame2.TabStop = false;
            // 
            // BtlShip
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(1333, 525);
            this.Controls.Add(this.PlnGame2);
            this.Controls.Add(this.PlnGame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BtlShip";
            this.Text = "Battleship";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BtlShip_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.PlnGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlnGame2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox PlnGame;
        private System.Windows.Forms.PictureBox PlnGame2;
    }
}

