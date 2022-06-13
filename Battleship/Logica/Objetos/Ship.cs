using Battleship.Logica.Objetos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Logica
{

    internal class Ship : Board
    {
        private Image[] ShipImg;
        private string[] imgRL;
        private int[,] pos;
        private int[,] form;
        private int[,] formIni;
        public int size = -1;
        private int rotation = 0;
        private bool setd = false;
        public bool Setd
        {
            get { return setd; }
            set { setd = value; }
        }



        public Ship()
        {
        }

        public Ship(string[] imgRL, int[,] pos, int[,] frm)
        {
            ShipImg = new Image[imgRL.Length];
            for (int i = 0; i < imgRL.Length; i++)
            {
                string filePath = Environment.CurrentDirectory;
                string url = imgRL[i];
                this.ShipImg[i] = Image.FromFile(filePath + @"\Imagenes\" + url + ".png");
                
            }

            this.form = frm;
            this.formIni = frm;
        }

        public bool checkSet()
        {
            return setd;
        }

        public int[,] getFormaAct()
        {
            return form;
        }

        public void Mover(int x, int y)
        {
            for (int i = 0; i < (form.Length/2); i++)
            {
                form[i, 0] += x;
                form[i, 1] += y;
            }
        }

        public int getOri()
        {
            return rotation;
        }
        public void setOri(int o)
        {
            this.rotation = o;
        }

        public void rotate(int rot, int frm)
        {
            switch (rot)
            {
                case 0:
                    
                    form = formIni;
                    break;
                case 90:
                    rotate(0, 0);
                    if (frm == 2)
                    {
                        int value = form[0, 0];
                        form[0, 0] = form[0, 1];
                        form[0, 1] = value;
                    }
                    else if (frm == 5)
                    {
                        int[,] val = { { form[1,0], form[1,1] } };
                        form[1, 0] = form[2, 0];
                        form[1, 1] = form[2, 1];
                        form[2, 0] = form[4, 0];
                        form[2, 1] = form[4, 1];
                        form[4, 0] = form[3, 0];
                        form[4, 1] = form[3, 1];
                        form[3, 0] = val[0, 0];
                        form[3, 1] = val[0, 1];
                        form[0,0] = 2;
                        form[0, 1] = 3;
                        form[5, 0] = 1;
                        form[5, 1] = 0;
                    }
                    else
                    {
                        for (int i = 0; i < form.GetLength(0); i++)
                        {
                            int value1 = 2;
                            int value2 = form[i, 1];
                            form[i, 0] = value2;
                            form[i, 1] = value1;

                        }
                    }
                    break;
                case 180:
                    rotate(0 ,0);
                    if (frm == 2)
                    {
                        form[3, 0] = 0;
                        form[3, 1] = 1;
                    }
                    else
                    {

                        rotate(90, 0);
                        for (int i = 0; i < form.GetLength(0); i++)
                        {

                            int value1 = form[i, 0];
                            int value2 = form[i, 1];

                            form[i, 0] = value2;
                            form[i, 1] = value1;

                        }
                    }
                    break;
                case 270:
                    rotate(0, 0);
                    if (frm == 2)
                    {
                        form[4, 0] = 1;
                        form[4, 1] = 0;
                    }
                    else
                    {
                        for (int i = 0; i < form.GetLength(0); i++)
                        {
                            int value1 = form[i, 0];
                            int value2 = form[i, 1];

                            form[i, 0] = value2;
                            form[i, 1] = value1;

                        }
                    }
                    break;
            }
            
        }

        public Image GetImage()
        {

            if (size < ((form.Length/2)-1))
            {
                size++;
            } else if (size == ((form.Length / 2) - 1) && size != 0)
            {
                size = 0;
            }
            return ShipImg[size];
        }

        

    }
}
