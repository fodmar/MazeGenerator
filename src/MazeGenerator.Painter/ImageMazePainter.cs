using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using MazeGenerator.ObjectModel;
using MazeGenerator.ObjectModel.Maze;
using MazeGenerator.ObjectModel.Utils;

namespace MazeGenerator.Painter
{
    public class ImageMazePainter : IMazePainter
    {
        public MazeGraphic Paint(Maze maze, MazeGenerationOptions options)
        {
            ImageSizesHelper helper = new ImageSizesHelper();
            ImageSizes sizes = helper.CalculateSizes(maze, options);

            using (Bitmap bitmap = new Bitmap(sizes.Width, sizes.Height))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    this.DrawMaze(maze, graphics, sizes);

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        bitmap.Save(memoryStream, ImageFormat.Jpeg);

                        return new MazeGraphic
                        {
                            Name = Guid.NewGuid().ToString(GuidFormats.Digits),
                            GraphicType = "image",
                            Content = memoryStream.ToArray()
                        };
                    }
                }
            }
        }

        private void DrawMaze(Maze maze, Graphics graphics, ImageSizes sizes)
        {
            Pen pen = new Pen(Color.White, 2);

            float currentPositionX = sizes.MarginX;
            float currentPositionY = sizes.MarginY;
            float width = sizes.CellWidth;
            float height = sizes.CellHeight;

            for (int i = 0; i < maze.Length; i++)
            {
                currentPositionX = sizes.MarginX;

                for (int j = 0; j < maze[i].Length; j++)
                {
                    MazeCell currentCell = maze[i][j];

                    if (currentCell.HasWall(MazeWall.Top))
                    {
                        graphics.DrawLine(pen, currentPositionX, currentPositionY, currentPositionX + width, currentPositionY);
                    }

                    if (currentCell.HasWall(MazeWall.Right))
                    {
                        graphics.DrawLine(pen, currentPositionX + width, currentPositionY, currentPositionX + width, currentPositionY + height);
                    }

                    if (currentCell.HasWall(MazeWall.Bottom))
                    {
                        graphics.DrawLine(pen, currentPositionX + width, currentPositionY + height, currentPositionX, currentPositionY + height);
                    }

                    if (currentCell.HasWall(MazeWall.Left))
                    {
                        graphics.DrawLine(pen, currentPositionX, currentPositionY + height, currentPositionX, currentPositionY);
                    }

                    currentPositionX += sizes.CellWidth;
                }

                currentPositionY += sizes.CellHeight;
            }
        }
    }
}