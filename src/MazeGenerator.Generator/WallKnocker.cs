using System;
using MazeGenerator.ObjectModel;
using MazeGenerator.ObjectModel.Maze;

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
    }
}