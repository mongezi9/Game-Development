/*
 Name & Surname: Emmanuel Mthimunye
 Date: 2013 Sept 5
 Implementing Artificial Intelligent level 1,2,3 and 4 in Game design
 
 * Class for creating/modifying objects
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
    class Units
    {
        public Vector2 position;
        public Point Position;
        public Point Destination;
        public int side;
        public int status;
        public int life;
        public int imageUsed;
        public MapTiles[,] map;
        public double angle;
        public bool selected;
        public int mouse_over;
        public int type;
        public Rectangle unitRect;
        public bool pathFound = true;
        public Vector2 destination;
        public double newAngle;
        public Point parentTile;
        public int typeOfUnit;
        public bool attack = false;
        public bool findpath = false;
        public bool wander;
        public bool patrol;
        public bool alive;


        public List<Point> path = new List<Point>();

        public Units(Vector2 position, Point Position, int side, int status, int life, int img, MapTiles[,] map, int type, int typeOfUnit)
        {
            // position = pos;
            this.side = side;
            this.status = status;
            this.life = life;
            this.map = map;
            imageUsed = img;
            destination = position;
            selected = false;
            this.typeOfUnit = typeOfUnit;
            this.type = type;
            angle = 0;
            this.Position = Position;
            Destination = Position;
            this.position = position;
            alive = true; 


        }

        public void DrawUnit(SpriteBatch spriteBatch, GraphicsDeviceManager graphics, Texture2D[] units, int camX, int camY, SpriteFont font, Network net, int index)
        {
            if (life > 0)
            {
                if (alive)
                {
                    spriteBatch.Draw(units[imageUsed], new Vector2(position.X - camX + graphics.PreferredBackBufferWidth / 2 + units[type].Width / 2 - 20
                        , position.Y - camY + graphics.PreferredBackBufferHeight / 2 + units[type].Height / 2 - 20), null, Color.White,
                        (MathHelper.Pi / 180) * (float)angle, new Vector2(units[imageUsed].Width / 2, units[imageUsed].Height / 2), 1.0f, SpriteEffects.None, 1.0f);
                }

                if (selected == true)
                {
                    spriteBatch.DrawString(font, Position.X.ToString() + "," + Position.Y.ToString(), new Vector2((float)position.X - camX + graphics.PreferredBackBufferWidth / 2 + units[type].Width / 2 - 25
                   , (float)position.Y - camY + graphics.PreferredBackBufferHeight / 2 + units[type].Height / 2 - 20), Color.Red);
                }
                if (path.Count != 0)
                {
                    destination = new Vector2(map[path[0].X, path[0].Y].position.X - camX + graphics.PreferredBackBufferWidth / 2 + units[type].Width / 2 - 20
                                         , map[path[0].X, path[0].Y].position.Y - camY + graphics.PreferredBackBufferHeight / 2 + units[type].Height / 2 - 20);
                    pathFound = false;
                    //if (net.connected == true)
                    //{
                    //    net.sendData("&u", type, destination, "", true);
                    //}
                    if (position.X - camX + graphics.PreferredBackBufferWidth / 2 + units[type].Width / 2 - 20 + 2 >= destination.X &&
                        position.X - camX + graphics.PreferredBackBufferWidth / 2 + units[type].Width / 2 - 20 <= destination.X + 4 &&
                        position.Y - camY + graphics.PreferredBackBufferHeight / 2 + units[type].Height / 2 - 20 + 2 >= destination.Y &&
                        position.Y - camY + graphics.PreferredBackBufferHeight / 2 + units[type].Height / 2 - 20 <= destination.Y + 4
                       )
                    {

                        map[Position.X, Position.Y].Blocked = false;
                        Position = new Point(path[0].X, path[0].Y);
                        map[Position.X, Position.Y].thereIsUnit = false;
                        path.RemoveAt(0);

                    }

                    update_angles(net, index);

                }
                else
                {
                    pathFound = true;
                }
                unitRect = new Rectangle((int)(position.X - camX + graphics.PreferredBackBufferWidth / 2 + units[type].Width / 2 - 20),
                    (int)(position.Y - camY + graphics.PreferredBackBufferHeight / 2 + units[type].Height / 2 - 20), units[type].Width,
                    units[type].Height);
            }
            else
            {

            }
        }
        public void update_angles(Network net, int index)
        {

            if (newAngle != angle)
            {
                int so = Math.Abs((int)angle - (int)newAngle);
                if (so < 180 && (angle < newAngle))
                {
                    angle++;
                    if (net.connected == true)
                    {
                        net.sendData("&a", index, position, angle.ToString(), true);
                    }
                }
                if (so < 180 && (angle > newAngle))
                {
                    angle--;
                    if (net.connected == true)
                    {
                        net.sendData("&a", index, position, angle.ToString(), true);
                    }
                }
                if (so > 180 && (angle < newAngle))
                {
                    angle--;
                    if (net.connected == true)
                    {
                        net.sendData("&a", index, position, angle.ToString(), true);
                    }
                }
                if (so > 180 && (angle > newAngle))
                {
                    angle++;
                    if (net.connected == true)
                    {
                        net.sendData("&a", index, position, angle.ToString(), true);
                    }
                }
                if (angle > 359)
                {
                    angle = 0;
                    if (net.connected == true)
                    {
                        net.sendData("&a", index, position, angle.ToString(), true);
                    }
                }
                if (angle < 0)
                {
                    {
                        angle = 360;
                        if (net.connected == true)
                        {
                            net.sendData("&a", index, position, angle.ToString(), true);
                        }
                    }
                }
            }
            else if (position != destination)
            {
                position.X += (float)(1 * Math.Cos((angle - 90) * (MathHelper.Pi / 180)));
                position.Y += (float)(1 * Math.Sin((angle - 90) * (MathHelper.Pi / 180)));
                if (net.connected == true)
                {
                    net.sendData("&u", type, position, "", true);
                }

            }
        }
        public double calcAngle(float oX, float oY, float dX, float dY)
        {
            double a = 0.0f;
            a = Math.Atan2((dY - oY), (dX - oX)) + MathHelper.Pi / 2;
            while (a < 0)
            {
                a += MathHelper.Pi * 2;
            }
            int t = (int)(a / (MathHelper.Pi / 180));
            return (double)t;

        }
        public void isSelected(int camX, int camY, Texture2D[] myText, GraphicsDeviceManager graphics)
        {
            if (Mouse.GetState().X > position.X - camX + graphics.PreferredBackBufferWidth / 2 - myText[type].Width / 2
                  && Mouse.GetState().X < position.X - camX + graphics.PreferredBackBufferWidth / 2 - myText[type].Width / 2 + 40
                  && Mouse.GetState().Y > position.Y - camY + graphics.PreferredBackBufferHeight / 2 - myText[type].Height / 2
                  && Mouse.GetState().Y < position.Y - camY + graphics.PreferredBackBufferHeight / 2 - myText[type].Height / 2 + 40
                  && side == 1)
            {
                mouse_over = 1;
            }
            else
            {
                mouse_over = 0;
            }
        }
    }
}
