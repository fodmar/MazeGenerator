using System;
using System.Collections.Generic;
using MazeGenerator.ObjectModel.Maze;

namespace MazeGenerator.Generator
{
    class NeighborFinder
    {
        public List<NeighborMazeCell> FindNeighborsWithAllWalls(MazeCell cell, Maze maze)
        {
            List<NeighborMazeCell> result = new List<NeighborMazeCell>();
            NeighborMazeCell neighbor = null;

            neighbor = this.CheckUpperNeighbor(cell, maze);
            if (neighbor != null)
            {
                result.Add(neighbor);
            }

            neighbor = this.CheckBottomNeighbor(cell, maze);
            if (neighbor != null)
            {
                result.Add(neighbor);
            }

            neighbor = this.CheckLeftNeighbor(cell, maze);
            if (neighbor != null)
            {
                result.Add(neighbor);
            }

            neighbor = this.CheckRightNeighbor(cell, maze);
            if (neighbor != null)
            {
                result.Add(neighbor);
            }

            return result;
        }

        public NeighborMazeCell CheckUpperNeighbor(MazeCell cell, Maze maze)
        {
            if (cell.X > 0 &&
                maze[cell.X - 1][cell.Y].HasAllWalls)
            {
                return new NeighborMazeCell(cell, maze[cell.X - 1][cell.Y], Neighbor.Upper);
            }

            return null;
        }

        public NeighborMazeCell CheckBottomNeighbor(MazeCell cell, Maze maze)
        {
            if (cell.X + 1 < maze.Length &&
                maze[cell.X + 1][cell.Y].HasAllWalls)
            {
                return new NeighborMazeCell(cell, maze[cell.X + 1][cell.Y], Neighbor.Bottom);
            }

            return null;
        }

        public NeighborMazeCell CheckLeftNeighbor(MazeCell cell, Maze maze)
        {
            if (cell.Y > 0 &&
                maze[cell.X][cell.Y - 1].HasAllWalls)
            {
                return new NeighborMazeCell(cell, maze[cell.X][cell.Y - 1], Neighbor.Left);
            }

            return null;
        }

        public NeighborMazeCell CheckRightNeighbor(MazeCell cell, Maze maze)
        {
            if (cell.Y + 1 < maze[cell.X].Length &&
                maze[cell.X][cell.Y + 1].HasAllWalls)
            {
                return new NeighborMazeCell(cell, maze[cell.X][cell.Y + 1], Neighbor.Right);
            }

            return null;
        }
    }
}