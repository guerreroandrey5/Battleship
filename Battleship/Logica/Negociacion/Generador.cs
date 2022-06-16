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
        private Board board  = new Board();
        

        public Label[,] generarJuego(Panel panel, int cond)
        {
            panel = board.GenerarCampo(panel);
            Label[,] campo = board.getCampo();
            return campo;
        }

        public Ship generarBarcos(Panel panel, int idx)
        {
            
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
                board.setLabel(x,y, null, "Barco", ship );
            }
            }

        public void getMovement(Ship ship, int x, int y)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    board.setLabel(i, j, null,  "Repintar", ship);
                }
            }
            
            ship.Mover(x,y);
            if (ship.isMoving_())
            {
                ship.setPos(ship.getFormaAct());
            } else
            {
                ship.setFormaAct(ship.getPos());
            }

            setBarco(ship, null);
        }

        public void Rotate(Ship ship, int rot)
        {
            
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    board.setLabel(i, j, null, "Repintar", ship);
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
            return board.getBarcosTam();
        }
    }
}
