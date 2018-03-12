namespace MazeGenerator.ObjectModel.Maze
{
    public class MazeCell
    {
        private MazeWall walls;

        public MazeCell()
        {
            this.walls = MazeWall.Top | MazeWall.Bottom | MazeWall.Left | MazeWall.Right;
        }

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