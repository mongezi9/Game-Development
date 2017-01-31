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
    class Button
    {
        Vector2 position;
        int image1;
        int image2;
        int view;
        int imaUsed;
        int action;
        int counter = 0;
        int soundView;
        SoundEffect[] click;
        MouseState pastMouse;

        public Button(Vector2 position, int img1, int img2, int act, int vie, SoundEffect[] click)
        {
            this.position = position;
            image1 = img1;
            image2 = img2;
            view = vie;
            action = act;
            imaUsed = image1;
            this.click = click;


        }
        public void setPosition(Vector2 p)
        {
            position = p;
        }
        public Vector2 getPosition()
        {
            return position;
        }
        public void myDraw(SpriteBatch mySprite, Texture2D[] myTex, int currentView)
        {
            soundView = currentView;
            if (view == currentView)
            {
                mySprite.Draw(myTex[imaUsed], position, Color.White);

            }


        }
        public void soundPlay(int num)
        {
            if (num == 3)
            {
                click[1].Play();
            }

        }
        public int inputButton(Vector2 mouse, Texture2D[] myText, SoundEffect[] click)
        {

            
            
            int ai = 0;
            if (mouse.X >= position.X  && mouse.X <= position.X + myText[imaUsed].Width
                && mouse.Y >= position.Y  && mouse.Y <= position.Y + myText[imaUsed].Height )
            {

                imaUsed = image2;
                counter++;
                if (soundView == view)
                    soundPlay(counter);
                if (mouse.X >= position.X && mouse.X <= position.X + myText[imaUsed].Width
                && mouse.Y >= position.Y && mouse.Y <= position.Y + myText[imaUsed].Height )
                {
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed && pastMouse.LeftButton == ButtonState.Released )
                    {
                        if (soundView == view)
                            ai = action;
                    }

                }
            }
            else
            {
                imaUsed = image1;
                counter = 0;
            }
            pastMouse = Mouse.GetState();
            return ai;
        }
    }
}
