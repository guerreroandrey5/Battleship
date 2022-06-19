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
    }
}
