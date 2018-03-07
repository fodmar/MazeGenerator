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
        private const float sizeX = 500f;
        private const float sizeY = 500f;
        private const float marginX = 10f;
        private const float marginY = 10f;

        public MazeGraphic Paint(Maze maze, MazeGenerationOptions options)
        {
            using (Bitmap bitmap = new Bitmap((int)(sizeX + 2 * marginX), (int)(sizeY + 2 * marginY)))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    this.DrawMaze(maze, graphics, sizeX / maze[0].Length, sizeY / maze.Length);

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

        private void DrawMaze(Maze maze, Graphics graphics, float width, float height)
        {
            Pen pen = new Pen(Color.White, 2);

            float currentPositionX = marginX;
            float currentPositionY = marginY;

            for (int i = 0; i < maze.Length; i++)
            {
                currentPositionX = marginX;

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

                    currentPositionX += width;
                }

                currentPositionY += height;
            }
        }
    }
}