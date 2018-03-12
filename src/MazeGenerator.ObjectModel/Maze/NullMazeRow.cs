namespace MazeGenerator.ObjectModel.Maze
{
    public class NullMazeRow : MazeRow
    {
        public static readonly MazeRow Instance = new NullMazeRow();

        public override int Length
        {
            get
            {
                return 0;
            }
        }

        public override MazeCell this[int index]
        {
            get
            {
                return NullMazeCell.Instance;
            }
        } 
    }
}