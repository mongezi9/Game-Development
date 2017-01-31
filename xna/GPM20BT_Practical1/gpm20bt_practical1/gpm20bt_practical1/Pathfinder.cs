/*
 Name & Surname: Emmanuel Mthimunye
 Date: 2013 Sept 5
 Implementing Artificial Intelligent level 1,2,3 and 4 in Game design
 * Practical path planning to determine shortest path 
 * using A* aglorithm
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
    class Pathfinder
    {
        //MapTiles[,] Tiles;
        const int Max_ClosedNodes = 512;

        public Pathfinder()
        {
            // Set Map nodes - aka whatever your map is 
           // Tiles = nodes;

        }

        public List<Point> FindPath(Point start, Point end,GraphicsDeviceManager graphics,Texture2D[] ima,int cX,int cY,SpriteBatch batch,MapTiles[,] Tiles,List<Point> path)
        {
          
            // Record the starting tickcount so we can take it away later to
            // find out how long the pathfinding tooking
            //path = new List<Point>();
            int startTime = Environment.TickCount;

            // Create open and closed lists
            PathNodeBinaryHeap openList = new PathNodeBinaryHeap(Tiles.GetLength(0), Tiles.GetLength(1));
            List<PathNode> closedList = new List<PathNode>();

            // Add first node(the starting point)
            PathNode current = new PathNode(start, null, 0, 0);
            openList.AddNode(current);

            // Create variables to be used in loop
            int xStart, yStart, xEnd, yEnd, width = Tiles.GetLength(0), height = Tiles.GetLength(1),
                gCost, hCost;

            Point position = Point.Zero;

            // Node searching loop, this is where the squares get searched
            // to find the path
            while (true)
            {
                // Check adjacent squares
                xStart = Math.Max(current.Position.X - 1, 0);
                yStart = Math.Max(current.Position.Y - 1, 0);
                xEnd = Math.Min(current.Position.X + 1, width - 1);
                yEnd = Math.Min(current.Position.Y + 1, height - 1);

                for (int x = xStart; x <= xEnd; x++)
                    for (int y = yStart; y <= yEnd; y++)
                        if (!(x == current.Position.X && y == current.Position.Y))
                            if (!Tiles[x, y].IsBlocked())
                            {
                                gCost = current.G;
                                // If movement is diagonal give it a higher G scoring to 
                                // down play diagonals as good movement choices
                                if ((x == xStart && y == yStart) || (x == xEnd && y == xStart)
                                    || (x == xStart && y == yEnd) || (x == xEnd && y == yEnd))
                                    gCost += 14;
                                else
                                    gCost += 10;
                                position.X = x;
                                position.Y = y;

                                // Use manhattan heuristic to get the Heuristic code(guess how far away
                                // you are from the goal). This can be replaced with whatever heuristic you
                                // like
                                hCost = ManhattanHeuristic(position, end);

                                // Add nodes that are not impassible to open list
                                // Check node doesnt already exist
                                if (!NodeInList(position, closedList))
                                {
                                    PathNode node = openList.FindByPosition(position);
                                    // If node is not in open list add it
                                    if (node == null)
                                    {
                                        openList.AddNode(new PathNode(position, current, gCost, hCost));
                                        // Colour tile to show you've checked it - remove this in your actual game.
                                        //Tiles[position.X, position.Y].SetColor(Color.LightBlue);
                                    }
                                    else
                                    {
                                        // Check to see if moving from current square back to an already checked square
                                        // is lower cost G cost. If so recalculate ccost for this node and resort it 
                                        // in heap to its proper position
                                        if (node.G > gCost)
                                        {
                                            // Reparent and change costs                                   
                                            node.Parent = current;
                                            node.G = gCost;
                                            node.Cost = gCost + hCost;
                                            openList.ResortNodeUp(node);
                                        }
                                    }
                                }


                            }

                // Drop current node from open list and add to closed
                openList.RemoveNode(current);
                closedList.Add(current);
               // Tiles[current.Position.X, current.Position.Y].SetColor(Color.Blue);

                // Find lowest cost square and start again on that node
                if (openList.Count == 0)
                {
                    // No possible movement from start
                    return null;
                }

                current = openList.TopNode;

                // reached end
                if (current.Position == end)
                    break;


                // taking too long
                if (closedList.Count > Max_ClosedNodes)
                    break;

            }

            // Work back through parents to find path
            
            while (current.Parent != null)
            {
                path.Insert(0, current.Position);
                current = current.Parent;
                // Set colour of path, remove this in your actual game
                //Tiles[current.Position.X, current.Position.Y].type = 2;
                //drawRectangle((int)(Tiles[current.Position.X, current.Position.Y].position.X - cX + graphics.PreferredBackBufferWidth / 2 - ima[Tiles[current.Position.X, current.Position.Y].type].Width / 2 ),
                //    (int)(Tiles[current.Position.X, current.Position.Y].position.Y - cY + graphics.PreferredBackBufferHeight / 2 - ima[Tiles[current.Position.X, current.Position.Y].type].Height / 2),
                //     ima[Tiles[current.Position.X, current.Position.Y].type].Width, ima[Tiles[current.Position.X, current.Position.Y].type].Height, graphics, batch, Color.Yellow);
            }

            // Clear list resources used
            openList.Dispose();
            closedList.Clear();

            // Output time it took to calculate path in console
            Console.WriteLine("Path took: " + (Environment.TickCount - startTime));

            return path;
        }
        public void drawRectangle(int x1, int y1, int width, int height, GraphicsDeviceManager graphics, SpriteBatch batch, Color color)
        {
            Rectangle spriteTextnew;
            spriteTextnew = new Rectangle(x1, y1, width, height);
            int bw = 2;
            Texture2D t;
            t = new Texture2D(graphics.GraphicsDevice, 1, 1);

            t.SetData(new[] { Color.White });

            batch.Draw(t, new Rectangle(spriteTextnew.Left, spriteTextnew.Top, bw, spriteTextnew.Height), color); // Left
            batch.Draw(t, new Rectangle(spriteTextnew.Right, spriteTextnew.Top, bw, spriteTextnew.Height), color); // Right
            batch.Draw(t, new Rectangle(spriteTextnew.Left, spriteTextnew.Top, spriteTextnew.Width, bw), color); // Top
            batch.Draw(t, new Rectangle(spriteTextnew.Left, spriteTextnew.Bottom, spriteTextnew.Width + 2, bw), color);//bottom

        }

        /// <summary>
        /// This will work out a hueristic based on orthagonal movement only. Which may slightly
        /// overestimate the route. However you can change it to any hueristic you like. 
        /// </summary>
        /// <param name="current"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private int ManhattanHeuristic(Point current, Point end)
        {
            return 10 * (Math.Abs(current.X - end.X) + Math.Abs(current.Y - end.Y));
        }

        /// <summary>
        /// Checks if a node is in a list by its position.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="nodes"></param>
        /// <returns></returns>
        private bool NodeInList(Point position, List<PathNode> nodes)
        {
            foreach (PathNode node in nodes)
            {
                if (node.Position == position)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Returns node if it is in the given list by searching for its position,
        /// if it does not exist in it then it will return null.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="nodes"></param>
        /// <returns></returns>
        private PathNode FindNodeInList(Point position, List<PathNode> nodes)
        {
            foreach (PathNode node in nodes)
            {
                if (node.Position == position)
                    return node;
            }

            return null;
        }

    }

    /// <summary>
    /// Stores open and closed list nodes with their respective costs. 
    /// </summary>
    public class PathNode
    {
        public Point Position;
        public PathNode Parent;
        public int G;
        public int Cost;
        public PathNode(Point pos, PathNode parent, int g, int h)
        {
            Position = pos;
            Parent = parent;
            G = g;
            Cost = g + h;
        }
    }

    /// <summary>
    /// Inherit from this to build your map for the pathfinder
    /// then you can just drop in your array in the pathfinders
    /// constructor.
    /// </summary>
    public interface MapNode
    {
        bool IsBlocked();
        void SetColor(Color c);
    }
}
