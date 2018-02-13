using MazeGenerator.ObjectModel;
using MazeGenerator.ObjectModel.Maze;

namespace MazeGenerator.Generator
{
    class NeighborMazeCell
    {
        public NeighborMazeCell(MazeCell cell, MazeCell neighbor, MazeWall cellWall)
        {
            this.Cell = cell;
            this.Neighbor = neighbor;
            this.CellWall = cellWall;
        }

        public MazeCell Cell { get; set; }
        public MazeCell Neighbor { get; set; }
        public MazeWall CellWall { get; set; }
    }
}