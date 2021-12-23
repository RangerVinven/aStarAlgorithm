using System;
using System.Collections.Generic;

namespace aStarAlgorithmRetry
{
    class Program
    {
        static void Main(string[] args)
        {
            Node startNode = new Node(new Tuple<int, int>(0, 9), Node.Type.StartNode);
            Node endNode = new Node(new Tuple<int, int>(10, 10), Node.Type.EndNode);
            List<Node> obstacles = new List<Node> { new Node(new Tuple<int, int>(3, 9), Node.Type.Obstacle), new Node(new Tuple<int, int>(6, 8), Node.Type.Obstacle), new Node(new Tuple<int, int>(7, 7), Node.Type.Obstacle), new Node(new Tuple<int, int>(9, 10), Node.Type.Obstacle) };

            Grid grid = new Grid(startNode, endNode, obstacles, new Tuple<int, int>(20, 20));

            grid.displayGrid(grid);
            Console.WriteLine("--------------------");
            
            // Loop until the current node is in the position of the end node
            while (grid.currentNode.coords.Item1 != grid.endNode.coords.Item1 || grid.currentNode.coords.Item2 != grid.endNode.coords.Item2) {
                grid = grid.findTouchingNodes(grid);
                grid = grid.moveToBestSpace(grid);
            }

            // Changes the text of the end node back to "E" as it changes to "L" when moving to the best node
            grid.currentNode.text = 'E';
            grid.displayGrid(grid);
            
        }
    }
}