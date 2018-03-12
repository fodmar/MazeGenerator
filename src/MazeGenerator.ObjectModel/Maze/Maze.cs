using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MazeGenerator.ObjectModel.Utils;

namespace MazeGenerator.ObjectModel.Maze
{
    public class Maze : IEnumerable<MazeRow>
    {
        private MazeRow[] rows;

        public Maze(int rows, int cols)
        {
            this.rows = new MazeRow[rows];
            for (int i = 0; i < rows; i++)
            {
                this.rows[i] = new MazeRow(cols);
            }
        }

        public Maze(int size) : this(size, size)
        {
        }

        public MazeRow this[int number]
        {
            get
            {
                return this.rows[number];
            }
            set
            {
                this.rows[number] = value;
            }
        }

        public int Length
        {
            get
            {
                return this.rows.Length;
            }
        }

        public IEnumerator<MazeRow> GetEnumerator()
        {
            return this.rows.AsEnumerable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.rows.GetEnumerator();
        }
    }
}