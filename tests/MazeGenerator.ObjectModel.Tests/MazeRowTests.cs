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
            MazeColumn row = new MazeColumn(5);

            for (int i = -10; i < 10; i++)
            {
                var dummy = row[i];
            }
        }
    }
}
