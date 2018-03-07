namespace MazeGenerator.ObjectModel.Maze
{
    public interface IMazePainter
    {
        MazeGraphic Paint(Maze maze, MazeGenerationOptions options);
    }
}