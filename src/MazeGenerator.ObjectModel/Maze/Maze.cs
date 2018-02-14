using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MazeGenerator.ObjectModel.Utils;

namespace MazeGenerator.ObjectModel.Maze
{
    public class Maze : IEnumerable<MazeCell[]>
    {
        private MazeCell[][] cells;

        public Maze(int rows, int cols)
        {
            this.cells = ArrayUtils.Create(rows, cols, (x, y) => new MazeCell(x, y));
        }

        public Maze(int size) : this(size, size)
        {
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

        public IEnumerator<MazeCell[]> GetEnumerator()
        {
            return this.cells.AsEnumerable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.cells.GetEnumerator();
        }
    }
}