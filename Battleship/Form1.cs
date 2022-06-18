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

        private ThreadStart threadDelegate;
        private Thread newThread;
        private bool juego = true;
        private Ship barco = new Ship();
        private Generador gen = new Generador();
        private Comprobador cbp = new Comprobador();
        private Panel panelactual;
        private Board[]CampoJugadores = new Board[2];
        private int jugadorAct = 0;
        protected int status = 0;
        string filePath = Environment.CurrentDirectory;
        int Ax = 0;
        int Ay = 0;
        private int idx = 0;
        public BtlShip()
        {
            InitializeComponent();
            Empezar();
            load();
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
            Board campo1 =  gen.generarJuego(PlnGame);
            Board campo2 =  gen.generarJuego(PlnGame2);
            
            panelactual = PlnGame;
            for (int i = 0; i <campo1.getCampo().GetLength(0); i++)
            {
                for (int j = 0; j < campo1.getCampo().GetLength(1); j++)
                {
                    Label label = campo1.getCampo()[i, j];
                    PlnGame.Controls.Add( label );
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
            //setFocusable(true);
            //requestFocus();
            //addKeyListener(this);
            //SC.saveDirty();
            if (juego)
            {
                threadDelegate  = new ThreadStart( Thread_Run );
                newThread = new Thread(threadDelegate);
                newThread.Start();
            }
    
        }
        public void load()
        {
            string title = "Jugador 1";
            string text = "Coloque sus Barcos en la posicion deseada";
            MessageBox.Show(text, title);
        }
        public void Finalizar()
        {
           /* save.mLis();
            ListAnt.setModel(save.AddModel);
            SC.saveCleaned();
            SC.setPerce(JLprc.getText());*/
            juego = false;
            //PlnGame.removeAll();

        }

        public void Actualizar()
        {
            
            if (juego)
            {
                if(status == 0)
                {
                    
                    barco = gen.generarBarcos(panelactual, idx);
                    
                    
                    if (!cbp.getCondS(barco) )
                    {
                        gen.setBarco(barco, CampoJugadores[jugadorAct].getCampo());
                        status = 1;
                        idx++;
                    } 
                } else if (status == 1)
                {

                } else if (status == 2)
                {
                    gen.getMovement(barco, Ax, Ay);
                    repintarBarcos(barco);
                    status = 1;
                } else if(status == 3)
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
                } else if (status == 4)
                {
                    
                }
                else if (status == 5)
                {
                    repintarBarcos();

                }
                /* int porcentaje = gen.CheckPolvo();
                 JLprc.setText(String.valueOf(porcentaje) + "%");
                 gen.getPosition(Robot, Mov, MovPers);
                 MovPers = Mov;
                 gen.comprobar(Robot, "Polvo");
                 boolean game = gen.comprobar(Robot, "Obstaculos");
                 if (game)
                 {
                     resetMovement();

                 }

                 if (porcentaje == 0)
                 {
                     JOptionPane.showMessageDialog(null, "¡El salon esta limpio!");
                     snd.ReproducirSonidoyay();
                     Finalizar();
                *
                 }*/

            }
            /*if (((Robot.getX()) <= -10) || ((Robot.getY()) <= -30) || ((Robot.getY()) >= 350) || ((Robot.getX()) >= 370))
            {
                snd.ReproducirSonidono();
                resetMovement();
            }*/
        }


        private void repintarBarcos(Ship sp2 = null)
        {
            for (int j = 0; j < CampoJugadores[jugadorAct].Barcos.GetLength(1); j++)
            {
                Ship ship = CampoJugadores[jugadorAct].Barcos[jugadorAct, j];
                if(ship != null)
                {
                    setB(ship);
                }
                
            }
            if(sp2 != null)
            {
                setB(sp2);
            }
        }

        private void setB(Ship ship)
        {
            gen.setBarco(ship, CampoJugadores[jugadorAct].getCampo());
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            int tecla = e.KeyChar;

            Console.WriteLine(tecla == 'w');

            switch (tecla)
            {

                case 'w':
                    if (status == 1)
                    {
                        Ax = 0;
                        Ay = -1;
                        status = 2;
                    }
                    
                    break;
                case 'a':
                    if (status == 1)
                    {
                        Ax = -1;
                        Ay = 0;
                        status = 2;
                    }
                    break;
                case 's':
                    if (status == 1)
                    {
                        Ax = 0;
                        Ay = 1;
                        status = 2;
                    }
                    break;
                case 'd':
                    if (status == 1)
                    {
                        Ax = 1;
                        Ay = 0;
                        status = 2;

                    }
                    break;
                case 'r':
                    
                    status = 3;
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
                        status = 5;//Inicia la partida
                    }
                    break;
                case ' ':
                    if (status == 1)
                    {

                        Console.WriteLine("LA MAMADA MIJO");
                        cbp.setCondS(barco, jugadorAct);
                        if ((idx == barco.getBarcosTam()) && (jugadorAct == 1))
                        {
                            repintarPanel();
                            CambiarJugador();
                            status = 4;
                        } else {
                            if ((idx == barco.getBarcosTam()))
                            {
                                j2();
                            }
                            CambiarCambiarPanel();
                            status = 0;
                    }
                    }
                    
                    break;
            }
        }
        public void j2()
        {
            string titl = "Jugador 2";
            string tex = "Coloque sus Barcos en la posicion deseada";
            MessageBox.Show(tex, titl);
            /*CampoJugadores.SetValue(gen.generarJuego(PlnGame2), 1);
            panelactual = PlnGame2;*/
        }

        public void CambiarJugador()
        {
            if (jugadorAct == 1)
            {
                jugadorAct = 0;
            }
            else
            {
                jugadorAct = 1;
            }
        }

        public void repintarPanel()
        {
            for (int j = 0; j < CampoJugadores[jugadorAct].Barcos.GetLength(1); j++)
            {
                Ship ship = CampoJugadores[jugadorAct].Barcos[jugadorAct, j];
                if (ship != null)
                {

                    CampoJugadores[jugadorAct].repintar(ship);
                }
            }
        }

        public void CambiarCambiarPanel()
        {
            if (idx == barco.getBarcosTam())
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

                    repintarPanel();

                }
                else
                {
                    height = PlnGame2.Height;
                    width = PlnGame2.Width;
                    PlnGame2.Height = PlnGame.Height;
                    PlnGame2.Width = PlnGame.Width;
                    PlnGame.Height = height;
                    PlnGame.Width = width;

                    repintarPanel();
                }

                CambiarJugador();
                
                idx = 0;

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void PlnGame_Paint(object sender, PaintEventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (var soundPlayer = new SoundPlayer(filePath + @"\Sounds\hit.wav"))
            {
                soundPlayer.Play(); // can also use soundPlayer.PlaySync()
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var soundPlayer = new SoundPlayer(filePath + @"\Sounds\pium.wav"))
            {
                soundPlayer.Play(); // can also use soundPlayer.PlaySync()
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var soundPlayer = new SoundPlayer(filePath + @"\Sounds\explosion.wav"))
            {
                soundPlayer.Play(); // can also use soundPlayer.PlaySync()
            }
        }

        private void BtlShip_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }





}
