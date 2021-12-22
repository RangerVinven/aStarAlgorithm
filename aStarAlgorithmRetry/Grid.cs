using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace aStarAlgorithmRetry
{
    public class Grid {
        private List<List<Node>> grid;
        private Node currentNode { get; set; }
        private Node startNode { get; set; }
        private Node endNode { get; set; }
        private int distanceTravelled { get; set; }

        // For keeping track of which nodes to consider when choosing the next node
        private List<Tuple<int, Tuple<int, int>>> nodesToConsider { get; set; }

        public Grid(Node startNode, Node endNode) {
            this.startNode = startNode;
            this.endNode = endNode;
            currentNode = startNode;
        }
        
        public static Grid findTouchingNodes(Grid grid) {
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
            if (grid.currentNode.coords.Item2 < grid.grid[0].Count) {
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
            if (grid.currentNode.coords.Item1 < grid.grid.Count) {
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
        }
        
        public static Node findCostsOfNode(Node node) {}
        
        public static Grid moveToBestSpace(Grid grid) {}
        
    }

}