using Battleship.Logica;
using Battleship.Logica.Negociacion;
using Battleship.Logica.Objetos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship
{
    public partial class BtlShip : Form
    {
        private delegate void SafeCallDelegate(string text);
        private ImagenManagment imgMgn = new ImagenManagment();
        private ThreadStart threadDelegate;
        private Thread newThread;
        private bool juego = true;
        private Ship barco = new Ship();
        private Ship aIm = new Ship();
        private Generador gen = new Generador();
        private Comprobador cbp = new Comprobador();
        private PictureBox panelactual;
        private Board[]CampoJugadores = new Board[2];
        private int jugadorAct = 0;
        private int jA = 0;
        private int aimAct = 0;
        protected int status = 0;
        protected int aim = 0;
        string filePath = Environment.CurrentDirectory;
        int Ax = 0;
        int Ay = 0;
        private int idx = 0;
        Ship aimz;
        public BtlShip()
        {
            InitializeComponent();
            Empezar();
        }

        public void Thread_Run()
        {
            while (true)
            {
                Actualizar();
                try
                {
                    Thread.Sleep(90);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void Empezar()
        {
            actualizarPanel();
            Board campo1 =  gen.generarJuego(PlnGame, 50);
            Board campo2 =  gen.generarJuego(PlnGame2, 30);           
            panelactual = PlnGame;
            for (int i = 0; i < campo1.getCampo().GetLength(0); i++)
            {
                for (int j = 0; j < campo1.getCampo().GetLength(1); j++)
                {
                    Label label = campo1.getCampo()[i, j];
                    PlnGame.Controls.Add(label);
                }
            }
            for (int i = 0; i < campo2.getCampo().GetLength(0); i++)
            {
                for (int j = 0; j < campo2.getCampo().GetLength(1); j++)
                {
                    Label label = campo2.getCampo()[i, j];
                    PlnGame2.Controls.Add(label);
                }
            }
            CampoJugadores.SetValue(campo1, 0);
            CampoJugadores.SetValue(campo2, 1);
            if (juego)
            {
                threadDelegate = new ThreadStart(Thread_Run);
                newThread = new Thread(threadDelegate);
                newThread.Start();
            }
        }

        public void Finalizar()
        {
            juego = false;
        }

        public void Actualizar()
        {
            if (juego)
            {
                if (status == 0)
                {
                    barco = gen.generarBarcos(panelactual, idx);
                    if (!cbp.getCondS(barco))
                    {
                        gen.setBarco(barco, CampoJugadores[jugadorAct].getCampo(), 50);
                        status = 1;
                        idx++;
                    }
                }
                else if (status == 1)
                {

                }
                else if (status == 2)
                {
                    gen.getMovement(barco, Ax, Ay);
                    repintarBarcos(50 , barco);
                    status = 1;
                }
                else if (status == 3)
                {
                    int rot = 0;
                    switch (barco.getOri())
                    {
                        case 0:
                            rot = 90;
                            break;
                        case 90:
                            rot = 180;
                            break;
                        case 180:
                            rot = 270;
                            break;
                        case 270:
                            rot = 0;
                            break;
                    }
                    gen.Rotate(barco, rot);
                    status = 1;
                }
                else if (status == 4)
                {

                }
                else if (status == 5)
                {
                    repintarBarcos(30);
                    barco = gen.generarBarcos(panelactual, 6);
                    gen.setBarco(barco, CampoJugadores[aimAct].getCampo(), 50);
                    CambiarJugador();
                    aim = 1;
                    status = 6;
                }
                else if (status == 6)
                {
                   
                }
                else if (status == 7)
                {
                    gen.getMovement(barco, Ax, Ay);
                    setB( barco, 50);
                    status = 6;
                }
            }
        }

        private void repintarBarcos(int s ,Ship sp2 = null)
        {
            for (int j = 0; j < CampoJugadores[jugadorAct].Barcos.GetLength(1); j++)
            {
                Ship ship = CampoJugadores[jugadorAct].Barcos[jugadorAct, j];
                if (ship != null)
                {
                    setB(ship, s);
                }
            }
            if (sp2 != null)
            {
                setB(sp2, s);
            }
        }

        private void setB(Ship ship, int size)
        {
            gen.setBarco(ship,  CampoJugadores[jugadorAct].getCampo(), size);
        }

        #region Teclas
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            int tecla = e.KeyChar;
            switch (tecla)
            {
                case 'w':                   
                        Ax = 0;
                        Ay = -1;
                    if (status == 1)
                    {
                        status = 2;
                    } else if (status == 6)
                    {
                        status = 7;
                    }
                    break;

                case 'a':                  
                        Ax = -1;
                        Ay = 0;
                    if (status == 1)
                    {
                        status = 2;
                    }
                    else if (status == 6)
                    {
                        status = 7;
                    }
                    break;

                case 's':                  
                        Ax = 0;
                        Ay = 1;
                        if (status == 1)
                        {
                            status = 2;
                        }
                        else if (status == 6)
                        {
                            status = 7;
                        }
                        break;

                case 'd':             
                        Ax = 1;
                        Ay = 0;
                        if (status == 1)
                        {
                            status = 2;
                        }
                        else if (status == 6)
                        {
                            status = 7;
                        }                   
                    break;

                case 'r':
                    if(status == 1)
                    {

                        status = 3;
                    }
                    break;

                case 'x':
                    string message = "Esta Seguro de Salir?";
                    string title = "Advertencia";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        this.Close();
                    }
                    break;

                case 'i':
                    string messag = "Esta Seguro de Iniciar la Partida?";
                    string titl = "Advertencia";
                    MessageBoxButtons button = MessageBoxButtons.YesNo;
                    DialogResult resul = MessageBox.Show(messag, titl, button, MessageBoxIcon.Warning);
                    if (resul == DialogResult.Yes)
                    {
                        string messa = "Apunte a donde creas que se encuentra un barco enemigo";
                        string tit = "Atención";
                        MessageBox.Show(messa, tit);
                        status = 5;                                            
                    }
                    break;

                case ' ':
                    if (status == 1)
                    {
                        bool cond = true;
                        for (int i = 0; i < CampoJugadores[jugadorAct].Barcos.GetLength(1); i++)
                        {
                            Ship cS = CampoJugadores[jugadorAct].Barcos[jugadorAct, i];
                            if(cS!= null)
                            {

                               // cond = cbp.comprobrarChoque(barco, cS);
                                if (!cond)
                                {
                                    sP("Uff");
                                    break;
                                }
                            }
                        }
                        if (cond)
                        {
                            sP("setBoat");
                            cbp.setCondS(barco, jugadorAct);
                            if ((idx == barco.getBarcosTam() - 1) && (jugadorAct == 1))
                            {
                                loadload();
                                repintarPanel(50);
                                CambiarJugador();
                                status = 4;
                            }
                            else
                            {
                                if ((idx == barco.getBarcosTam() - 1))
                                {
                                    loadload();                                                                     
                                }
                                CambiarCambiarPanel();
                                gen.changeTam(50, CampoJugadores[jugadorAct].getCampo());
                                status = 0;
                            }
                        }                                         
                    }
                    if (aim == 1)
                    {
                        shoot();
                    }
                    break;
            }
        }
        public void loadload()
        {
            unload();
            loadTime.Start();
            load();
        }
        #endregion
        public void shoot()
        {            
            if (jugadorAct == 1)
            {
                jA = 1;
            }
            if (jugadorAct == 0)
            {
                jA = 0;
            }
            bool cond = true;
            for (int i = 0; i < CampoJugadores[jugadorAct].Barcos.GetLength(1); i++)
            {
                Ship cS = CampoJugadores[jugadorAct].Barcos[jA, i];
                if (cS != null)
                {
                    aIm = gen.generarBarcos(panelactual, 1);
                    cond = cbp.comprobrarChoque(barco, cS);
                    if (!cond)
                    {
                        sP("pium");
                        break;
                    }
                }
            }
            
            if (cond)
            {
                sP("splash");

                CambiarJugador();
                repintarPanel(50);
                CambiarCambiarPanel();
                gen.changeTam(50, CampoJugadores[jugadorAct].getCampo());
                status = 5;
            }
        }

        public void j2()
        {
            string titl = "Jugador 2";
            string tex = "Coloque sus Barcos en la posicion deseada";
            MessageBox.Show(tex, titl);
        }

        public void j1()
        {
            string title = "Jugador 1";
            string text = "Coloque sus Barcos en la posicion deseada";
            MessageBox.Show(text, title);
        }

        public void CambiarJugador()
        {
            if (jugadorAct == 1)
            {
                panelactual = PlnGame;
                jugadorAct = 0;
                aimAct = 1;
            }
            else
            {
                panelactual = PlnGame2;
                jugadorAct = 1;
                aimAct = 0;
            }
        }

        public void unload()
        {
            PlnLoad.Show();
            PlnGame.Hide();          
            PlnGame2.Hide();
        }
        public void load()
        {
            PlnGame.Show();
            PlnGame2.Show();
        }
        public void repintarPanel(int s)
        {
            for (int j = 0; j < CampoJugadores[jugadorAct].Barcos.GetLength(1); j++)
            {
                Ship ship = CampoJugadores[jugadorAct].Barcos[jugadorAct, j];              
                if (ship != null)
                {
                    CampoJugadores[jugadorAct].repintar(ship, s);
                    aimz = CampoJugadores[aimAct].Barcos[aimAct, 6];
                }
            }
            actualizarPanel();
        }

        public void actualizarPanel()
        {
            PlnGame.Invalidate();
            PlnGame.Refresh();
            PlnGame2.Invalidate();
            PlnGame2.Refresh();

            if (PlnGame.InvokeRequired)
            {
                PlnGame.Invoke(new MethodInvoker(delegate
                {
                    PlnGame.BackgroundImage = (Image)imgMgn.ResizeImage(Image.FromFile(filePath + @"\Imagenes\mar.png"), PlnGame.Width, PlnGame.Height);
                }));
            } else
            {
                PlnGame.BackgroundImage = (Image)imgMgn.ResizeImage(Image.FromFile(filePath + @"\Imagenes\mar.png"), PlnGame.Width, PlnGame.Height);
               
            }
            if (PlnGame2.InvokeRequired)
            {
                PlnGame2.Invoke(new MethodInvoker(delegate
                {                  
                    PlnGame2.BackgroundImage = (Image)imgMgn.ResizeImage(Image.FromFile(filePath + @"\Imagenes\mar.png"), PlnGame2.Width, PlnGame2.Height);
                }));
            }
            else
            {
                PlnGame2.BackgroundImage = (Image)imgMgn.ResizeImage(Image.FromFile(filePath + @"\Imagenes\mar.png"), PlnGame2.Width, PlnGame2.Height);
            }
        }

        public void LimpiarPanel(int s)
        {
            CampoJugadores[jugadorAct].GenerarCampo(s, null, CampoJugadores[jugadorAct].getCampo());               
        }

        public void CambiarCambiarPanel()
        {
            if (idx == barco.getBarcosTam() - 1 || status == 6)
            {
                int height, width;
                if (PlnGame.Width > PlnGame2.Width)
                {
                    height = PlnGame.Height;
                    width = PlnGame.Width;
                    PlnGame.Height = PlnGame2.Height;
                    PlnGame.Width = PlnGame2.Width;
                    PlnGame2.Height = height;
                    PlnGame2.Width = width;
                    repintarPanel(30);
                }
                else
                {
                    height = PlnGame2.Height;
                    width = PlnGame2.Width;
                    PlnGame2.Height = PlnGame.Height;
                    PlnGame2.Width = PlnGame.Width;
                    PlnGame.Height = height;
                    PlnGame.Width = width;
                    repintarPanel(30);
                }
                CambiarJugador();
                idx = 0;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            PlnLoad.Hide();
        }

        private void PlnGame_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sP(string audio)
        {
            using (var soundPlayer = new SoundPlayer(filePath + @"\Sounds\"+ audio +".wav"))
            {
                soundPlayer.Play();
            }
        }

        private void BtlShip_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void loadTime_Tick(object sender, EventArgs e)
        {
            if (pBar.Value < 100)
            {
                pBar.Value += 100;
                LblLoad.Text = LblLoad.Text + " " + pBar.Value.ToString() + "%";
            }
            else
            {
                loadTime.Stop();
                PlnLoad.Hide();
                if (jugadorAct == 0)
                {
                    j1();
                }
                if (jugadorAct == 1)
                {
                    j2();
                }
            }
        }
    }
}