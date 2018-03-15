using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MazeGenerator.ObjectModel.Maze
{
    public class MazeColumn : IEnumerable<MazeCell>
    {
        private MazeCell[] cells;

        protected MazeColumn()
        {
        }

        public MazeColumn(int size) : this(size, 0)
        {
        }

        public MazeColumn(int size, int x)
        {
            this.cells = new MazeCell[size];
            for (int y = 0; y < size; y++)
            {
                this.cells[y] = new MazeCell(x, y);
            }
        }

        public virtual int Length
        {
            get
            {
                return this.cells.Length;
            }
        }

        public virtual MazeCell this[int index]
        {
            get
            {
                if (index < 0 || index >= this.cells.Length)
                {
                    return NullMazeCell.Instance;
                }

                return this.cells[index];
            }
        }

        public IEnumerator<MazeCell> GetEnumerator()
        {
            return this.cells.AsEnumerable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.cells.GetEnumerator();
        }
    }
}