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
            Ship ship = new Ship(board.getImages(idx),board.getForma(idx), board.getForma(idx));
            board.setBarco(ship);
            return ship;
        }

        public void setBarco(Ship ship, Panel panel)
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          {
            for (int i = 0; i <= ship.getFormaAct().GetLength(0); i++)
            {
                for (int j = 0; j <= ship.getFormaAct().GetLength(1); j++)
                {
                    
                    board.setLabel(i,j, null, "Barco", ship );
                }
            }
            }

        public void getMovement(Ship ship, int x, int y)
        {
            for (int i = 0; i < ship.getFormaAct().GetLength(0); i++)
            {
                for (int j = 0; j < ship.getFormaAct().GetLength(1); j++)
                {
                    board.setLabel(i, j, null,  "Repintar", ship);
                }
            }
            
            ship.Mover(x,y);
            setBarco(ship,null);
        }

        public void Rotate(Ship ship, int rot)
        {
            for (int i = 0; i < ship.getFormaAct().GetLength(0); i++)
            {
                for (int j = 0; j < ship.getFormaAct().GetLength(1); j++)
                {
                    board.setLabel(i, j, null, "Repintar", ship);
                }
            }
            ship.setOri(rot);
            int Sbarco = ((ship.getFormaAct().Length / 2) - 1);
            if (Sbarco == 5)
            {
                if (ship.getOri() == 90)
                {
                    rot = 0;
                } 
            }
            ship.rotate(rot, Sbarco);
            setBarco(ship, null);
        }

        public int getT()
        {
            return board.getBarcosTam();
        }
    }
}
