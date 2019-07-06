using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathFinding
{
    public enum TileType
    {
        NONE, START, END
    }

    public class Tile
    {
        #region ATRIBUTOS
        private string texture;
        private bool block;
        private TileType type;
        #endregion

        #region CONSTRUCTORES
        public Tile(string texture)
        {
            this.texture = texture;
            type = TileType.NONE;
        }

        public Tile(string texture, bool block)
        {
            this.texture = texture;
            this.block = block;
        }

        public Tile(string texture, bool block, TileType type)
        {
            this.texture = texture;
            this.block = block;
            this.type = type;
        }
        #endregion

        #region GETTERS Y SETTERS
        public string Texture
        {
            get { return texture; }
            set { texture = value; }
        }
    
        public bool Block
        {
            get { return block; }
            set { block = value; }
        }

        public TileType Type
        {
            get { return type; }
            set { type = value; }
        }
        #endregion

    }

}
