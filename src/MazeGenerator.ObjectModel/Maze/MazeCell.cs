using System.Collections.Generic;

namespace MazeGenerator.ObjectModel
{
    public class MazeCell
    {
        public MazeCell(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.Walls = new List<MazeWall>();
        }

        public int X { get; private set; }
        public int Y { get; private set; }
        public List<MazeWall> Walls { get; set; }
    }
}
