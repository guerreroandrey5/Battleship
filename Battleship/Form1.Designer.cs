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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.PlnGame = new System.Windows.Forms.PictureBox();
            this.PlnGame2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PlnGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlnGame2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(917, 549);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "hit button test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(809, 549);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "pium button test";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(809, 578);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(99, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "explosion button";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
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
            this.ClientSize = new System.Drawing.Size(1333, 638);
            this.Controls.Add(this.PlnGame2);
            this.Controls.Add(this.PlnGame);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox PlnGame;
        private System.Windows.Forms.PictureBox PlnGame2;
    }
}

