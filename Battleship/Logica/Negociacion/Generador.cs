using Battleship.Logica.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship.Logica.Negociacion
{
    internal class Generador
    {
       
        

        public Board generarJuego(Panel panel)
        {
            Board board = new Board(panel);
            return board;
        }

        public Ship generarBarcos(Panel panel, int idx)
        {
            Board board = new Board();
            Ship ship = new Ship(board.getImages(idx, 0),board.getForma(idx), board.getForma(idx), idx);
            board.setBarco(ship);
            return ship;
        }

        public void setBarco(Ship ship, Panel panel)
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          {
            for (int i = 0; i < ship.getFormaAct().GetLength(0); i++)
            {
                int x = ship.getFormaAct()[i,0];
                int y = ship.getFormaAct()[i, 1];
                ship.setLabel(x,y, panel, "Barco", ship );
            }
            }

        public void getMovement(Ship ship, int x, int y)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    ship.setLabel(i, j, null,  "Repintar", ship);
                }
            }
            
            ship.Mover(x,y);

            setBarco(ship, null);
        }

        public void Rotate(Ship ship, int rot)
        {
            
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    ship.setLabel(i, j, null, "Repintar", ship);
                }
            }
            int Sbarco = ((ship.getFormaAct().Length / 2) - 1);
            if (Sbarco == 5)
            {
                if (ship.getOri() == 90)
                {
                    rot = 0;
                } 
            }

            ship.setOri(rot);
            ship.rotate(rot, Sbarco);
            setBarco(ship, null);
        }

        public int getT()
        {
            Board board = new Board();
            return board.getBarcosTam();
        }
    }
}
