using System;
using System.Collections.Generic;
using System.Linq;
using MazeGenerator.ObjectModel;
using MazeGenerator.ObjectModel.Maze;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MazeGenerator.Generator.UnitTests
{
    [TestClass]
    public class IntactWallHelperTests
    {
        private readonly IntactWallHelper intactWallHelper = new IntactWallHelper();

        [TestMethod]
        public void FindNeighborsWithAllWallIntact_RightBottomCornerCell_UpAndLeftNeighborReturned()
        {
            Maze maze = new Maze(4);
            MazeCell cell = maze[3][3];

            List<MazeCell> neighbors = this.intactWallHelper.FindNeighborsWithAllWallIntact(cell, maze);

            Assert.AreEqual(2, neighbors.Count);
            Assert.IsTrue(neighbors.Any(n => n.X == 2 && n.Y == 3)); // up
            Assert.IsTrue(neighbors.Any(n => n.X == 3 && n.Y == 2)); // left
        }

        [TestMethod]
        public void FindNeighborsWithAllWallIntact_MiddleCornerAndTopNeighborIsNotIntact_LeftRightBottomNeighborReturned()
        {
            Maze maze = new Maze(3);
            maze[0][1].KnockDownWall(MazeWall.Left);

            MazeCell cell = maze[1][1];

            List<MazeCell> neighbors = this.intactWallHelper.FindNeighborsWithAllWallIntact(cell, maze);

            Assert.AreEqual(3, neighbors.Count);
            Assert.IsTrue(neighbors.Any(n => n.X == 1 && n.Y == 0)); // left
            Assert.IsTrue(neighbors.Any(n => n.X == 1 && n.Y == 2)); // right
            Assert.IsTrue(neighbors.Any(n => n.X == 2 && n.Y == 1)); // bottom
        }

        [TestMethod]
        public void CheckUpperNeighbor_NeighborExistsAndHasAllWalls_NeighborReturned()
        {
            Maze maze = new Maze(2);
            MazeCell cell = maze[1][0];

            Assert.IsNotNull(this.intactWallHelper.CheckUpperNeighbor(cell, maze));
        }

        [TestMethod]
        public void CheckUpperNeighbor_NeighborDoesntExists_NullReturned()
        {
            Maze maze = new Maze(2);
            MazeCell cell = maze[0][0];

            Assert.IsNull(this.intactWallHelper.CheckUpperNeighbor(cell, maze));
        }

        [TestMethod]
        public void CheckUpperNeighbor_NeighborExistsAndHasNotAllWalls_NullReturned()
        {
            Maze maze = new Maze(2);
            maze[0][0].KnockDownWall(MazeWall.Right);
            MazeCell cell = maze[1][0];

            Assert.IsNull(this.intactWallHelper.CheckUpperNeighbor(cell, maze));
        }

        [TestMethod]
        public void CheckBottomNeighbor_NeighborExistsAndHasAllWalls_NeighborReturned()
        {
            Maze maze = new Maze(2);
            MazeCell cell = maze[0][1];

            Assert.IsNotNull(this.intactWallHelper.CheckBottomNeighbor(cell, maze));
        }

        [TestMethod]
        public void CheckBottomNeighbor_NeighborDoesntExists_NullReturned()
        {
            Maze maze = new Maze(2);
            MazeCell cell = maze[1][1];

            Assert.IsNull(this.intactWallHelper.CheckBottomNeighbor(cell, maze));
        }

        [TestMethod]
        public void CheckBottomNeighbor_NeighborExistsAndHasNotAllWalls_NullReturned()
        {
            Maze maze = new Maze(2);
            maze[1][0].KnockDownWall(MazeWall.Right);
            MazeCell cell = maze[0][0];

            Assert.IsNull(this.intactWallHelper.CheckBottomNeighbor(cell, maze));
        }

        [TestMethod]
        public void CheckLeftNeighbor_NeighborExistsAndHasAllWalls_NeighborReturned()
        {
            Maze maze = new Maze(2);
            MazeCell cell = maze[1][1];

            Assert.IsNotNull(this.intactWallHelper.CheckLeftNeighbor(cell, maze));
        }

        [TestMethod]
        public void CheckLeftNeighbor_NeighborDoesntExists_NullReturned()
        {
            Maze maze = new Maze(2);
            MazeCell cell = maze[0][0];

            Assert.IsNull(this.intactWallHelper.CheckLeftNeighbor(cell, maze));
        }

        [TestMethod]
        public void CheckLeftNeighbor_NeighborExistsAndHasNotAllWalls_NullReturned()
        {
            Maze maze = new Maze(2);
            maze[0][0].KnockDownWall(MazeWall.Bottom);
            MazeCell cell = maze[0][1];

            Assert.IsNull(this.intactWallHelper.CheckLeftNeighbor(cell, maze));
        }

        [TestMethod]
        public void CheckRightNeighbor_NeighborExistsAndHasAllWalls_NeighborReturned()
        {
            Maze maze = new Maze(2);
            MazeCell cell = maze[1][0];

            Assert.IsNotNull(this.intactWallHelper.CheckRightNeighbor(cell, maze));
        }

        [TestMethod]
        public void CheckRightNeighbor_NeighborDoesntExists_NullReturned()
        {
            Maze maze = new Maze(2);
            MazeCell cell = maze[0][1];

            Assert.IsNull(this.intactWallHelper.CheckRightNeighbor(cell, maze));
        }

        [TestMethod]
        public void CheckRightNeighbor_NeighborExistsAndHasNotAllWalls_NullReturned()
        {
            Maze maze = new Maze(2);
            maze[0][1].KnockDownWall(MazeWall.Top);
            MazeCell cell = maze[0][0];

            Assert.IsNull(this.intactWallHelper.CheckRightNeighbor(cell, maze));
        }
    }
}
