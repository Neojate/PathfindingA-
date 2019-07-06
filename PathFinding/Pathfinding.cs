using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathFinding
{
    public class PathFinding
    {
        #region CONSTANTES
        private const int AXIS_VALUE = 10;
        private const int DIAGONAL_VALUE = 14;
        #endregion

        #region ATRIBUTOS
        private Tile[,] map;

        private List<Node> openList;
        private List<Node> closedList;

        private Node start;
        private Node end;
        private Node current;

        private int g;
        #endregion

        #region CONSTRUCTORES
        public PathFinding(Tile[,] map)
        {
            this.map = map;
        }
        #endregion

        #region MÉTODOS PÚBLICOS
        //Método que arranca el algoritmo de pathfinding
        public void init(int x1, int y1, int x2, int y2)
        {
            loadInitialValues(x1, y1, x2, y2);

            //mientras la lista abierta contenga algún nodo...
            while (openList.Count > 0)
            {
                //el nodo actual será aquel con valor F más bajo
                int lowerFValue = openList.Min(node => node.F);
                current = openList.First(lower => lower.F == lowerFValue);

                //actualizamos las listas
                closedList.Add(current);
                openList.Remove(current);

                //comprueba si el nodo actual es el destino
                if (closedList.FirstOrDefault(node => node.IsSameNode(end)) != null) break;

                //buscamos los nodos adyacentes al nodo actual y aumentamos la g
                List<Node> adjacentNodes = current.CalculateAdjacentNodes(map);
                g += AXIS_VALUE;

                //para cada nodo adyacente...
                foreach (Node n in adjacentNodes)
                {
                    //si el nodo no se encuentra en la lista cerrada
                    if (openList.FirstOrDefault(node => node.IsSameNode(n)) == null)
                    {
                        //recalculamos su F
                        n.CalctulateF(end, g);

                        //establecemos el nodo actual como su parent
                        n.Parent = current;

                        //añadimos el nodo adyacente a la lista de abiertos
                        openList.Insert(0, n);

                    }
                    else
                    {
                        //si ya se encuentra en la lista pero el camino resulta más optimo
                        if (g + n.H < n.F)
                        {
                            //recalculamos su F
                            n.CalctulateF(end, g);

                            //establecemos el nodo actual como su parent
                            n.Parent = current;
                        }
                    }
                }

            }

            //dibujamos el trayecto de los parents
            while (current != null)
            {
                map[current.X, current.Y].Texture = "·";
                current = current.Parent;
            }
            map[start.X, start.Y].Texture = "S";
            map[end.X, end.Y].Texture = "F";

        }
        #endregion

        #region MÉTODOS PRIVADOS
        //Método que inicializa todos los valores para el Pathfinding y establece el nodo inicial y final
        private void loadInitialValues(int x1, int y1, int x2, int y2)
        {
            start = new Node(x1, y1);
            map[x1, y1].Type = TileType.START;

            end = new Node(x2, y2);
            map[x2, y2].Type = TileType.END;

            openList = new List<Node>();
            closedList = new List<Node>();

            openList.Add(start);

            g = 0;
        }
        #endregion

    }
}
