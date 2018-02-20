using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using MazeGenerator.ObjectModel.Maze;
using MazeGenerator.ObjectModel.Utils;

namespace MazeGenerator.Painter
{
    public class ImageMazePainter : IMazePainter
    {
        public MazeGraphic Paint(Maze maze)
        {
            using (Bitmap bitmap = new Bitmap(100, 100))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.Clear(Color.AliceBlue);

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
    }
}