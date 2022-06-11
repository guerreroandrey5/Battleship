using Battleship.Logica.Negociacion;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship.Logica.Objetos
{
    internal class Board
    {
        protected static Label[,] campo = new Label[10, 10];
        private static int tam = 6;
        protected static Ship[,] barcos = new Ship[1, tam];
        protected static string[][] imagesS = new string[6][];
        private ImagenManagment imgMgnt = new ImagenManagment();
        private int[][,] formas = new int[6][,];
        public Board()
        {
            setformas();
        }

        private void  setformas()
        {
            int[,] array1 = { { 0,0 }, { 1,0 } };
            int[,] array2 = { { 0,1},{ 1,1 },{ 2,1 } };
            int[,] array3 = { { 0, 1 }, { 1, 1 },{1,2 }, { 2, 1 } };
            int[,] array4 = { { 0, 1 }, { 1, 1 }, { 2, 1 }, {3,1 } };
            int[,] array5 = { { 0, 1 }, { 1, 1 }, { 2, 1 }, { 3, 1 }, {4,1 } };
            int[,] array6 = { { 0, 2 }, { 1, 2 }, { 2, 2 }, { 1, 1 }, { 2, 1 } , { 3, 1 } };
            //string[] imagen1 = { 'C:\Users\Cris\Downloads\mar.png' };
            //string[,] imagen2 = { { 0, 1 }, { 1, 1 }, { 2, 1 } };
            string[] imagen6 = { "PA1", "PA4", "PA2", "PA5", "PA3", "PA6" };
            //string[,] imagen4 = { { 0, 1 }, { 1, 1 }, { 2, 1 }, { 3, 1 } };
            //string[,] imagen5 = { { 0, 1 }, { 1, 1 }, { 2, 1 }, { 3, 1 }, { 4, 1 } };
            //string[,] imagen6 = { { 1, 1 }, { 1, 2 }, { 1, 3 }, { 2, 0 }, { 2, 1 }, { 2, 2 } };
            formas[0] = array1;
            formas[1] = array2;
            formas[2] = array3;
            formas[3] = array4;
            formas[4] = array5;
            formas[5] = array6;
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

        public Panel setLabel(int x, int y, Panel panel, String status, Ship shp)
        { //Coloca los label eb el panel de juego
            
            switch (status)
            {
                case "Mar":
                    if (panel != null)
                    {
                        campo[x, y] = new Label();
                    }
                    campo[x, y].Image = (Image)imgMgnt.ResizeImage(Image.FromFile(@"C:\Users\Cris\Downloads\mar.png"), 50, 50);

                    break;

                case "Barco":
                    int[,] indice = { { x, y } };
                    //campo[x][y].setIcon(controlIMG.getScaledImage(new ImageIcon("E:/Codigo U/Programacion 2/LP2.1-Robot/dust.png"), 50, 50));

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
                    //campo[x][y].setIcon(controlIMG.getScaledImage(new ImageIcon("E:/Codigo U/Programacion 2/LP2.1-Robot/dust.png"), 50, 50));

                    for (int i = 0; i < shp.getFormaAct().GetLength(0); i++)
                    {
                        if (shp.getFormaAct()[i, 0] == ind[0, 0] && shp.getFormaAct()[i, 1] == ind[0, 1])
                        {
                            campo[x, y].Image = (Image)imgMgnt.ResizeImage(Image.FromFile(@"C:\Users\Cris\Downloads\mar.png"), 50, 50);

                        }
                    }

                    break;
            }
            if(panel != null)
            {
                campo[x, y].SetBounds(x * 50, y * 50, 50, 50);
                panel.Controls.Add(campo[x, y]);
            }
            

            return panel;
        }

        public Label[,] getCampo()
        {
            return campo;
        }

        public string[] getImages(int idx)
        {
            return imagesS[idx];
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
