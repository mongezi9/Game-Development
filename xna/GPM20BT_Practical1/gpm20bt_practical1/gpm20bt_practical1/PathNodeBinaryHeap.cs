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
namespace GPM20BT_Practical1
{
    class PathNodeBinaryHeap
    {
        PathNode[] Nodes;
        int ItemCount;

        public int Count { get { return ItemCount; } }

        public PathNode TopNode { get { return Nodes[0]; } }

        
        public PathNodeBinaryHeap(int mapWidth, int mapHeight)
        {
            // Create an array same size as map for binary tree
            Nodes = new PathNode[mapWidth * mapHeight];
            ItemCount = 0;
        }

        /// <summary>
        /// Adds node to bottom of the heap and sorts it up to its appropriate place. 
        /// </summary>
        /// <param name="node"></param>
        public void AddNode(PathNode node)
        {

            Nodes[ItemCount] = node;
            int currentIndex = ItemCount;
            ItemCount++;

            PathNode temp;

            // Make sure not at top node
            while (currentIndex != 0)
            {
                // If parent node higher cost then swap them round else end moving of node
                if (Nodes[currentIndex].Cost <= Nodes[currentIndex / 2].Cost)
                {
                    temp = Nodes[currentIndex];
                    Nodes[currentIndex] = Nodes[currentIndex / 2];
                    Nodes[currentIndex / 2] = temp;

                    // Move onto next parent
                    currentIndex /= 2;

                }
                else
                    return;
            }


        }

        /// <summary>
        /// Removes node and resorts the heap slightly so nodes are
        /// moved back into their appropriate places. 
        /// </summary>
        /// <param name="node"></param>
        public void RemoveNode(PathNode node)
        {
            int nodeIndex = FindNode(node);

            // Put bottom node in top slot
            ItemCount--;
            Nodes[nodeIndex] = Nodes[ItemCount];
            Nodes[ItemCount] = null;

            PathNode temp;
            int currentIndex = nodeIndex, index;
            while (true)
            {
                index = currentIndex;

                // If both children exist
                if (2 * index + 1 <= ItemCount - 1)
                {
                    if (Nodes[index].Cost >= Nodes[2 * index].Cost)
                        currentIndex = 2 * index;

                    if (Nodes[currentIndex].Cost >= Nodes[2 * index + 1].Cost)
                        currentIndex = 2 * index + 1;
                }
                // Only one child exists
                else if (2 * index <= ItemCount - 1)
                {
                    if (Nodes[index].Cost >= Nodes[2 * index].Cost)
                        currentIndex = 2 * index;
                }

                if (index != currentIndex)
                {
                    temp = Nodes[index];
                    Nodes[index] = Nodes[currentIndex];
                    Nodes[currentIndex] = temp;
                }
                else
                    return;

            }

        }
        /// <summary>
        /// Resorts node with a new LOWER cost
        /// </summary>
        /// <param name="node"></param>
        public void ResortNodeUp(PathNode node)
        {
            int currentIndex = FindNode(node);
            PathNode temp;
            // Make sure not at top node
            while (currentIndex > 0)
            {
                // If parent node higher cost then swap them round else end moving of node
                if (Nodes[currentIndex].Cost < Nodes[currentIndex / 2].Cost)
                {
                    temp = Nodes[currentIndex];
                    Nodes[currentIndex] = Nodes[currentIndex / 2];
                    Nodes[currentIndex / 2] = temp;

                    // Move onto next parent
                    currentIndex /= 2;

                }
                else
                    return;
            }
        }

        private int FindNode(PathNode node)
        {
            for (int i = 0; i < Nodes.Length; i++)
                if (Nodes[i] == node)
                    return i;

            throw new Exception("Cannot find node in open list");
        }
        public PathNode FindByPosition(Point position)
        {

            foreach (PathNode node in Nodes)
            {
                if (node == null)
                    return null;

                if (node.Position == position)
                    return node;
            }

            return null;
        }

        public void Dispose()
        {
            Nodes = null;
            GC.Collect();
        }



    }
}
