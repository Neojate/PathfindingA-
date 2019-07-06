using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathFinding
{
    public class Node
    {
        #region ATRIBUTOS
        private int x, y;

        private int f, g, h;

        private Node parent;
        #endregion

        #region CONSTRUCTORES
        public Node()
        {

        }

        public Node(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        #endregion

        #region MÉTODOS PÚBLICOS
        //método que crea los nodos adjacentes del nodo siempre que no sean paredes
        public List<Node> CalculateAdjacentNodes(Tile[,] map)
        {
            List<Node> adjacentNodes = new List<Node>()
            {
                new Node(x, y - 1),
                new Node(x, y + 1),
                new Node(x - 1, y),
                new Node(x + 1, y)
            };
            return adjacentNodes.Where(node => !map[node.X, node.Y].Block).ToList();
        }

        //método que comprueba si dos nodos son iguales
        public bool IsSameNode(Node node)
        {
            return x == node.X && y == node.Y;
        }

        //método que actualiza el valor f del nodo
        public void CalctulateF(Node end, int g)
        {
            this.g = g;
            f = CalculateH(end) + g;
        }
        #endregion

        #region MÉTODOS PRIVADOS
        //método que calcula el valor de h en función del destino
        private int CalculateH(Node end)
        {
            h = Math.Abs(x - end.X) + Math.Abs(y - end.Y);
            return h;
        }
        #endregion

        #region GETTERS Y SETTERS
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public int F
        {
            get { return f; }
            set { f = value; }
        }

        public int G
        {
            get { return g; }
            set { g = value; }
        }

        public int H
        {
            get { return h; }
            set { h = value; }
        }

        public Node Parent
        {
            get { return parent; }
            set { parent = value; }
        }
        #endregion
    }
}
