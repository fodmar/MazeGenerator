namespace MazeGenerator.ObjectModel.Maze
{
    public class MazeCell
    {
        private MazeWall walls;

        public MazeCell(int x, int y)
        {
            this.walls = MazeWall.Top | MazeWall.Bottom | MazeWall.Left | MazeWall.Right;
            this.X = x;
            this.Y = y;
        }

        public int X { get; private set; }
        public int Y { get; private set; }

        public virtual bool HasAllWalls
        {
            get
            {
                return this.walls.HasFlag(MazeWall.Top | MazeWall.Bottom | MazeWall.Left | MazeWall.Right);
            }
        }

        public virtual void KnockDownWall(MazeWall wall)
        {
            this.walls &= ~wall;
        }

        public virtual bool HasWall(MazeWall walls)
        {
            return this.walls.HasFlag(walls);
        }
    }
}