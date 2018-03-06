using MazeGenerator.ObjectModel.Maze;
using MazeGenerator.ObjectModel.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System.Linq;
using MazeGenerator.ObjectModel;

namespace MazeGenerator.Generator.UnitTests
{
    [TestClass]
    public class DepthFirstMazeGeneratorTests
    {
        [TestMethod]
        [Timeout(1000)]
        public void Generate()
        {
            IRandom random = MockRepository.GenerateMock<IRandom>();
            random.Stub(r => r.Next(Arg<int>.Is.Anything)).Return(0);

            IMazeGenerator generator = new DepthFirstMazeGenerator(random);

            Maze maze = generator.Generate(3);

            Assert.AreEqual(3, maze.Length);
            Assert.IsTrue(maze.All(m => m.Length == 3));
            
            Assert.IsTrue(maze[0][0].HasWall(MazeWall.Left | MazeWall.Right));
            Assert.IsTrue(maze[1][0].HasWall(MazeWall.Left | MazeWall.Right));
            Assert.IsTrue(maze[2][0].HasWall(MazeWall.Left));

            Assert.IsTrue(maze[2][1].HasWall(MazeWall.Bottom | MazeWall.Right));
            Assert.IsTrue(maze[1][1].HasWall(MazeWall.Left | MazeWall.Right));
            Assert.IsTrue(maze[0][1].HasWall(MazeWall.Top | MazeWall.Left));

            Assert.IsTrue(maze[0][2].HasWall(MazeWall.Top | MazeWall.Right));
            Assert.IsTrue(maze[1][2].HasWall(MazeWall.Left | MazeWall.Right));
            Assert.IsTrue(maze[2][2].HasWall(MazeWall.Bottom | MazeWall.Right | MazeWall.Left));
        }
    }
}