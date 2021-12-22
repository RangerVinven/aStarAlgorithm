using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace aStarAlgorithmRetry
{
    public class Grid {
        private List<List<Node>> grid;
        public Node currentNode { get; set; }
        public Node startNode { get; set; }
        public Node endNode { get; set; }
        private int distanceTravelled { get; set; }

        // For keeping track of which nodes to consider when choosing the next node
        public List<Tuple<int, Tuple<int, int>>> nodesToConsider { get; set; }

        public Grid(Node startNode, Node endNode, Tuple<int, int> gridDimensions) {
            this.startNode = startNode;
            this.endNode = endNode;
            currentNode = startNode;

            // Creates the grid
            grid = new List<List<Node>>();
            for (int row = 0; row < gridDimensions.Item2; row++) {
                grid.Add(new List<Node>());

                for (int column = 0; column < gridDimensions.Item2; column++) {
                    // Checks if the current node is an start node, end node, or neither, then adds the appropriate node
                    if (row == startNode.coords.Item1 && column == startNode.coords.Item2) {
                        grid[row].Add(startNode);
                    } else if (row == endNode.coords.Item1 && column == endNode.coords.Item2) {
                        grid[row].Add(endNode);
                    }
                    else {
                        grid[row].Add(new Node(new Tuple<int, int>(row, column), Node.Type.Regular));
                    }
                }
                
            }

            nodesToConsider = new List<Tuple<int, Tuple<int, int>>>();

        }
        
        public Grid findTouchingNodes(Grid grid) {
            Node touchingNode;
            
            // Checks if the current node is touching the above node (or if it's at the top) and that it isn't an obstacle
            if (grid.currentNode.coords.Item1 > 0) {
                // Makes sure the above node isn't an obstacle
                if (grid.grid[grid.currentNode.coords.Item1 - 1][grid.currentNode.coords.Item2].type != Node.Type.Obstacle) {

                    // Sets the touchingNode variable
                    touchingNode = new Node(new Tuple<int, int>(grid.currentNode.coords.Item1 - 1, grid.currentNode.coords.Item2), Node.Type.Regular);

                    // Gets the h, g and f cost of the touching node 
                    int hCostOfTouchingNode = Node.calculateHcost(new Tuple<int, int>(touchingNode.coords.Item1, touchingNode.coords.Item2), new Tuple<int, int>(grid.endNode.coords.Item1, grid.endNode.coords.Item2));
                    int gCostOfTouchingNode = Node.calculateGcost(grid.distanceTravelled);
                    int fCostOfTouchingNode = Node.calculateFcost(hCostOfTouchingNode, gCostOfTouchingNode);
                    
                    // Adds the touching node to the nodesToConsider list
                    grid.nodesToConsider.Add(new Tuple<int, Tuple<int, int>>(fCostOfTouchingNode, new Tuple<int, int>(touchingNode.coords.Item1, touchingNode.coords.Item2)));
                }

            }
            
            // Checks if the current node is touching the node to the right and that it isn't an obstacle
            if (grid.currentNode.coords.Item2 < grid.grid[0].Count-1) {
                
                // Makes sure the above node isn't an obstacle
                if (grid.grid[grid.currentNode.coords.Item1][grid.currentNode.coords.Item2 + 1].type != Node.Type.Obstacle) {

                    // Sets the touchingNode variable
                    touchingNode = new Node(new Tuple<int, int>(grid.currentNode.coords.Item1, grid.currentNode.coords.Item2 + 1), Node.Type.Regular);

                    // Gets the h, g and f cost of the touching node 
                    int hCostOfTouchingNode = Node.calculateHcost(new Tuple<int, int>(touchingNode.coords.Item1, touchingNode.coords.Item2), new Tuple<int, int>(grid.endNode.coords.Item1, grid.endNode.coords.Item2));
                    int gCostOfTouchingNode = Node.calculateGcost(grid.distanceTravelled);
                    int fCostOfTouchingNode = Node.calculateFcost(hCostOfTouchingNode, gCostOfTouchingNode);
                    
                    // Adds the touching node to the nodesToConsider list
                    grid.nodesToConsider.Add(new Tuple<int, Tuple<int, int>>(fCostOfTouchingNode, new Tuple<int, int>(touchingNode.coords.Item1, touchingNode.coords.Item2)));
                }

            }
            
            // Checks if the current node is touching the below node and that it isn't an obstacle
            if (grid.currentNode.coords.Item1 < grid.grid.Count-1) {
                // Makes sure the above node isn't an obstacle
                if (grid.grid[grid.currentNode.coords.Item1 + 1][grid.currentNode.coords.Item2].type != Node.Type.Obstacle) {

                    // Sets the touchingNode variable
                    touchingNode = new Node(new Tuple<int, int>(grid.currentNode.coords.Item1 + 1, grid.currentNode.coords.Item2), Node.Type.Regular);

                    // Gets the h, g and f cost of the touching node 
                    int hCostOfTouchingNode = Node.calculateHcost(new Tuple<int, int>(touchingNode.coords.Item1, touchingNode.coords.Item2), new Tuple<int, int>(grid.endNode.coords.Item1, grid.endNode.coords.Item2));
                    int gCostOfTouchingNode = Node.calculateGcost(grid.distanceTravelled);
                    int fCostOfTouchingNode = Node.calculateFcost(hCostOfTouchingNode, gCostOfTouchingNode);
                    
                    // Adds the touching node to the nodesToConsider list
                    grid.nodesToConsider.Add(new Tuple<int, Tuple<int, int>>(fCostOfTouchingNode, new Tuple<int, int>(touchingNode.coords.Item1, touchingNode.coords.Item2)));
                }

            }
            
            // Checks if the current node is touching the node to the left and that it isn't an obstacle
            if (grid.currentNode.coords.Item2 > 0) {
                // Makes sure the above node isn't an obstacle
                if (grid.grid[grid.currentNode.coords.Item1][grid.currentNode.coords.Item2 - 1].type != Node.Type.Obstacle) {

                    // Sets the touchingNode variable
                    touchingNode = new Node(new Tuple<int, int>(grid.currentNode.coords.Item1, grid.currentNode.coords.Item2 - 1), Node.Type.Regular);

                    // Gets the h, g and f cost of the touching node 
                    int hCostOfTouchingNode = Node.calculateHcost(new Tuple<int, int>(touchingNode.coords.Item1, touchingNode.coords.Item2), new Tuple<int, int>(grid.endNode.coords.Item1, grid.endNode.coords.Item2));
                    int gCostOfTouchingNode = Node.calculateGcost(grid.distanceTravelled);
                    int fCostOfTouchingNode = Node.calculateFcost(hCostOfTouchingNode, gCostOfTouchingNode);
                    
                    // Adds the touching node to the nodesToConsider list
                    grid.nodesToConsider.Add(new Tuple<int, Tuple<int, int>>(fCostOfTouchingNode, new Tuple<int, int>(touchingNode.coords.Item1, touchingNode.coords.Item2)));
                }

            }

            return grid;

        }

        public Grid moveToBestSpace(Grid grid) {
            // Sets the position of the lowest f score
            int posOfLowestFcost = 0;
            
            // Loops through the nodesToConsider variable and finds the position of the lowest f score
            for (int i = 0; i < grid.nodesToConsider.Count-1; i++) {
                if (grid.nodesToConsider[i].Item1 < grid.nodesToConsider[posOfLowestFcost].Item1) {
                    posOfLowestFcost = i;
                }
            }

            // Gets the row and column coordinate of the touching node with the lowest f score
            int lowestFcostRow = grid.nodesToConsider[posOfLowestFcost].Item2.Item1;
            int lowestFcostColumn = grid.nodesToConsider[posOfLowestFcost].Item2.Item2;
            
            // Changes the text of the new current node to "L" to show the line
            grid.grid[lowestFcostRow][lowestFcostColumn].text = 'L';
            
            grid.currentNode = grid.grid[lowestFcostRow][lowestFcostColumn];

            return grid;
        }

        public void displayGrid(Grid grid) {
            // Loops through each row
            foreach (var row in grid.grid) {
                Console.Write("|");

                // Displays each column in the row
                foreach (var column in row) {
                    Console.Write(column.text);
                }
                Console.WriteLine("| ");
            }
        }

        
    }

}