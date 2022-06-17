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
        private int[,] pos;
        private int NBarco;
        private bool move = true;
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

        public Ship(string[] imgRL, int[,] pos, int[,] frm, int numB)
        {
            this.NBarco = numB;
            setSIGs( imgRL );
            this.formIni = new int[frm.GetLength(0), frm.GetLength(1)];
            Array.Copy(frm, 0, formIni, 0, frm.Length);
            setFormaAct(frm.Clone() as int[,]);


        }

        public bool checkSet()
        {
            return setd;
        }

        private void setSIGs(string[] imgRL)
        {
            ShipImg = new Image[imgRL.Length];
            for (int i = 0; i < imgRL.Length; i++)
            {
                string filePath = Environment.CurrentDirectory;
                string url = imgRL[i];
                this.ShipImg[i] = Image.FromFile(filePath + @"\Imagenes\" + url + ".png");

            }
        }

        public int[,] getFormaAct()
        {
            return form;
        }
        public void setFormaAct(int[,] Fpos)
        {
            this.form = Fpos;
        }

        public void Mover(int x, int y)
        {
            int[] movimientos = new int[form.Length];
            for (int i = 0; i < (form.GetLength(0)); i++)
            {
                int tf = form[i, 0] + x;
                int td = form[i, 1] + y;
                movimientos[i] = tf;
                movimientos[i+1] = td;
                i++;
            }
            if(Array.Exists(movimientos, element => element < 0) || Array.Exists(movimientos, element => element > 8))
            {
                move = false;
            } else
            {
                move = true;
                moverBarco(x, y);
            }
        }

        private void moverBarco(int x, int y)
        {
            for (int i = 0; i < (form.GetLength(0)); i++)
            {
                form[i, 0] += x;
                form[i, 1] += y;
                formIni[i, 0] += x;
                formIni[i, 1] += y;
            }
        }

    
        public int[,] getPos()
        {
            return this.formIni;
        }

        public bool isMoving_(){
            return move;
        }

        public int getOri()
        {
            return rotation;
        }
        public void setOri(int o)
        {
            this.rotation = o;
        }
        public void setFOri()
        {
            Array.Copy(form, 0, formIni, 0, form.Length);
        }

        public void rotate(int rot, int frm)
        {
            int value1 = 0;
            int value2 = 0;
            if (NBarco == 2)
            {
                value1 = form[2, 0];
                value2 = form[2, 1];
            }
            int contador = 1;
            int[,] CADFRM = form;
            switch (rot)
            {
                case 0:

                    Array.Copy(formIni, 0, form, 0, formIni.Length);
                    setSIGs(getImages(this.NBarco, 0));
                    break;
                case 90:
                    //rotate(0, frm);
                     if (frm == 5)
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
                        int[,] val2 = { { form[0, 0], form[0, 1] } };
                        form[0,0] = form[5, 0] -  1;
                        form[0, 1] = form[5, 1] + 2;
                        form[5, 0] = val2[0, 0] + 1;
                        form[5, 1] = val2[0, 1] -2;
                    } else 
                    {
                        contador = 1;
                        
                        for (int i = 0; i < form.GetLength(0); i++)
                        {
                           /* for (int j = 1; j < form.GetLength(1); j++)
                            {*/
                        if(i!=1)
                            {
                                
                                if (form[1, 0] > form[i, 0])
                                {
                                    form[i, 0] = form[i, 0] + contador;
                                    form[i, 1] = form[i, 1] - contador;
                                } else if (form[1, 0] < form[i, 0])
                                {
                                    form[i, 0] = form[i, 0] - contador;
                                    form[i, 1] = form[i, 1] + contador;
                                }
                                while (form[i, 0] < 0)
                                {
                                    moverBarco(1, 0);
                                }
                                while (form[i, 0] > 9)
                                {
                                    moverBarco(-1, 0);
                                }
                                while (form[i, 1] < 0)
                                {
                                    moverBarco(0, 1);
                                }
                                while (form[i, 1] > 9)
                                {
                                    moverBarco(0, -1);
                                }
                                if (i >= 2)
                                {
                                    contador++;
                                }
                                /*if (form[1, 0] == -1 || form[i, 0] == -1 || form[1, 0] == 10 || form[i, 0] == 10)
                                {
                                    form = CADFRM;
                                    break;
                                }*/

                            }
                            //}
                        }
                        

                    }
                        setSIGs(getImages(this.NBarco, 1));
                    break;
                case 180:
                    contador = 1;
                    for (int i = 0; i < form.GetLength(0); i++)
                    {
                        /* for (int j = 1; j < form.GetLength(1); j++)
                         {*/
                        if (i != 1)
                        {

                            if ( form[i, 0] < form[1, 0]  )
                            {
                                form[i, 0] = form[i, 0] + contador;
                                form[i, 1] = form[i, 1] + contador;
                            }
                            else if ( form[i, 0] > form[1, 0])
                            {
                                form[i, 0] = form[i, 0] - contador;
                                form[i, 1] = form[i, 1] - contador;
                            } else if (form[i, 0] == form[1, 0])
                            {
                                if (form[i, 1] < form[1, 1])
                                {
                                    form[i, 0] = form[i, 0] + contador;
                                    form[i, 1] = form[i, 1] + contador;
                                }
                                else if (form[i, 1] > form[1, 1])
                                {
                                    form[i, 0] = form[i, 0] - contador;
                                    form[i, 1] = form[i, 1] - contador;
                                }
                            }

                            while (form[i, 0] < 0)
                            {
                                moverBarco(1, 0);
                            }
                            while (form[i, 0] > 9)
                            {
                                moverBarco(-1, 0);
                            }
                            while (form[i, 0] < 0)
                            {
                                moverBarco(1, 0);
                            }
                            while (form[i, 1] < 0)
                            {
                                moverBarco(0, 1);
                            }
                            while (form[i, 1] > 9)
                            {
                                moverBarco(0, 1);
                            }
                            if (i >= 2)
                            {
                                contador++;
                            }
                            if (form[1, 0] == -1 || form[i, 0] == -1 || form[1, 0] == 10 || form[i, 0] == 10)
                            {
                                form = CADFRM;
                                break;
                            }
                        }
                        //}
                    }
                    setSIGs(getImages(this.NBarco, 2));
                    break;
                case 270:
                    contador = 1;

                    for (int i = 0; i < form.GetLength(0); i++)
                    {
                        /* for (int j = 1; j < form.GetLength(1); j++)
                         {*/
                        if (i != 1)
                        {

                            if (form[1, 0] > form[i, 0])
                            {
                                form[i, 0] = form[i, 0] + contador;
                                form[i, 1] = form[i, 1] - contador ;
                            }
                            else if (form[1, 0] < form[i, 0])
                            {
                                form[i, 0] = form[i, 0] - contador;
                                form[i, 1] = form[i, 1] + contador;
                            }
                            while (form[i, 0] < 0)
                            {
                                moverBarco(1, 0);
                            }
                            while (form[i, 0] > 9)
                            {
                                moverBarco(-1, 0);
                            }
                            while (form[i, 0] < 0)
                            {
                                moverBarco(1, 0);
                            }
                            while (form[i, 1] < 0)
                            {
                                moverBarco(0, 1);
                            }
                            while (form[i, 1] > 9)
                            {
                                moverBarco(0, 1);
                            }

                            if (i >= 2)
                            {
                                contador++;
                            }
                            if (form[1, 0] == -1 || form[i, 0] == -1 || form[1, 0] == 10 || form[i, 0] == 10)
                            {
                                form = CADFRM;
                                break;
                            }
                        }
                        //}
                    }
                    setSIGs(getImages(this.NBarco, 3));
                    break;
            }
            if (NBarco == 2)
            {
                form[3, 0] = value1;
                form[3, 1] = value2;
            }
            //this.formIni = CADFRM;

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
