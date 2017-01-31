/*
 Name & Surname: Emmanuel Mthimunye
 Date: 2013 Sept 5
 Implementing Artificial Intelligent level 1,2,3 and 4 in Game design
 * Button Class
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GPM20BT_Practical1
{
    class Bullets
    {
        public int speed;
        public Vector2 position;
        public float angle;
        public int side;
        public int img;
        public int status;
        public Texture2D bullet;
        public int parent;
        public Rectangle bulletRect;
        public float bullDistaceFrom;

        public Bullets(int s, Vector2 p, float a, int sd, int i, Texture2D bull, int pr)
        {
            speed = s;
            position = p;
            angle = a;
            side = sd;
            img = i;
            status = 1;
            bullet = bull;
            parent = pr;

        }
        //public Rectangle bulletRect(Texture2D[] images, GraphicsDeviceManager graphics, int cmX, int cmY)
        //{

        //    return new Rectangle(
        //    (int)(position.X - cmX + graphics.PreferredBackBufferWidth / 2 + images[img].Width / 2),
        //    (int)(position.Y - cmY + graphics.PreferredBackBufferHeight / 2 + images[img].Height / 2),
        //    bullet.Width, bullet.Height);

        //}
        public void drawBullet(GraphicsDeviceManager graphics, SpriteBatch batch, Texture2D[] ships, int cX, int cY)
        {
            if (status == 1)
            {

                batch.Draw(bullet, new Vector2(position.X - cX + graphics.PreferredBackBufferWidth / 2 + ships[img].Width / 2 - 20,
                    position.Y - cY + graphics.PreferredBackBufferHeight / 2 + ships[img].Height / 2 - 20),
                    null, Color.White, (MathHelper.Pi / 180) * angle,
                    new Vector2((float)bullet.Width / 2, (float)bullet.Height / 2),
                    1.0f, SpriteEffects.None, 0f);
            }
            else
            {
 
            }


            position.X += (float)(speed * Math.Cos((angle - 90) * (MathHelper.Pi / 180)));
            position.Y += (float)(speed * Math.Sin((angle - 90) * (MathHelper.Pi / 180)));
            if ((position.X - cX + graphics.PreferredBackBufferWidth / 2) > 0 &&
                (position.X - cX + graphics.PreferredBackBufferWidth / 2)
                < graphics.PreferredBackBufferWidth
                && (position.Y - cY + graphics.PreferredBackBufferHeight / 2) > 0 &&
                (position.Y - cY + graphics.PreferredBackBufferHeight / 2)
                < graphics.PreferredBackBufferHeight)
            {

            }
            else
            {
                status = 0;
            }
            bulletRect =  new Rectangle(
           (int)(position.X - cX + graphics.PreferredBackBufferWidth / 2 + ships[img].Width / 2),
           (int)(position.Y - cY + graphics.PreferredBackBufferHeight / 2 + ships[img].Height / 2),
            bullet.Width, bullet.Height);
        }
    }
}
