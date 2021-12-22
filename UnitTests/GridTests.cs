using System;
using System.Collections.Generic;
using System.Linq;
using aStarAlgorithmRetry;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GridTests
{
    [TestClass]
    public class GridTests {
        
        [TestMethod]
        public void findTouchingNodes_TouchingAllNodes() {
            // Arrange
            Node startNode = new Node(new Tuple<int, int>(1, 1), Node.Type.StartNode);
            Node endNode = new Node(new Tuple<int, int>(3, 3), Node.Type.EndNode);
            Grid grid = new Grid(startNode, endNode);

            List<Tuple<int, Tuple<int, int>>> expectedOutput = new List<Tuple<int, Tuple<int, int>>>
                {new(6, new Tuple<int, int>(0, 1)), new(4, new Tuple<int, int>(1, 2)), new(4, new Tuple<int, int>(2, 1)), new(6, new Tuple<int, int>(1, 0))};

            // Act
            grid = grid.findTouchingNodes(grid);

            // Assert
            bool areSameValues = true;
            
            // Loops through the expectedOutput variable to make sure it matches with the actual output
            for (int i = 0; i < expectedOutput.Count; i++)
            {
                if (!Equals(grid.nodesToConsider[i], expectedOutput[i])) {
                    areSameValues = false;
                }
            }
            
            Assert.IsTrue(areSameValues);
            
        }
        
        [TestMethod]
        public void findTouchingNodes_TouchingAllNodesExceptTop() {
            // Arrange
            Node startNode = new Node(new Tuple<int, int>(0, 1), Node.Type.StartNode);
            Node endNode = new Node(new Tuple<int, int>(3, 3), Node.Type.EndNode);
            Grid grid = new Grid(startNode, endNode);

            List<Tuple<int, Tuple<int, int>>> expectedOutput = new List<Tuple<int, Tuple<int, int>>>
                {new(5, new Tuple<int, int>(0, 2)), new(5, new Tuple<int, int>(1, 1)), new(7, new Tuple<int, int>(0, 0))};

            // Act
            grid = grid.findTouchingNodes(grid);

            // Assert
            bool areSameValues = true;
            
            // Loops through the expectedOutput variable to make sure it matches with the actual output
            for (int i = 0; i < expectedOutput.Count; i++)
            {
                if (!Equals(grid.nodesToConsider[i], expectedOutput[i])) {
                    Console.WriteLine("{0} - {1}", grid.nodesToConsider[i], expectedOutput[i]);
                    areSameValues = false;
                }
            }
            
            Assert.IsTrue(areSameValues);
            
        }
        
        [TestMethod]
        public void findTouchingNodes_TouchingAllNodesExceptRight() {
            // Arrange
            Node startNode = new Node(new Tuple<int, int>(1, 3), Node.Type.StartNode);
            Node endNode = new Node(new Tuple<int, int>(3, 3), Node.Type.EndNode);
            Grid grid = new Grid(startNode, endNode);

            List<Tuple<int, Tuple<int, int>>> expectedOutput = new List<Tuple<int, Tuple<int, int>>>
                {new(4, new Tuple<int, int>(0, 3)), new(2, new Tuple<int, int>(2, 3)), new(4, new Tuple<int, int>(1, 2))};

            // Act
            grid = grid.findTouchingNodes(grid);

            // Assert
            bool areSameValues = true;
            
            // Loops through the expectedOutput variable to make sure it matches with the actual output
            for (int i = 0; i < expectedOutput.Count; i++)
            {
                if (!Equals(grid.nodesToConsider[i], expectedOutput[i])) {
                    Console.WriteLine("{0} - {1}", grid.nodesToConsider[i], expectedOutput[i]);
                    areSameValues = false;
                }
            }
            
            Assert.IsTrue(areSameValues);
            
        }
        
        [TestMethod]
        public void findTouchingNodes_TouchingAllNodesExceptLeft() {
            // Arrange
            Node startNode = new Node(new Tuple<int, int>(1, 0), Node.Type.StartNode);
            Node endNode = new Node(new Tuple<int, int>(3, 3), Node.Type.EndNode);
            Grid grid = new Grid(startNode, endNode);

            List<Tuple<int, Tuple<int, int>>> expectedOutput = new List<Tuple<int, Tuple<int, int>>>
                {new(7, new Tuple<int, int>(0, 0)), new(5, new Tuple<int, int>(1, 1)), new(5, new Tuple<int, int>(2, 0))};

            // Act
            grid = grid.findTouchingNodes(grid);

            // Assert
            bool areSameValues = true;
            
            // Loops through the expectedOutput variable to make sure it matches with the actual output
            for (int i = 0; i < expectedOutput.Count; i++)
            {
                if (!Equals(grid.nodesToConsider[i], expectedOutput[i])) {
                    Console.WriteLine("{0} - {1}", grid.nodesToConsider[i], expectedOutput[i]);
                    areSameValues = false;
                }
            }
            
            Assert.IsTrue(areSameValues);
            
        }
        
    }
}