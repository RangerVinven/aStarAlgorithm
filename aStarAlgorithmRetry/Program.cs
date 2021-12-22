using System;

namespace aStarAlgorithmRetry
{
    class Program
    {
        static void Main(string[] args)
        {
            Node startNode = new Node(new Tuple<int, int>(0, 9), Node.Type.StartNode);
            Node endNode = new Node(new Tuple<int, int>(9, 0), Node.Type.EndNode);
            Grid grid = new Grid(startNode, endNode, new Tuple<int, int>(10, 10));

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