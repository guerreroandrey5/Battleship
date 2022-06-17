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
        private static Label[,] campo = new Label[10, 10];
        private static int tam = 6;
        protected static Ship[,] barcos = new Ship[1, tam];
        protected static string[][,] imagesS = new string[6][,];
        private ImagenManagment imgMgnt = new ImagenManagment();
        private int[][,] formas = new int[6][,];
        string filePath =  Directory.GetCurrentDirectory();
        
        public Board()
        {
            setformas();
        }

        public Board(Panel panel)
        {
            setformas();
            GenerarCampo(panel);
        }

        private void setformas()
        {
            int[,] array1 = { { 0, 0 }, { 1, 0 } };
            int[,] array2 = { { 0, 1 }, { 1, 1 }, { 2, 1 } };
            int[,] array3 = { { 0, 1 }, { 1, 1 }, { 2, 1 },{ 1, 0 } };
            int[,] array4 = { { 0, 1 }, { 1, 1 }, { 2, 1 }, { 3, 1 } };
            int[,] array5 = { { 0, 1 }, { 1, 1 }, { 2, 1 }, { 3, 1 }, { 4, 1 } };
            int[,] array6 = { { 0, 2 }, { 1, 2 }, { 2, 2 }, { 1, 1 }, { 2, 1 }, { 3, 1 } };
            //string[] imagen1 = { 'C:\Users\Cris\Downloads\mar.png' };
            //string[,] imagen2 = { { 0, 1 }, { 1, 1 }, { 2, 1 } };
            string[,] imagen1 = { { "L1", "L2" },
                                { "90_L1", "90_L2" },
                                { "180_L2", "180_L1" },
                                { "270_L2", "270_L1" }};
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
            string[,] imagen5 = { { "PA1", "PA2", "PA3", "PA4", "PA5" },
                                  { "R_PA1", "R_PA2", "R_PA3", "R_PA4", "R_PA5" } };
            string[,] imagen6 = { { "PA1", "PA2", "PA3", "PA4", "PA5", "PA6" },
                                  { "R_PA1", "R_PA2", "R_PA3", "R_PA4", "R_PA5", "R_PA6" } };
            formas[0] = array1;
            formas[1] = array2;
            formas[2] = array3;
            formas[3] = array4;
            formas[4] = array5;
            formas[5] = array6;
            
            imagesS[0] = imagen1;
            imagesS[1] = imagen2;
            imagesS[2] = imagen3;
            imagesS[3] = imagen4;
            imagesS[4] = imagen5;
            imagesS[5] = imagen6;
        }

        public int[,] getForma(int idn)
        {
            return formas[idn];
        }

        public Panel GenerarCampo(Panel panel = null)
        {
            for (int i = 0; i < campo.GetLength(0); i++)
            {
                for (int j = 0; j < campo.GetLength(1); j++)
                {
                    panel = setLabel(j, i, panel, "Mar", null);
                }
            }

            return panel;
        }

        public Panel setLabel(int x, int y, Panel panel, String status, Ship shp, Label[,] campoAc = null)
        { //Coloca los labels en el panel de juego
            if (campoAc == null)
            {
                campoAc = campo;
            }
            switch (status)
            {
                case "Mar":
                    if (panel != null)
                    {
                        campo[x, y] = new Label();
                    }                   
                    Console.WriteLine(filePath);
                    campoAc[x, y].Image = (Image)imgMgnt.ResizeImage(Image.FromFile(filePath + @"\Imagenes\mar.png"), 50, 50);
                    //campo[x, y].Image = (Image)imgMgnt.ResizeImage(Image.FromFile(@"C:\Users\Cris\Downloads\mar.png"), 50, 50);              
                    break;

                case "Barco":
                    int[,] indice = { { x, y } };
                    //campo[x][y].setIcon(controlIMG.getScaledImage(new ImageIcon("E:/Codigo U/Programacion 2/LP2.1-Robot/dust.png"), 50, 50));

                    for (int i = 0; i < shp.getFormaAct().GetLength(0); i++)
                    {
                            if (shp.getFormaAct()[i,0] == indice[0,0] && shp.getFormaAct()[i, 1] == indice[0,1])
                            {
                                campoAc[x, y].Image = (Image)imgMgnt.ResizeImage(shp.GetImage(), 50, 50);
                            }
                    }
                    
                    break;
                case "Repintar":
                    int[,] ind = { { x, y } };
                    //campo[x][y].setIcon(controlIMG.getScaledImage(new ImageIcon("E:/Codigo U/Programacion 2/LP2.1-Robot/dust.png"), 50, 50));

                    for (int i = 0; i < shp.getFormaAct().GetLength(0); i++)
                    {
                        if (shp.getFormaAct()[i, 0] == ind[0, 0] && shp.getFormaAct()[i, 1] == ind[0, 1])
                        {
                            //campo[x, y].Image = (Image)imgMgnt.ResizeImage(Image.FromFile(@"C:\Users\Cris\Downloads\mar.png"), 50, 50);
                            campoAc[x, y].Image = (Image)imgMgnt.ResizeImage(Image.FromFile(filePath + @"\Imagenes\mar.png"), 50, 50);
                        }
                    }

                    break;
            }
            if(panel != null)
            {
                campoAc[x, y].SetBounds(x * 50, y * 50, 50, 50);
                try
                {
                    panel.Controls.Add(campoAc[x, y]);
                }
                catch (Exception)
                {
                    Thread form = new Thread(() =>
                    {
                        panel.Invoke((MethodInvoker)delegate { panel.Controls.Add(campoAc[x, y]); });

                    });
                    throw;
                }
                
            }
            

            return panel;
        }

        public Label[,] getCampo()
        {
            return campo;
        }

        public string[] getImages(int idx, int st)
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

        public void setBarco(Ship sh)
        {

        }

    }
}
