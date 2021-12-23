using System;
using System.Collections.Generic;

namespace aStarAlgorithmRetry
{
    class Program
    {
        static void Main(string[] args)
        {
            Node startNode = new Node(new Tuple<int, int>(0, 10), Node.Type.StartNode);
            Node endNode = new Node(new Tuple<int, int>(10, 10), Node.Type.EndNode);
            List<Node> obstacles = new List<Node> { new Node(new Tuple<int, int>(5, 8), Node.Type.Obstacle), new Node(new Tuple<int, int>(5, 9), Node.Type.Obstacle), new Node(new Tuple<int, int>(5, 10), Node.Type.Obstacle), new Node(new Tuple<int, int>(5, 11), Node.Type.Obstacle), new Node(new Tuple<int, int>(5, 12), Node.Type.Obstacle), new Node(new Tuple<int, int>(4, 8), Node.Type.Obstacle), new Node(new Tuple<int, int>(3, 8), Node.Type.Obstacle), new Node(new Tuple<int, int>(4, 12), Node.Type.Obstacle), new Node(new Tuple<int, int>(3, 12), Node.Type.Obstacle) };

            Grid grid = new Grid(startNode, endNode, obstacles, new Tuple<int, int>(20, 20));

            grid.displayGrid(grid);
            Console.WriteLine("--------------------");


            bool startToEndImpossible= false;

            // Loop until the current node is in the position of the end node
            while (grid.currentNode.coords.Item1 != grid.endNode.coords.Item1 || grid.currentNode.coords.Item2 != grid.endNode.coords.Item2) {
                // Gets the row and column before moving to be used to check if the program is stuck
                int rowBeforeMove = grid.currentNode.coords.Item1;
                int columnBeforeMove = grid.currentNode.coords.Item2;

                grid = grid.findTouchingNodes(grid);
                grid = grid.moveToBestSpace(grid);

                if (grid.currentNode.coords.Item1 == rowBeforeMove && grid.currentNode.coords.Item2 == columnBeforeMove) {
                    Console.WriteLine("It's impossible to get to the endpoint");
                    startToEndImpossible = true;
                    break;
                }

            }

            // Only runs if it's possible to find a path from the start to the end node
            if(!startToEndImpossible) {
                // Changes the text of the end node back to "E" as it changes to "L" when moving to the best node
                grid.currentNode.text = 'E';
                grid.displayGrid(grid);
            }
            
        }
    }
}