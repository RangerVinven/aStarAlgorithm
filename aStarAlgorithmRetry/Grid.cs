using System;
using System.Collections.Generic;

namespace aStarAlgorithmRetry
{
    public class Grid {
        private List<List<Node>> grid;
        private Node currentNode { get; set; }
        private Node startNode { get; set; }
        private Node endNode { get; set; }

        // For keeping track of which nodes to consider when choosing the next node
        private List<Tuple<int, Tuple<int, int>>> nodesToConsider { get; set; }

        public Grid(Node startNode, Node endNode) {
            this.startNode = startNode;
            this.endNode = endNode;
            currentNode = startNode;
        }
        
        public static Grid findTouchingNodes() {}
        
        public static Node findCostsOfNode(Node node) {}
        
        public static Grid moveToBestSpace(Grid grid) {}
        
    }

}