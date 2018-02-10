using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGenerator.ObjectModel
{
    public interface IRepository<T>
    {
        Task<T> Create(T item);
        Task<IEnumerable<T>> Read();
        Task<T> Update(T item);
        Task Delete(T item);
    }
}
