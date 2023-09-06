using Short_path_finder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Map Representation:

//Create a data structure to represent your game map. You can use a 2D array of integers, where 0 represents accessible terrain, and 1 represents elevated terrain.

//Node Representation:

//Create a node class to represent each point on the map. This node should store information like its position, parent node (to reconstruct the path), cost to reach, and heuristic (estimated) cost to the destination.

//Path Find Algorithm:

//•	This algorithm to find the path from the starting point to the finish point. The algorithm involves maintaining two lists: an open list and a closed list.
//•	Start with the initial node (starting point) and add it to the open list.
//•	While the open list is not empty, do the following:
//•	Find the node with the lowest total cost (sum of cost to reach and heuristic) from the open list.
//•	If this node is the finish point, you have found the path.
//•	Otherwise, expand the current node by considering its neighbors (adjacent cells).
//•	Calculate the cost to reach each neighbor and their heuristics.
//•	If a neighbor is not in the open list, add it; if it's in the open list and the new path is cheaper, update its values.
//•	Move the current node to the closed list.
//•	Once you reach the finish point or the open list is empty, reconstruct the path by following parent pointers from the finish node back to the start.

namespace Short_path_finder.Algoritham
{
    public class ShortestParhFinder
    {
        public static List<Node> FindPath(Node[,] grid, Node startNode, Node targetNode)
        {
            List<Node> openSet = new List<Node>();
            HashSet<Node> closedSet = new HashSet<Node>();

            openSet.Add(startNode);

            while (openSet.Count > 0)
            {
                Node currentNode = openSet[0];

                for (int i = 1; i < openSet.Count; i++)
                {
                    if (openSet[i].fCost < currentNode.fCost || (openSet[i].fCost == currentNode.fCost && openSet[i].hCost < currentNode.hCost))
                    {
                        currentNode = openSet[i];
                    }
                }

                openSet.Remove(currentNode);
                closedSet.Add(currentNode);

                if (currentNode == targetNode)
                {
                    return RetracePath(startNode, targetNode);
                }

                foreach (Node neighbor in GetNeighbors(grid, currentNode))
                {
                    if (!neighbor.walkable || closedSet.Contains(neighbor))
                    {
                        continue;
                    }

                    int newCostToNeighbor = currentNode.gCost + GetDistance(currentNode, neighbor);

                    if (newCostToNeighbor < neighbor.gCost || !openSet.Contains(neighbor))
                    {
                        neighbor.gCost = newCostToNeighbor;
                        neighbor.hCost = GetDistance(neighbor, targetNode);
                        neighbor.parent = currentNode;

                        if (!openSet.Contains(neighbor))
                        {
                            openSet.Add(neighbor);
                        }
                    }
                }
            }

            // No path found
            return null;
        }

        private static List<Node> RetracePath(Node startNode, Node endNode)
        {
            List<Node> path = new List<Node>();
            Node currentNode = endNode;

            while (currentNode != startNode)
            {
                path.Add(currentNode);
                currentNode = currentNode.parent;
            }

            path.Reverse();
            return path;
        }

        private static List<Node> GetNeighbors(Node[,] grid, Node node)
        {
            List<Node> neighbors = new List<Node>();
            int[] xOffsets = { -1, 0, 1, 0 };
            int[] yOffsets = { 0, 1, 0, -1 };

            for (int i = 0; i < 4; i++)
            {
                int x = node.x + xOffsets[i];
                int y = node.y + yOffsets[i];

                if (x >= 0 && x < grid.GetLength(0) && y >= 0 && y < grid.GetLength(1))
                {
                    neighbors.Add(grid[x, y]);
                }
            }

            return neighbors;
        }

        private static int GetDistance(Node nodeA, Node nodeB)
        {
            int dstX = Math.Abs(nodeA.x - nodeB.x);
            int dstY = Math.Abs(nodeA.y - nodeB.y);

            return dstX + dstY;
        }
    }
}
