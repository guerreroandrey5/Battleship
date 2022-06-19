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
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.LblLoad = new System.Windows.Forms.Label();
            this.loadTime = new System.Windows.Forms.Timer(this.components);
            this.LblCT = new System.Windows.Forms.Label();
            this.Turnos = new System.Windows.Forms.Label();
            this.LblCbr = new System.Windows.Forms.Label();
            this.LblBR = new System.Windows.Forms.Label();
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
            this.PlnLoad.Location = new System.Drawing.Point(2, 4);
            this.PlnLoad.Name = "PlnLoad";
            this.PlnLoad.Size = new System.Drawing.Size(1328, 519);
            this.PlnLoad.TabIndex = 7;
            // 
            // pBar
            // 
            this.pBar.Location = new System.Drawing.Point(472, 325);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(291, 23);
            this.pBar.TabIndex = 1;
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
            // loadTime
            // 
            this.loadTime.Interval = 2000;
            this.loadTime.Tick += new System.EventHandler(this.loadTime_Tick);
            // 
            // LblCT
            // 
            this.LblCT.AutoSize = true;
            this.LblCT.Font = new System.Drawing.Font("JetBrains Mono", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCT.ForeColor = System.Drawing.Color.Silver;
            this.LblCT.Location = new System.Drawing.Point(518, 12);
            this.LblCT.Name = "LblCT";
            this.LblCT.Size = new System.Drawing.Size(180, 19);
            this.LblCT.TabIndex = 2;
            this.LblCT.Text = "Cantidad de Turnos:\r\n";
            // 
            // Turnos
            // 
            this.Turnos.AutoSize = true;
            this.Turnos.BackColor = System.Drawing.Color.Transparent;
            this.Turnos.Font = new System.Drawing.Font("JetBrains Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Turnos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Turnos.Location = new System.Drawing.Point(704, 12);
            this.Turnos.Name = "Turnos";
            this.Turnos.Size = new System.Drawing.Size(20, 21);
            this.Turnos.TabIndex = 2;
            this.Turnos.Text = "1";
            // 
            // LblCbr
            // 
            this.LblCbr.AutoSize = true;
            this.LblCbr.BackColor = System.Drawing.Color.Transparent;
            this.LblCbr.Font = new System.Drawing.Font("JetBrains Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCbr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LblCbr.Location = new System.Drawing.Point(704, 48);
            this.LblCbr.Name = "LblCbr";
            this.LblCbr.Size = new System.Drawing.Size(20, 21);
            this.LblCbr.TabIndex = 8;
            this.LblCbr.Text = "5";
            // 
            // LblBR
            // 
            this.LblBR.AutoSize = true;
            this.LblBR.Font = new System.Drawing.Font("JetBrains Mono", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblBR.ForeColor = System.Drawing.Color.Silver;
            this.LblBR.Location = new System.Drawing.Point(518, 48);
            this.LblBR.Name = "LblBR";
            this.LblBR.Size = new System.Drawing.Size(162, 19);
            this.LblBR.TabIndex = 9;
            this.LblBR.Text = "Barcos Restantes:\r\n";
            // 
            // BtlShip
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(1333, 525);
            this.Controls.Add(this.PlnLoad);
            this.Controls.Add(this.LblCbr);
            this.Controls.Add(this.LblBR);
            this.Controls.Add(this.Turnos);
            this.Controls.Add(this.LblCT);
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
            this.PlnLoad.ResumeLayout(false);
            this.PlnLoad.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox PlnGame;
        private System.Windows.Forms.PictureBox PlnGame2;
        private System.Windows.Forms.Panel PlnLoad;
        private System.Windows.Forms.Timer loadTime;
        private System.Windows.Forms.ProgressBar pBar;
        private System.Windows.Forms.Label LblLoad;
        private System.Windows.Forms.Label LblCT;
        private System.Windows.Forms.Label Turnos;
        private System.Windows.Forms.Label LblCbr;
        private System.Windows.Forms.Label LblBR;
    }
}

