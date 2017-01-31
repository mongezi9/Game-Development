/*
 Name & Surname: Emmanuel Mthimunye
 Date: 2013 Sept 5
 Implementing Artificial Intelligent level 1,2,3 and 4 in Game design
 * Manipulating picture interactive
 * 
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
    class MyButtonPics
    {
        Vector2 position;
        int image1;

        public bool mouseOver = false;
        public bool selected = false;
        int imaUsed;
        int action;
        MouseState pastMouse;
        public MyButtonPics(Vector2 position, int img1, int act)
        {
            
            this.position = position;
            image1 = img1;
            
            
            action = act;
            imaUsed = image1;
        }
        public void myDraw(SpriteBatch mySprite, Texture2D[] myTex, GraphicsDeviceManager graphics)
        {
           

            mySprite.Draw(myTex[imaUsed], position, Color.White);
            if (selected == true)
            {
                
                drawRectangle((int)position.X, (int)position.Y, myTex[imaUsed].Bounds.Width, myTex[imaUsed].Bounds.Height, graphics, mySprite);
            }
           
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


        public int input(Vector2 mouse, Texture2D[] images)
        {
            int ai = 0;
            if (mouse.X >= position.X && mouse.X <= position.X + images[imaUsed].Width
                && mouse.Y >= position.Y&& mouse.Y <= position.Y + images[imaUsed].Height)
            {
                if (Mouse.GetState().LeftButton == ButtonState.Pressed && pastMouse.LeftButton == ButtonState.Released)
                {
                    
                        ai = action;
                }
            }
            pastMouse = Mouse.GetState();
            return ai;
        }
 
    }
}
