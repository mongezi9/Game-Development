/*
 Name & Surname: Emmanuel Mthimunye
 Date: 2013 Sept 5
 Implementing Artificial Intelligent level 1,2,3 and 4 in Game design

 * Populating Tiles
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
namespace GPM20BT_Practical1
{
    public class Tile : MapNode
    {
        public Rectangle Position;
        public Color Color;
        public int type;
        public bool Blocked;
        public int Cost;
        public Point theTilePos;
        public Tile()
        {
            Position = new Rectangle(0, 0, 16, 16);
            Color = Color.White;
            Blocked = false;
            Cost = 0;

        }
        public void setTilePos(Point pos)
        {
            theTilePos = pos; 
        }

        public bool IsBlocked() 
        {
            return Blocked; 
        }

        public void SetColor(Color c) 
        { 
            Color = c; 
        }
    }
}
