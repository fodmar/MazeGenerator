namespace MazeGenerator.ObjectModel.Maze
{
    public class MazeGenerationOptions
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public bool FixedSize { get; set; }
        public bool Gaps { get; set; }
    }
}