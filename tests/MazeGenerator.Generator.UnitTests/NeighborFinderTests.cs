using System;
using System.Collections.Generic;
using System.Linq;
using MazeGenerator.ObjectModel;
using MazeGenerator.ObjectModel.Maze;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MazeGenerator.Generator.UnitTests
{
    [TestClass]
    public class NeighborFinderTests
    {
        private readonly NeighborFinder neighborFinder = new NeighborFinder();

        [TestMethod]
        public void FindNeighborsWithAllWallIntact_RightBottomCornerCell_UpAndLeftNeighborReturned()
        {
            Maze maze = new Maze(4);
            MazeCell cell = maze[3][3];

            List<NeighborMazeCell> neighbors = this.neighborFinder.FindNeighborsWithAllWalls(cell, maze);

            Assert.AreEqual(2, neighbors.Count);
            Assert.IsTrue(neighbors.All(n => n.Cell.X == 3 && n.Cell.Y == 3));
            Assert.IsTrue(neighbors.Any(n => n.Neighbor.X == 3 && n.Neighbor.Y == 2)); // left
            Assert.IsTrue(neighbors.Any(n => n.Neighbor.X == 2 && n.Neighbor.Y == 3)); // down
        }

        [TestMethod]
        public void FindNeighborsWithAllWallIntact_MiddleCornerAndTopNeighborIsNotIntact_LeftRightBottomNeighborReturned()
        {
            Maze maze = new Maze(3);
            maze[0][1].KnockDownWall(MazeWall.Left);

            MazeCell cell = maze[1][1];

            List<NeighborMazeCell> neighbors = this.neighborFinder.FindNeighborsWithAllWalls(cell, maze);

            Assert.AreEqual(3, neighbors.Count);
            Assert.IsTrue(neighbors.All(n => n.Cell.X == 1 && n.Cell.Y == 1));
            Assert.IsTrue(neighbors.Any(n => n.Neighbor.X == 1 && n.Neighbor.Y == 0)); // left
            Assert.IsTrue(neighbors.Any(n => n.Neighbor.X == 1 && n.Neighbor.Y == 2)); // right
            Assert.IsTrue(neighbors.Any(n => n.Neighbor.X == 2 && n.Neighbor.Y == 1)); // up
        }
    }
}
