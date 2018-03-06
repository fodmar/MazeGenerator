using System;
using MazeGenerator.ObjectModel;
using MazeGenerator.ObjectModel.Maze;
using MazeGenerator.ObjectModel.Utils;

namespace MazeGenerator.Generator
{
    class WallKnocker
    {
        public void KnockDownWallBetweenNeighbors(NeighborMazeCell neighborMazeCell)
        {
            switch (neighborMazeCell.CellWall)
            {
                case MazeWall.Top:
                    neighborMazeCell.Cell.KnockDownWall(MazeWall.Top);
                    neighborMazeCell.Neighbor.KnockDownWall(MazeWall.Bottom);
                    break;

                case MazeWall.Bottom:
                    neighborMazeCell.Cell.KnockDownWall(MazeWall.Bottom);
                    neighborMazeCell.Neighbor.KnockDownWall(MazeWall.Top);
                    break;

                case MazeWall.Left:
                    neighborMazeCell.Cell.KnockDownWall(MazeWall.Left);
                    neighborMazeCell.Neighbor.KnockDownWall(MazeWall.Right);
                    break;

                case MazeWall.Right:
                    neighborMazeCell.Cell.KnockDownWall(MazeWall.Right);
                    neighborMazeCell.Neighbor.KnockDownWall(MazeWall.Left);
                    break;
            }
        }

        public void CreateEntrance(Maze maze, IRandom random)
        {
            maze[0][random.Next(maze[0].Length)].KnockDownWall(MazeWall.Top);
        }

        public void CreateExit(Maze maze, IRandom random)
        {
            int lastIndex = maze.Length - 1;
            maze[lastIndex][random.Next(maze[lastIndex].Length)].KnockDownWall(MazeWall.Bottom);
        }
    }
}