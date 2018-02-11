using System.Collections.Generic;
using System.Threading.Tasks;
using MazeGenerator.ObjectModel.Maze;

namespace MazeGenerator.ObjectModel.Data
{
    public interface IMazeGraphicRepository : IRepository<MazeGraphic>
    {
        Task<IEnumerable<string>> GetNames();
        Task<MazeGraphic> GetByName(string name);
    }
}