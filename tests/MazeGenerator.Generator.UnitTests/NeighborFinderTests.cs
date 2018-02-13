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
            Assert.IsTrue(neighbors.Any(n => n.Neighbor.X == 2 && n.Neighbor.Y == 3)); // up
            Assert.IsTrue(neighbors.Any(n => n.Neighbor.X == 3 && n.Neighbor.Y == 2)); // left
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
            Assert.IsTrue(neighbors.Any(n => n.Neighbor.X == 2 && n.Neighbor.Y == 1)); // bottom
        }

        [TestMethod]
        public void CheckUpperNeighbor_NeighborExistsAndHasAllWalls_NeighborReturned()
        {
            Maze maze = new Maze(2);
            MazeCell cell = maze[1][0];

            NeighborMazeCell neighbor = this.neighborFinder.CheckUpperNeighbor(cell, maze);
            Assert.IsNotNull(neighbor);
            Assert.AreEqual(MazeWall.Top, neighbor.CellWall);
        }

        [TestMethod]
        public void CheckUpperNeighbor_NeighborDoesntExists_NullReturned()
        {
            Maze maze = new Maze(2);
            MazeCell cell = maze[0][0];

            Assert.IsNull(this.neighborFinder.CheckUpperNeighbor(cell, maze));
        }

        [TestMethod]
        public void CheckUpperNeighbor_NeighborExistsAndHasNotAllWalls_NullReturned()
        {
            Maze maze = new Maze(2);
            maze[0][0].KnockDownWall(MazeWall.Right);
            MazeCell cell = maze[1][0];

            Assert.IsNull(this.neighborFinder.CheckUpperNeighbor(cell, maze));
        }

        [TestMethod]
        public void CheckBottomNeighbor_NeighborExistsAndHasAllWalls_NeighborReturned()
        {
            Maze maze = new Maze(2);
            MazeCell cell = maze[0][1];

            NeighborMazeCell neighbor = this.neighborFinder.CheckBottomNeighbor(cell, maze);
            Assert.IsNotNull(neighbor);
            Assert.AreEqual(MazeWall.Bottom, neighbor.CellWall);
        }

        [TestMethod]
        public void CheckBottomNeighbor_NeighborDoesntExists_NullReturned()
        {
            Maze maze = new Maze(2);
            MazeCell cell = maze[1][1];

            Assert.IsNull(this.neighborFinder.CheckBottomNeighbor(cell, maze));
        }

        [TestMethod]
        public void CheckBottomNeighbor_NeighborExistsAndHasNotAllWalls_NullReturned()
        {
            Maze maze = new Maze(2);
            maze[1][0].KnockDownWall(MazeWall.Right);
            MazeCell cell = maze[0][0];

            Assert.IsNull(this.neighborFinder.CheckBottomNeighbor(cell, maze));
        }

        [TestMethod]
        public void CheckLeftNeighbor_NeighborExistsAndHasAllWalls_NeighborReturned()
        {
            Maze maze = new Maze(2);
            MazeCell cell = maze[1][1];

            NeighborMazeCell neighbor = this.neighborFinder.CheckLeftNeighbor(cell, maze);
            Assert.IsNotNull(neighbor);
            Assert.AreEqual(MazeWall.Left, neighbor.CellWall);
        }

        [TestMethod]
        public void CheckLeftNeighbor_NeighborDoesntExists_NullReturned()
        {
            Maze maze = new Maze(2);
            MazeCell cell = maze[0][0];

            Assert.IsNull(this.neighborFinder.CheckLeftNeighbor(cell, maze));
        }

        [TestMethod]
        public void CheckLeftNeighbor_NeighborExistsAndHasNotAllWalls_NullReturned()
        {
            Maze maze = new Maze(2);
            maze[0][0].KnockDownWall(MazeWall.Bottom);
            MazeCell cell = maze[0][1];

            Assert.IsNull(this.neighborFinder.CheckLeftNeighbor(cell, maze));
        }

        [TestMethod]
        public void CheckRightNeighbor_NeighborExistsAndHasAllWalls_NeighborReturned()
        {
            Maze maze = new Maze(2);
            MazeCell cell = maze[1][0];

            NeighborMazeCell neighbor = this.neighborFinder.CheckRightNeighbor(cell, maze);
            Assert.IsNotNull(neighbor);
            Assert.AreEqual(MazeWall.Right, neighbor.CellWall);
        }

        [TestMethod]
        public void CheckRightNeighbor_NeighborDoesntExists_NullReturned()
        {
            Maze maze = new Maze(2);
            MazeCell cell = maze[0][1];

            Assert.IsNull(this.neighborFinder.CheckRightNeighbor(cell, maze));
        }

        [TestMethod]
        public void CheckRightNeighbor_NeighborExistsAndHasNotAllWalls_NullReturned()
        {
            Maze maze = new Maze(2);
            maze[0][1].KnockDownWall(MazeWall.Top);
            MazeCell cell = maze[0][0];

            Assert.IsNull(this.neighborFinder.CheckRightNeighbor(cell, maze));
        }
    }
}
