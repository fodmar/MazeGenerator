namespace MazeGenerator.ObjectModel.Maze
{
    public class MazeGraphic
    {
        public MazeGraphic(string name, string graphicType, byte[] content)
        {
            this.Name = name;
            this.GraphicType = graphicType;
            this.Content = content;
        }

        public string Name { get; private set; }
        public string GraphicType { get; private set; }
        public byte[] Content { get; set; }
    }
}