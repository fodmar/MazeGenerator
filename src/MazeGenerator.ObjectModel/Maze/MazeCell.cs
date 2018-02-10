using System.Collections.Generic;

namespace MazeGenerator.ObjectModel
{
    public class MazeCell
    {
        public MazeCell(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.Walls = MazeWall.Top | MazeWall.Bottom | MazeWall.Left | MazeWall.Right;
        }

        public int X { get; private set; }
        public int Y { get; private set; }
        public MazeWall Walls { get; set; }
    }
}
