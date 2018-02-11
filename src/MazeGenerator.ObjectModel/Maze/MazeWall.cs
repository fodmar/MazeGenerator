using System;

namespace MazeGenerator.ObjectModel
{
    [Flags]
    public enum MazeWall
    {
        Top = 1,
        Right = 2,
        Left = 4,
        Bottom = 8,
    }
}