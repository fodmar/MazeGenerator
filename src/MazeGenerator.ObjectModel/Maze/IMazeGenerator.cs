﻿namespace MazeGenerator.ObjectModel.Maze
{
    public interface IMazeGenerator
    {
        Maze Generate(MazeGenerationOptions options);
    }
}