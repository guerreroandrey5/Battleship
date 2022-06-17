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
    public partial class Form1 : Form
    {

        private ThreadStart threadDelegate;
        private Thread newThread;
        private bool juego = true;
        private Ship barco = new Ship();
        private Generador gen = new Generador();
        private Comprobador cbp= new Comprobador();
        private Panel panelactual;
        private Board[]CampoJugadores = new Board[2];
        private int jugadorAct = 0;
        protected int status = 0;
        string filePath = Environment.CurrentDirectory;
        int Ax = 0;
        int Ay = 0;
        private int idx = 0;
        public Form1()
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
            CampoJugadores.SetValue(gen.generarJuego(panel1),0);
            CampoJugadores.SetValue(gen.generarJuego(panel2),1);
            panelactual = panel1;
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
                    
                    
                    if (!cbp.getCondS(barco) && idx < barco.getBarcosTam())
                    {
                        gen.setBarco(barco, panelactual);
                        status = 1;
                        idx++;
                    } else if (idx == barco.getBarcosTam()) {
                        status = 1;
                        idx = 0;
                    }
                } else if (status == 1)
                {

                } else if (status == 2)
                {
                    gen.getMovement(barco, Ax, Ay);
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



        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            int tecla = e.KeyChar;

            Console.WriteLine(tecla == 'w');

            switch (tecla)
            {

                case 'w':
                    Ax = 0;
                    Ay = -1;
                    status = 2;
                    break;
                case 'a':
                    Ax = -1;
                    Ay = 0;
                    status = 2;
                    break;
                case 's':
                    Ax = 0;
                    Ay = 1;
                    status = 2; 
                    break;
                case 'd':
                    Ax = 1;
                    Ay = 0;
                    status = 2; 
                    break;
                case 'r':
                    
                    status = 3;
                    break;
                case ' ':
                    if (status == 1)
                    {
                        Console.WriteLine("LA MAMADA MIJO");
                        cbp.setCondS(barco);
                        status = 0;
                    }
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
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
    }





}
