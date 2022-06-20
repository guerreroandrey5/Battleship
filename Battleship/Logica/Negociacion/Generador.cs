using Battleship.Logica.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship.Logica.Negociacion
{
    internal class Generador//La clase Generador crea los objetos barco y los modifica
    {
        public Board generarJuego(PictureBox panel, int tam)//Funcion Genera la zona de juego
        {
            Board board = new Board(panel, tam);
            return board;
        }

        public Ship generarBarcos(PictureBox panel, int idx)//Funcion Genera los barcos
        {
            Board board = new Board();
            Ship ship = new Ship(board.getImages(idx, 0),board.getForma(idx), board.getForma(idx), 1, idx);            
            return ship;
        }

        public void setBarco(Ship ship, Label[,] campo, int size)//Funcion Genera la posicion de los barcos
        {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              
            for (int i = 0; i < ship.getFormaAct().GetLength(0); i++)
            {
                int x = ship.getFormaAct()[i,0];
                int y = ship.getFormaAct()[i, 1];
                ship.setLabel(x,y, "Barco", ship, size , campo );
            }
        }

        public void setFireLocation(Ship ship, Ship mira)
        {
            int[,] nw = new int[mira.getFormaAct().GetLength(0), mira.getFormaAct().GetLength(1)];
            Array.Copy(mira.getFormaAct(), nw, mira.getFormaAct().Length);
            ship.setFormaAct(nw);
        }
        public void setFire(Ship ship, Label[,] campo, int size, Ship mira, int jA)//Funcion Genera la posicion de los barcos
        {
            
            for (int i = 0; i < ship.getFormaAct().GetLength(0); i++)
            {
                int x = ship.getFormaAct()[i, 0];
                int y = ship.getFormaAct()[i, 1];
                ship.setLabel(x, y, "Fuego", ship, size, campo);
            }
           
        }

        public void changeTam(int size, Label[,] campo)//Funcion que aunmenta el tamano de la zona de juego
        {
            Board br = new Board();
            for (int i = 0; i < campo.GetLength(0); i++)
            {
                for (int j = 0; j < campo.GetLength(1); j++)
                {
                    br.cambiarTamLBL(i,j, size, campo);
                }
            }
        }

        public void getMovement(Ship ship, int x, int y)//Funcion que Genera el movimiento de los barcos
        {
            ship.repintar(ship, 50);            
            ship.Mover(x,y);
        }

        public void Rotate(Ship ship, int rot)//Funcion que Genera la rotacion de los barcos
        {           
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    ship.setLabel(i, j, "Repintar", ship, 50);
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
            setBarco(ship, null, 50);
        }

        public int getT()//Funcion que obtiene el tamano de la zona de juego
        {
            Board board = new Board();
            return board.getBarcosTam();
        }
    }
}
