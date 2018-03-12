namespace MazeGenerator.ObjectModel.Maze
{
    public class NullMazeCell : MazeCell
    {
        public static readonly NullMazeCell Instance = new NullMazeCell();

        public override bool HasAllWalls
        {
            get
            {
                return false;
            }
        }

        public override bool HasWall(MazeWall walls)
        {
            return false;
        }

        public override void KnockDownWall(MazeWall wall)
        {
        }
    }
}