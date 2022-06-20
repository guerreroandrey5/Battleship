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
        private Generador gen = new Generador();
        private Comprobador cbp = new Comprobador();
        private PictureBox panelactual;
        private Board[]CampoJugadores = new Board[2];
        private int jugadorAct = 0;
        private int jA = 0;
        private int aimAct = 0;
        protected int status = 0;
        protected int aim = 0;
        protected int turnithing = 1;
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
        /*Esta funcion tiene el proposito de iniciar el juego, 
        inicializa y acutaliza los paneles de juegode cada jugador*/
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
        /*Esta funcion es la que hace que le juego "corra", al moverse los barcos
        los paneles deben ser actualizados para mostrar la nueva posicion de estos
        Ademas de ser la que "setea" los barcos en sus posiciones*/
        {
            if (juego)
            {
                if (status == 0)//Genera los barcos
                {
                    barco = gen.generarBarcos(panelactual, idx);
                    if (!cbp.getCondS(barco))
                    {
                        gen.setBarco(barco, CampoJugadores[jugadorAct].getCampo(), 50);
                        status = 1;
                        idx++;
                    }
                }
                else if (status == 1)//Genera el movimiento de los barcos
                {

                }
                else if (status == 2)//Genera la rotación de los barcos
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
                else if (status == 5)//Se utiliza al iniciar la partida
                {
                    repintarBarcos(30);
                    barco = gen.generarBarcos(panelactual, 6);
                    gen.setBarco(barco, CampoJugadores[aimAct].getCampo(), 50);
                    CambiarJugador();
                    showLbl();
                    aim = 1;
                    status = 6;
                }
                else if (status == 6)
                {
                   
                }
                else if (status == 7)//Genera movimiento para los barcos del otro jugador
                {
                    gen.getMovement(barco, Ax, Ay);
                    
                   
                    repintarDamage(50);
                    setB(barco, 50);
                    status = 6;
                }
            }
        }
        public void showLbl()//Funcion que muestra los labels del contador de barcos destruidos
        {
            if (LblBR.InvokeRequired)
            {
                LblBR.Invoke(new MethodInvoker(delegate
                {
                    LblBR.Show();
                }));
            }
            else
            {
                LblBR.Show();
            }

            if (LblCbr.InvokeRequired)
            {
                LblCbr.Invoke(new MethodInvoker(delegate
                {
                    LblCbr.Show();
                }));
            }
            else
            {
                LblCbr.Show();
            }
        }
        private void repintarBarcos(int s ,Ship sp2 = null)//Funcion encargada de mostrar los barco en pantalla
        {
            for (int j = 0; j < CampoJugadores[jugadorAct].Barcos.GetLength(1); j++)
            {
                Ship ship = CampoJugadores[jugadorAct].Barcos[jugadorAct, j];
                if (ship != null)
                {
                    setB(ship, s);
                }
            }
            repintarDamage(s);
            if (sp2 != null)
            {
                setB(sp2, s);
            }
        }

        private void repintarDamage(int s)
        {
            for (int i = 0; i < CampoJugadores[jugadorAct].Disparos[jA].GetLength(0); i++)
            {
                for (int j = 0; j < CampoJugadores[jugadorAct].Disparos[jA].GetLength(1); j++)
                {
                    Ship fuego = CampoJugadores[jugadorAct].Disparos[jA][i, j];
                    if (fuego != null)
                    {
                        gen.setFire(fuego, CampoJugadores[jugadorAct].getCampo(),s, barco,  jA);
                    }
                }
            }
        }

        private void setB(Ship ship, int size)
        {
            gen.setBarco(ship,  CampoJugadores[jugadorAct].getCampo(), size);
        }

        #region Teclas
        /*En esta region se encuentran los controles del juego*/
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            int tecla = e.KeyChar;
            switch (tecla)
            {
                case 'w'://Mueve el barco una posicion arriba                     
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

                case 'a'://Mueve el barco una posicion a la izquierda                    
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

                case 's'://Mueve el barco una posicion abajo                    
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

                case 'd'://Mueve el barco una posicion a la derecha             
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

                case 'r'://Rota el barco
                    if (status == 1)
                    {

                        status = 3;
                    }
                    break;

                case 'x'://Muestra un mensaje de advertencia, si este se acepta cierra el juego
                    string message = "Esta Seguro de Salir?";
                    string title = "Advertencia";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        this.Close();
                    }
                    break;

                case 'i'://Muestra un mensaje de advertencia, si este se acepta, inicia la partida
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

                case ' '://Dispara/Coloca los barcos en la posicion deseada
                    if (status == 1)
                    {
                        bool cond = true;
                        for (int i = 0; i < CampoJugadores[jugadorAct].Barcos.GetLength(1); i++)
                        {
                            Ship cS = CampoJugadores[jugadorAct].Barcos[jugadorAct, i];
                            if(cS!= null)
                            {
                                cond = cbp.comprobrarChoque(barco, cS);
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
                            barco.sethealth(barco.getFormaAct().Length/2);
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
                                    j2();
                                }
                                CambiarCambiarPanel();
                                gen.changeTam(50, CampoJugadores[jugadorAct].getCampo());
                                status = 0;
                            }
                        }                                         
                    }
                    if (aim == 1)
                    {
                        bool shootC = true;
                        for (int i = 0; i < CampoJugadores[jugadorAct].Disparos[jugadorAct].GetLength(0); i++)
                        {
                            for (int j = 0; j < CampoJugadores[jugadorAct].Disparos[jugadorAct].GetLength(1); j++)
                            {
                                Ship fuego = CampoJugadores[jugadorAct].Disparos[jugadorAct][i, j];
                                if (fuego != null)
                                {
                                    shootC = cbp.comprobrarChoque(barco, fuego);
                                }
                                
                                if (!shootC)
                                {
                                    break;
                                }
                            }
                            if (!shootC)
                            {
                                break;
                            }


                        }
                        if(shootC)
                        {
                            shoot();
                        }
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
        /*Funcion que compara la posicion de la "mira" y los barcos en los paneles
        Segun lo que retorne sonara un sonido de "disparo o un "splash" alertando
        que fallo el tiro*/
        {
            Ship fire = gen.generarBarcos(panelactual, 6);
            if (jugadorAct == 1)
            {
                jA = 1;
            }
            if (jugadorAct == 0)
            {
                jA = 0;
            }
            bool cond = true;
            bool ded = false;
            for (int i = 0; i < CampoJugadores[jugadorAct].Barcos.GetLength(1); i++)
            {
                Ship cS = CampoJugadores[jugadorAct].Barcos[jA, i];
                if (cS != null)
                {
                    cond = cbp.comprobrarChoque(barco, cS);
                    if ((!cond)&&(cS.gethealth() != 0))
                    {
                        cS.sethealth(cS.gethealth() - 1);                       
                        sP("pium");
                        if (cS.gethealth() == 0)
                        {
                            ded = true;
                            //CampoJugadores[jugadorAct].setboatd(CampoJugadores[jugadorAct].getboatd() + 1); //esta linea es la que cuenta los barcos destruidos
                            CampoJugadores[jugadorAct].setCbar(CampoJugadores[jugadorAct].getCbar() - 1);
                        }
                        gen.setFireLocation(fire, barco);
                        gen.setFire(fire, CampoJugadores[jugadorAct].getCampo(), 50, barco, jA);
                        fire.setFire(fire, jA);
                        break;
                    }
                }
            }
            if (ded)
            {
                sP("explosion");
            }
            if (cond)
            {
                sP("splash");
                turnithing++;
                loadload();
                
                CambiarJugador();
                repintarPanel(50);
                CambiarCambiarPanel();
                ocultarMira(30);
                gen.changeTam(50, CampoJugadores[jugadorAct].getCampo());
                status = 5;
                if (Turnos.InvokeRequired)
                {
                    Turnos.Invoke(new MethodInvoker(delegate
                    {
                        Turnos.Text = turnithing.ToString();
                    }));
                }
                else
                {
                    Turnos.Text = turnithing.ToString();
                }

                if (LblCbr.InvokeRequired)
                {
                    LblCbr.Invoke(new MethodInvoker(delegate
                    { 
                    LblCbr.Text = CampoJugadores[jugadorAct].getCbar().ToString();
                    }));
                }
                else
                {
                    LblCbr.Text = CampoJugadores[jugadorAct].getCbar().ToString();
                }
            }
        }

        public void j2()//Un simple mensaje que alerta cuando es turno del segundo jugador
        {
            string titl = "Jugador 2";
            string tex = "Coloque sus Barcos en la posicion deseada";
            MessageBox.Show(tex, titl);
        }

        public void j1()//Un simple mensaje que alerta cuando es turno del primer jugador
        {
            string title = "Jugador 1";
            string text = "Coloque sus Barcos en la posicion deseada";
            MessageBox.Show(text, title);
        }

        public void CambiarJugador()//Funcion que cambia los jugadores
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
        public void repintarPanel(int s)//Funcion que "repinta" los paneles de juego
        {
            for (int j = 0; j < CampoJugadores[jugadorAct].Barcos.GetLength(1); j++)
            {
                Ship ship = CampoJugadores[jugadorAct].Barcos[jugadorAct, j];              
                if (ship != null)
                {
                    CampoJugadores[jugadorAct].repintar(ship, s);
                }
            }
            
            actualizarPanel();
        }

        public void ocultarMira(int s)//Funcion que "repinta" los paneles de juego
        {
            
                if (barco != null)
                {
                    CampoJugadores[jugadorAct].repintar(barco, s);
                }
            
            actualizarPanel();
        }

        public void actualizarPanel()//Funcion que actualiza los paneles de juego
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

        public void LimpiarPanel(int s)//Funcion que limpia los paneles al cambiar de jugador
        {
            CampoJugadores[jugadorAct].GenerarCampo(s, null, CampoJugadores[jugadorAct].getCampo());               
        }

        public void CambiarCambiarPanel()//Funcion que modifica el tamaño de los paneles de juego al cambiar de jugador
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
            LblBR.Hide();
            LblCbr.Hide();
        }

        private void PlnGame_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sP(string audio)//Funcion que carga los sonidos segun el parametro que reciba
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
                //comente esto porque no estoy seguro si sea necesario, llega a ser molesto
                //if (jugadorAct == 0)
                //{
                //    j1();
                //}
                //if (jugadorAct == 1)
                //{
                //    j2();
                //}
            }
        }
    }
}