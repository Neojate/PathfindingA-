using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathFinding
{
    class Program
    {
        #region ATRIBUTOS
        private Tile[,] map;

        private int sizeX, sizeY;
        #endregion

        static void Main(string[] args)
        {
            Program program = new Program();

            program.createMap();
            program.findPath();
            program.drawMap();
        }

        #region MÉTODOS PRIVADOS
        //método que crea el mapa
        private void createMap()
        {
            sizeX = 20;
            sizeY = 20;

            map = new Tile[sizeX, sizeY];

            //relleno general
            for (int y = 0; y < sizeY; y++)
            {
                for (int x = 0; x < sizeX; x++) map[x, y] = new Tile(" ", false);
            }

            //bordes
            for (int y = 0; y < sizeY; y++)
            {
                map[0, y] = new Tile("1", true);
                map[sizeY - 1, y] = new Tile("1", true);
                map[y, 0] = new Tile("1", true);
                map[y, sizeY - 1] = new Tile("1", true);
            }

            //muros
            for (int y = 0; y < sizeY; y++)
            {
                map[12, y] = new Tile("1", true);
                map[16, y] = new Tile("1", true);
            }
            map[12, 12] = new Tile(" ", false);
            map[16, 18] = new Tile(" ", false);

            for (int x = 0; x < 12; x++) map[x, 10] = new Tile("1", true);
            map[4, 10] = new Tile(" ", false);
        }

        //método que arranca el algoritmo de pathfinding y establece los nodos inicial y final
        private void findPath()
        {
            Node start = null;
            Node end = null;

            PathFinding path = new PathFinding(map);

            start = createNode();
            end = createNode();

            path.init(start.X, start.Y, end.X, end.Y);
        }

        //método que dibuja el mapa
        private void drawMap()
        {
            for (int y = 0; y < sizeY; y++)
            {
                for (int x = 0; x < sizeX; x++) Console.Write(map[x, y].Texture + " ");
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        //método que crea nodos a través de datos insertados por consola
        private Node createNode()
        {
            Node n = new Node();
            Console.WriteLine("Escribe el nodo: ");
            Console.WriteLine("X: ");
            n.X = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Y: ");
            n.Y = Int32.Parse(Console.ReadLine());
            return n;
        }
        #endregion
    }
}
