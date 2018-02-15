using System.Collections.Generic;
using System.Threading.Tasks;
using MazeGenerator.ObjectModel.Data;
using MazeGenerator.ObjectModel.Maze;

namespace MazeGenerator.Persistence.FileSystem
{
    public class FileSystemRepository : IMazeGraphicRepository
    {
        public Task<IEnumerable<string>> GetNames()
        {
            throw new System.NotImplementedException();
        }

        public Task<MazeGraphic> GetByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public Task<MazeGraphic> Create(MazeGraphic item)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<MazeGraphic>> Read()
        {
            throw new System.NotImplementedException();
        }

        public Task<MazeGraphic> Update(MazeGraphic item)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(MazeGraphic item)
        {
            throw new System.NotImplementedException();
        }
    }
}
