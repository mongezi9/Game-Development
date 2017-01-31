/*
 Name & Surname: Emmanuel Mthimunye
 Date: 2013 Sept 5
 Implementing Artificial Intelligent level 1,2,3 and 4 in Game design
 * Tiles for creating maps
 */


using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GPM20BT_Practical1
{
    class MapTiles
    {
        public int type;
        
        public Vector2 position;
        public bool mouse_over = false;
        public Rectangle Position;
        public bool Blocked;
        public int Cost;
        public bool thereIsUnit;
       
        public MapTiles(int type,Vector2 position)
        {
            this.position = position;
            this.type = type;           
            Blocked = false;
            Cost = 0;
            
        }
        
        public bool IsBlocked()
        {
            return Blocked;
        }
       
        public void drawRectangle(int x1, int y1, int width, int height, GraphicsDeviceManager graphics, SpriteBatch batch)
        {
            Rectangle spriteTextnew;
            spriteTextnew = new Rectangle(x1, y1, width, height);
            int bw = 2;
            Texture2D t;
            t = new Texture2D(graphics.GraphicsDevice, 1, 1);

            t.SetData(new[] { Color.White });

            batch.Draw(t, new Rectangle(spriteTextnew.Left, spriteTextnew.Top, bw, spriteTextnew.Height), Color.Red); // Left
            batch.Draw(t, new Rectangle(spriteTextnew.Right, spriteTextnew.Top, bw, spriteTextnew.Height), Color.Red); // Right
            batch.Draw(t, new Rectangle(spriteTextnew.Left, spriteTextnew.Top, spriteTextnew.Width, bw), Color.Red); // Top
            batch.Draw(t, new Rectangle(spriteTextnew.Left, spriteTextnew.Bottom, spriteTextnew.Width + 2, bw), Color.Red);//bottom

        }
        public void drawTile(GraphicsDeviceManager graphics, SpriteBatch batch, Texture2D[] images,int camX,int camY)
        {
            Position = new Rectangle((int)(position.X - camX + graphics.PreferredBackBufferWidth / 2 - images[type].Width / 2 + 20), 
                (int)(position.Y - camY + graphics.PreferredBackBufferHeight / 2 - images[type].Height / 2 + 20), images[type].Width,images[type].Height);
            batch.Draw(images[type], new Vector2(position.X - camX + graphics.PreferredBackBufferWidth / 2 - images[type].Width / 2,
                position.Y - camY + graphics.PreferredBackBufferHeight / 2 - images[type].Height / 2), Color.White);
            
          
        }
    }
}
