using Battleship.Logica.Negociacion;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship.Logica.Objetos
{
    internal class Board
    {
        private Label[,] campo = new Label[10, 10];
        private static int tam = 7;
        private static Ship[,] barcos = new Ship[2, tam];
        private static Ship[][,] disparos = new Ship[2][,];
        private static Ship[,] disparos1  = new Ship[10,10];
        private static Ship[,] disparos2 = new Ship[10, 10];
        protected static string[][,] imagesS = new string[7][,];
        private ImagenManagment imgMgnt = new ImagenManagment();
        private int[][,] formas = new int[7][,];
        string filePath =  Directory.GetCurrentDirectory();
        protected int cbar = 5;
        protected int boatd = 0;
        private static bool initiated = false;
        public Ship[,] Barcos
        {
            get { return barcos; }
        }

        public Ship[][,] Disparos
        {
            get { return disparos; }
        }
        public int getCbar()
        {
            return cbar; 
        }
        public void setCbar(int Cbar)
        {
            cbar = Cbar;
        }
        public void setboatd(int boat)
        {
            boatd = boat;
        }
        public int getboatd()
        {
            return boatd;
        }
      
        public Board()
        {
            setformas();
        }

        public Board(PictureBox panel, int tam)
        {
            GenerarCampo(tam, panel);
        }

        private void setformas()
        /*Funcion que define arrays para las imagenes y las dimensiones que utlizaran*/
        {
            #region Arrays
            int[,] array1 = { { 0, 0 }, { 1, 0 } };
            int[,] array2 = { { 0, 1 }, { 1, 1 }, { 2, 1 } };
            int[,] array3 = { { 0, 1 }, { 1, 1 }, { 2, 1 },{ 1, 0 } };
            int[,] array4 = { { 0, 1 }, { 1, 1 }, { 2, 1 }, { 3, 1 } };
            int[,] array5 = { { 0, 1 }, { 1, 1 }, { 2, 1 }, { 3, 1 }, { 4, 1 } };
            int[,] array6 = { { 0, 2 }, { 1, 2 }, { 2, 2 }, { 1, 1 }, { 2, 1 }, { 3, 1 } };
            int[,] array7 = { { 0, 0 } };
            #endregion
            #region Matrices de Imagenes
            string[,] imagen1 = { { "L1", "L2" },
                                { "90_L1", "90_L2" },
                                { "180_L1", "180_L2" },
                                { "270_L1", "270_L2" }};
            string[,] imagen2 ={ { "LL1", "LL2","LL3" },
                                { "90_LL1", "90_LL2","90_LL3" },
                                { "180_LL1", "180_LL2","180_LL3" },
                                { "270_LL1", "270_LL2","270_LL3" }};
            string[,] imagen3 ={ { "Sub1", "Sub2","Sub3", "Sub4" },
                                { "90_Sub1", "90_Sub2","90_Sub3", "90_Sub4" },
                                { "180_Sub1", "180_Sub2","180_Sub3", "180_Sub4" },
                                { "270_Sub1", "270_Sub2","270_Sub3", "270_Sub4" }};
            string[,] imagen4 ={ { "BG1", "BG2","BG3", "BG4" },
                                { "90_BG1", "90_BG2","90_BG3", "90_BG4" },
                                { "180_BG1", "180_BG2","180_BG3", "180_BG4" },
                                { "270_BG1", "270_BG2","270_BG3", "270_BG4" }};
            string[,] imagen5 = { { "AC1", "AC2","AC3", "AC4", "AC5" },
                                { "90_AC1", "90_AC2","90_AC3", "90_AC4", "90_AC5" },
                                { "180_AC1", "180_AC2","180_AC3", "180_AC4", "180_AC5" },
                                { "270_AC1", "270_AC2","270_AC3", "270_AC4", "270_AC5" }};
            string[,] imagen6 = { { "PA1", "PA2", "PA3", "PA4", "PA5", "PA6" },
                                  { "R_PA1", "R_PA2", "R_PA3", "R_PA4", "R_PA5", "R_PA6" } };
            string[,] imagen7 = { { "crosshair" } };
            #endregion 
            //Se definen los nombres de los archivos
            #region Declaraciones de Arrays e Imagenes

            disparos[0] = disparos1;
            disparos[1] = disparos2;

            formas[0] = array1;
            formas[1] = array2;
            formas[2] = array3;
            formas[3] = array4;
            formas[4] = array5;
            formas[5] = array6;
            formas[6] = array7;

            imagesS[0] = imagen1;
            imagesS[1] = imagen2;
            imagesS[2] = imagen3;
            imagesS[3] = imagen4;
            imagesS[4] = imagen5;
            imagesS[5] = imagen6;
            imagesS[6] = imagen7;
            #endregion
            //Se define los arrays correspondientes
        }

        public int[,] getForma(int idn)
        {
            return formas[idn];
        }

        public void repintar(Ship ship, int s)
        {
            for ( int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    setLabel(i, j, "Repintar", ship, s);
                }
            }
        }

        public void GenerarCampo(int sizes, PictureBox panel = null, Label[,] ca = null)
        {
            for (int i = 0; i < campo.GetLength(0); i++)
            {
                for (int j = 0; j < campo.GetLength(1); j++)
                {
                    setLabel(i, j,  "Mar", null, sizes, ca);
                }
            }
        }

        public void setLabel(int x, int y, String status, Ship shp, int sL, Label[,] campoAC = null)
        { //Coloca los labels en el panel de juego
            if (campoAC != null)
            {
                campo = campoAC;
            }          
            switch (status)
            {
                case "Mar":
                    if(campoAC == null)
                    {
                        campo[x, y] = new Label();
                    }
                    Console.WriteLine(filePath);
                    break;

                case "Barco":
                    int[,] indice = { { x, y } };

                    for (int i = 0; i < shp.getFormaAct().GetLength(0); i++)
                    {
                            if (shp.getFormaAct()[i,0] == indice[0,0] && shp.getFormaAct()[i, 1] == indice[0,1])
                            {
                                campo[x, y].Image = (Image)imgMgnt.ResizeImage(shp.GetImage(), 50, 50);
                            }
                    }                   
                    break;

                case "Repintar":
                    int[,] ind = { { x, y } };
                    for (int i = 0; i < shp.getFormaAct().GetLength(0); i++)
                    {
                        if (shp.getFormaAct()[i, 0] == ind[0, 0] && shp.getFormaAct()[i, 1] == ind[0, 1])
                        {
                           campo[x, y].Image = null;
                        }
                    }
                    break;
                case "Fuego":
                    int[,] indiceFuego = { { x, y } };

                    for (int i = 0; i < shp.getFormaAct().GetLength(0); i++)
                    {
                        if (shp.getFormaAct()[i, 0] == indiceFuego[0, 0] && shp.getFormaAct()[i, 1] == indiceFuego[0, 1])
                        {
                            campo[x, y].Image = (Image)imgMgnt.ResizeImage(Image.FromFile(filePath + @"/Imagenes/fire.png"), 50, 50);
                        }
                    }
                    break;

            }
            campo[x, y].BackColor = Color.Transparent;
            cambiarTamLBL(x, y, sL);
        }

        public void cambiarTamLBL(int x, int y, int size, Label[,] c = null)//Modifica el tamaño de los labels
        {
            if (c!= null)
            {
                campo = c; 
            }
            if (campo[x, y].InvokeRequired)
            {
                campo[x, y].Invoke(new MethodInvoker(delegate
                {
                    campo[x, y].SetBounds(x * size, y * size, size, size);
                }));
            }
            else
            {
                campo[x, y].SetBounds(x * size, y * size, size, size);
            }
        }

        public Label[,] getCampo()
        {
            return campo;
        }

        public string[] getImages(int idx, int st)//Obtiene las imagenes de los arrays 
        {
            string[,] mx = imagesS[idx];
            string[] arr = new string[mx.GetLength(1)];
            for (int i = 0; i < mx.GetLength(1); i++)
            {
                arr[i] = mx[st,i];
            }
            return arr;
        }

        public int getBarcosTam()
        {
            return tam;
        }

        public void setBarco(Ship sh,int ja, int idx)
        {
            barcos[ja, idx] = sh;
        }
        public void setFire(Ship sh, int ja)
         { 
            
            bool cond = true;
            for (int i = 0; i < disparos[ja].GetLength(0); i++)
            {
                for (int j = 0; j < disparos[ja].GetLength(1); j++)
                {
                    if (disparos[ja][i,j] == null && cond)
                    {
                        disparos[ja][i, j] = sh;
                        cond = false;
                    }
                }
            }
        }
    }
}
