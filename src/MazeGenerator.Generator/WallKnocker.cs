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
            int maxX = maze.Length;

            int x = random.Next(maxX);
            int y = 0;

            maze[0][0].KnockDownWall(MazeWall.Bottom);
        }

        public void CreateExit(Maze maze, IRandom random)
        {
            int maxX = maze.Length;
            int maxY = maze[0].Length;

            int x = random.Next(maxX);
            int y = maxY;

            maze[x][y].KnockDownWall(MazeWall.Top);
        }
    }
}