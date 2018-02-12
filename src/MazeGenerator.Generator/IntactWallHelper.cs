using System;
using System.Collections.Generic;
using MazeGenerator.ObjectModel.Maze;

namespace MazeGenerator.Generator
{
    class IntactWallHelper
    {
        public List<MazeCell> FindNeighborsWithAllWallIntact(MazeCell cell, Maze maze)
        {
            List<MazeCell> result = new List<MazeCell>();
            MazeCell neighbor = null;

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

        public MazeCell CheckUpperNeighbor(MazeCell cell, Maze maze)
        {
            if (cell.X > 0 &&
                maze[cell.X - 1][cell.Y].HasAllWalls)
            {
                return maze[cell.X - 1][cell.Y];
            }

            return null;
        }

        public MazeCell CheckBottomNeighbor(MazeCell cell, Maze maze)
        {
            if (cell.X + 1 < maze.Length &&
                maze[cell.X + 1][cell.Y].HasAllWalls)
            {
                return maze[cell.X + 1][cell.Y];
            }

            return null;
        }

        public MazeCell CheckLeftNeighbor(MazeCell cell, Maze maze)
        {
            if (cell.Y > 0 &&
                maze[cell.X][cell.Y - 1].HasAllWalls)
            {
                return maze[cell.X][cell.Y - 1];
            }

            return null;
        }

        public MazeCell CheckRightNeighbor(MazeCell cell, Maze maze)
        {
            if (cell.Y + 1 < maze[cell.X].Length &&
                maze[cell.X][cell.Y + 1].HasAllWalls)
            {
                return maze[cell.X][cell.Y + 1];
            }

            return null;
        }
    }
}