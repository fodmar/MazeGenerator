using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MazeGenerator.ObjectModel.Data;
using MazeGenerator.ObjectModel.Maze;

namespace MazeGenerator.Persistence.File
{
    public class MazeGraphicRepository : IMazeGraphicRepository
    {
        private readonly string basePath;

        public MazeGraphicRepository(string basePath)
        {
            this.basePath = basePath;
        }

        public Task<IEnumerable<string>> GetNames()
        {
            IEnumerable<string> names = Directory.EnumerateFiles(this.basePath).Select(Path.GetFileNameWithoutExtension);
            return Task<IEnumerable<string>>.FromResult(names);
        }

        public Task<MazeGraphic> GetByName(string name)
        {
            string fullPath = this.FindFullPathByName(name);

            if (string.IsNullOrEmpty(fullPath))
            {
                return Task.FromResult<MazeGraphic>(null);
            }

            return this.ReadMazeGraphicFromFile(name, fullPath);
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
            string fullPath = this.FindFullPathByName(item.Name);

            if (!string.IsNullOrEmpty(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }

            return Task.FromResult(true);
        }

        private string FindFullPathByName(string name)
        {
            return Directory
                .EnumerateFiles(this.basePath)
                .Where(n => Path.GetFileNameWithoutExtension(n) == name)
                .SingleOrDefault();
        }

        private async Task<MazeGraphic> ReadMazeGraphicFromFile(string name, string fullPath)
        {
            using (FileStream fileStream = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    await fileStream.CopyToAsync(memoryStream);

                    return new MazeGraphic
                    {
                        Name = name,
                        GraphicType = Path.GetExtension(fullPath),
                        Content = memoryStream.ToArray()
                    };
                }
            }
        }
    }
}
