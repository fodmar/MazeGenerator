using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MazeGenerator.ObjectModel.Utils;

namespace MazeGenerator.ObjectModel.Maze
{
    public class Maze : IEnumerable<MazeColumn>
    {
        private MazeColumn[] columns;

        public Maze(int rows, int cols)
        {
            this.columns = new MazeColumn[cols];
            for (int x = 0; x < cols; x++)
            {
                this.columns[x] = new MazeColumn(rows, x);
            }
        }

        public Maze(int size) : this(size, size)
        {
        }

        public MazeColumn this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Length)
                {
                    return NullMazeColumn.Instance;
                }

                return this.columns[index];
            }
        }

        public int Length
        {
            get
            {
                return this.columns.Length;
            }
        }

        public IEnumerator<MazeColumn> GetEnumerator()
        {
            return this.columns.AsEnumerable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.columns.GetEnumerator();
        }
    }
}