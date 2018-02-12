namespace MazeGenerator.ObjectModel.Maze
{
    public class Maze
    {
        private MazeCell[][] cells { get; set; }

        public Maze(int size)
        {
            this.cells = new MazeCell[size][];

            for (int i = 0; i < this.cells.Length; i++)
            {
                this.cells[i] = new MazeCell[size];

                for (int j = 0; j < this.cells[i].Length; j++)
                {
                    this.cells[i][j] = new MazeCell(i, j);
                }
            }
        }

        public MazeCell[] this[int number]
        {
            get
            {
                return this.cells[number];
            }
            set
            {
                this.cells[number] = value;
            }
        }

        public int Length
        {
            get
            {
                return this.cells.Length;
            }
        }
    }
}