namespace MazeGenerator.ObjectModel.Maze
{
    public class NullMazeColumn : MazeColumn
    {
        public static readonly MazeColumn Instance = new NullMazeColumn();

        private NullMazeColumn()
        {
        }

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