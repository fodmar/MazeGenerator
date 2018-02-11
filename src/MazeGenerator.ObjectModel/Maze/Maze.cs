namespace MazeGenerator.ObjectModel.Maze
{
    public class Maze
    {
        public Maze(int size)
        {
            this.Cells = new MazeCell[size][];

            for (int i = 0; i < this.Cells.Length; i++)
            {
                this.Cells[i] = new MazeCell[size];

                for (int j = 0; j < this.Cells[i].Length; j++)
                {
                    this.Cells[i][j] = new MazeCell(i, j);
                }
            }
        }

        public MazeCell[][] Cells { get; set; }
    }
}