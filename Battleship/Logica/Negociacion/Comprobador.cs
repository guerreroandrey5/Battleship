using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Logica.Negociacion
{
    internal class Comprobador
    {

        public bool getCondS(Ship ship)
        {
            return ship.Setd;
        }

        public void setCondS(Ship ship, int ja)
        {
            ship.Setd = true;

            ship.setBarco(ship, ja, ship.NBarco);
        }

        public bool comprobrarChoque(Ship sh1, Ship sh2)//Esta clase comprueba constantemente las posiciones de los barcos
        {
            int[,] coor1 = sh1.getFormaAct();
            int[,] coor2 = sh2.getFormaAct();

            

            for (int i = 0; i < coor1.GetLength(0); i++)
             {
                 for (int j = 0; j < coor2.GetLength(0); j++)
                 {
                     if (coor1[i,0] == coor2[j, 0] && coor1[i, 1] == coor2[j, 1])
                     {
                        return false;
                     }
                 }
             }

            return true;
        }

       

    }
}
