using System;
using System.Collections.Generic;
using System.Linq;
using MazeGenerator.ObjectModel;
using MazeGenerator.ObjectModel.Maze;

namespace MazeGenerator.Generator
{
    class NeighborFinder
    {
        public List<NeighborMazeCell> FindNeighborsWithAllWalls(MazeCell cell, Maze maze)
        {
            return new List<NeighborMazeCell>
            {
                new NeighborMazeCell(cell, maze[cell.X][cell.Y - 1], MazeWall.Bottom),
                new NeighborMazeCell(cell, maze[cell.X][cell.Y + 1], MazeWall.Top),
                new NeighborMazeCell(cell, maze[cell.X - 1][cell.Y], MazeWall.Left),
                new NeighborMazeCell(cell, maze[cell.X + 1][cell.Y], MazeWall.Right),
            }
            .FindAll(n => n.Neighbor.HasAllWalls);
        }
    }
}