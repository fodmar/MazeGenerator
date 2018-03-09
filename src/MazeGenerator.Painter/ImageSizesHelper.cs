using MazeGenerator.ObjectModel.Maze;

namespace MazeGenerator.Painter
{
    class ImageSizesHelper
    {
        private const int sizeX = 500;
        private const int sizeY = 500;
        private const int marginX = 10;
        private const int marginY = 10;

        public ImageSizes CalculateSizes(Maze maze, MazeGenerationOptions options)
        {
            ImageSizes result = new ImageSizes();

            if (options.FixedSize)
            {
                result.Width = (int)(sizeX + 2 * marginX);
                result.Height = (int)(sizeY + 2 * marginY);
                result.CellWidth = (int)(sizeX / maze[0].Length);
                result.CellHeight = (int)(sizeY / maze.Length);
            }
            else
            {
                result.CellWidth = 25;
                result.CellHeight = 25;
                result.Width = (int)(marginX * 2 + result.CellWidth * maze[0].Length);
                result.Height = (int)(marginY * 2 + result.CellHeight * maze.Length);
            }

            result.MarginX = marginX;
            result.MarginY = marginY;

            return result;
        }
    }
}