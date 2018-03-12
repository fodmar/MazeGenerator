using Microsoft.VisualStudio.TestTools.UnitTesting;
using MazeObject = MazeGenerator.ObjectModel.Maze.Maze;

namespace MazeGenerator.ObjectModel.Tests
{
    [TestClass]
    class MazeTests
    {
        [TestMethod]
        public void IndexerShouldNotThrowException()
        {
            MazeObject maze = new MazeObject(5);

            for (int i = -10; i < 10; i++)
            {
                for (int j = -10; j < 10; j++)
                {
                    var dummy = maze[i][j];
                }
            }
        }
    }
}