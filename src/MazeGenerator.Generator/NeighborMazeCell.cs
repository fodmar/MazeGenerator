using MazeGenerator.ObjectModel.Maze;

namespace MazeGenerator.Generator
{
    class NeighborMazeCell
    {
        public NeighborMazeCell(MazeCell cell, MazeCell neighbor, Neighbor neighborType)
        {
            this.Cell = cell;
            this.Neighbor = neighbor;
            this.NeighborType = neighborType;
        }

        public Neighbor NeighborType { get; set; }
        public MazeCell Cell { get; set; }
        public MazeCell Neighbor { get; set; }
    }
}