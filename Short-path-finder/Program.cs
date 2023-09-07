using Short_path_finder.Algoritham;
using Short_path_finder.Model;
using System;
using System.Collections.Generic;
public class Program
{
    public static void Main()
    {
        // Create a grid with nodes 
     
        int [,] mapData = {
            {0, 0, 1, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 1, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 1, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 1, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 1, 0, 0, 0},
            {0, 0, 1, 1, 1, 1, 1, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 1, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 1, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
        };
        Node[,] grid = new Node[mapData.GetLength(0), mapData.GetLength(1)];

        // Initialize nodes and set their walkable property 
        for (int x = 0; x < mapData.GetLength(0); x++)
        {
            for (int y = 0; y < mapData.GetLength(1); y++)
            {
                bool walkable = mapData[x, y] == 0;
                grid[x, y] = new Node(x, y, walkable);
            }
        }

        Node startNode = grid[0, 0];       // Top-left corner
        Node targetNode = grid[1,1];     // Bottom-right corner

        List<Node> path = ShortestParhFinder.FindPath(grid, startNode, targetNode);

        if (path != null)
        {
            Console.WriteLine("Path found!");
            foreach (Node node in path)
            {
                Console.WriteLine($"({node.x}, {node.y})");
            }
        }
        else
        {
            Console.WriteLine("No path found!");
        }
    }
}

