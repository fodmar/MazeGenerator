using System;
using MazeGenerator.ObjectModel.Maze;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MazeGenerator.ObjectModel.Tests
{
    [TestClass]
    public class MazeRowTests
    {
        [TestMethod]
        public void IndexerShouldNotThrowException()
        {
            MazeRow row = new MazeRow(5);

            for (int i = -10; i < 10; i++)
            {
                var dummy = row[i];
            }
        }
    }
}
