using System;
using System.Collections.Generic;

namespace aStarAlgorithmRetry
{
    public class Node {
        public enum Type {
            StartNode,
            EndNode,
            Obstacle,
            Regular
        }
        
        public int? hCost { get; set; }
        private int? gCost { get; set; }
        public int? fCost { get; set; }
        public Tuple<int, int> coords;
        public Type type;
        public List<Tuple<int, int>> touchingNodesCoords;

        public Node(Tuple<int, int> nodeCoords, Type nodeType) {
            coords = nodeCoords;
            type = nodeType;

            hCost = null;
            gCost = null;
            fCost = null;

        }

        // Calculates the h cost of the node
        public static int calculateHcost(Tuple<int, int> nodeCoords, Tuple<int, int> endNodeCoords) {
            return Math.Abs(nodeCoords.Item1 - endNodeCoords.Item1) + Math.Abs(nodeCoords.Item2 - endNodeCoords.Item2);
        }

        // Calculate the g cost of the node
        public static int calculateGcost(int distanceTravelled) {
            return distanceTravelled + 1;
        }

        // Calculate the f cost of the node
        public static int calculateFcost(int hCost, int gCost) {
            return hCost + gCost;
        }

    }

}