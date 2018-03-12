using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MazeGenerator.ObjectModel.Maze
{
    public class MazeRow : IEnumerable<MazeCell>
    {
        private MazeCell[] cells;

        protected MazeRow()
        {
        }

        public MazeRow(int size)
        {
            this.cells = new MazeCell[size];
            for (int i = 0; i < size; i++)
            {
                this.cells[i] = new MazeCell();
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