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
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GPM20BT_Practical1
{
    class Path
    {
        public List<Point> openlist = new List<Point>();
        public List<Point> closelist = new List<Point>();
        public List<Point> path = new List<Point>();
        public int opcount = 0;
        public int clcount = 0;
        public Path()
        {
            opcount = 0;
            clcount = 0;
        }
        public bool isInList(List<Point> li, Point p)
        {
            bool flag = false;
            for (int i = 0; i < li.Count; i++)
            {
                if (li[i] == p)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
        public void reconstructPath(Point end, Point start, Point[,] parent, List<Point> pth)
        {
            Point current = end;
            do
            {
                path.Add(current);
                current = parent[current.Y, current.X];
            }
            while (current != start);
            for (int k = (path.Count - 1); k >= 0; k--)
            {
                pth.Add(path[k]);
            }
        }
        public void addToOpenList(Point lc, Point end, bool[,] map, int[,] cost, Point[,] parent)
        {
            for (int y = lc.Y - 1; y < lc.Y + 2; y++)
            {
                for (int x = lc.X - 1; x < lc.X + 2; x++)
                {
                    if (y >= 0 && y < map.GetLength(0) && x >= 0 && x < map.GetLength(1) && !(x == lc.X && y == lc.Y) && !isInList(closelist, new Point(x, y)) && !isInList(openlist, new Point(x, y)))
                    {
                        if (x != lc.X && y != lc.Y)
                        {
                            if (map[y, lc.X] && map[lc.Y, x] && map[y, x])
                            {
                                openlist.Add(new Point(x, y));
                                cost[y, x] = cost[lc.Y, lc.X] + 15 + (Math.Abs(x - end.X) + Math.Abs(y - end.Y));
                                parent[y, x] = lc;
                            }
                        }
                        else
                        {
                            if (map[y, x])
                            {
                                openlist.Add(new Point(x, y));
                                cost[y, x] = cost[lc.Y, lc.X] + 10 + (Math.Abs(x - end.X) + Math.Abs(y - end.Y));
                                parent[y, x] = lc;
                            }
                        }
                    }
                }
            }
        }
        public bool findPath(bool[,] map, Point start, Point end, int[,] cost, Point[,] parent, List<Point> pth)
        {
            bool ret = false;
            openlist[0] = start;
            while (openlist.Count > 0)
            {
                Point lowestCost = openlist[0];
                int indexer = 0;
                for (int i = 0; i < openlist.Count; i++)
                {
                    if (cost[openlist[i].Y, openlist[i].X] < cost[lowestCost.Y, lowestCost.X])
                    {
                        indexer = i;
                        lowestCost = openlist[i];
                    }
                }
                openlist.RemoveAt(indexer);
                if (lowestCost == end)
                {
                    reconstructPath(lowestCost, start, parent, pth);
                    ret = true;
                    break;
                }
                addToOpenList(lowestCost, end, map, cost, parent);
                closelist.Add(lowestCost);
                //break;
            }
            return ret;
        }
    }
}
