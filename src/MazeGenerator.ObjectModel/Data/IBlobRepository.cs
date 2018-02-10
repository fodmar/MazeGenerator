using System.Collections.Generic;
using System.Threading.Tasks;

namespace MazeGenerator.ObjectModel
{
    public interface IBlobRepository : IRepository<Blob>
    {
        Task<IEnumerable<string>> GetNames();
        Task<Blob> GetByName(string name);
    }
}
