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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BtlShip));
            this.PlnGame = new System.Windows.Forms.PictureBox();
            this.PlnGame2 = new System.Windows.Forms.PictureBox();
            this.PlnLoad = new System.Windows.Forms.Panel();
            this.loadTime = new System.Windows.Forms.Timer(this.components);
            this.LblLoad = new System.Windows.Forms.Label();
            this.pBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.PlnGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlnGame2)).BeginInit();
            this.PlnLoad.SuspendLayout();
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
            // PlnLoad
            // 
            this.PlnLoad.Controls.Add(this.pBar);
            this.PlnLoad.Controls.Add(this.LblLoad);
            this.PlnLoad.Location = new System.Drawing.Point(2, 3);
            this.PlnLoad.Name = "PlnLoad";
            this.PlnLoad.Size = new System.Drawing.Size(1328, 520);
            this.PlnLoad.TabIndex = 7;
            // 
            // loadTime
            // 
            this.loadTime.Interval = 2000;
            this.loadTime.Tick += new System.EventHandler(this.loadTime_Tick);
            // 
            // LblLoad
            // 
            this.LblLoad.AutoSize = true;
            this.LblLoad.BackColor = System.Drawing.Color.Transparent;
            this.LblLoad.Font = new System.Drawing.Font("JetBrains Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLoad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LblLoad.Location = new System.Drawing.Point(545, 255);
            this.LblLoad.Name = "LblLoad";
            this.LblLoad.Size = new System.Drawing.Size(120, 21);
            this.LblLoad.TabIndex = 0;
            this.LblLoad.Text = "Cargando...";
            // 
            // pBar
            // 
            this.pBar.Location = new System.Drawing.Point(472, 325);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(291, 23);
            this.pBar.TabIndex = 1;
            // 
            // BtlShip
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(1333, 525);
            this.Controls.Add(this.PlnGame2);
            this.Controls.Add(this.PlnGame);
            this.Controls.Add(this.PlnLoad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BtlShip";
            this.Text = "Battleship";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BtlShip_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.PlnGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlnGame2)).EndInit();
            this.PlnLoad.ResumeLayout(false);
            this.PlnLoad.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox PlnGame;
        private System.Windows.Forms.PictureBox PlnGame2;
        private System.Windows.Forms.Panel PlnLoad;
        private System.Windows.Forms.Timer loadTime;
        private System.Windows.Forms.ProgressBar pBar;
        private System.Windows.Forms.Label LblLoad;
    }
}

