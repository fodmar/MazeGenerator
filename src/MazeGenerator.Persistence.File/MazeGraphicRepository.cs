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

        private readonly ExtensionPicker extensionPicker;

        public MazeGraphicRepository(string basePath)
        {
            this.basePath = basePath;

            this.extensionPicker = new ExtensionPicker();
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

            return this.ReadMazeGraphicFromFile(fullPath);
        }

        public async Task<MazeGraphic> Create(MazeGraphic item)
        {
            string fullPath = string.Format("{0}/{1}.{2}",
                this.basePath,
                item.Name,
                this.extensionPicker.GetExtensionByType(item.GraphicType));

            using (FileStream file = new FileStream(fullPath, FileMode.CreateNew, FileAccess.Write, FileShare.None))
            {
                await file.WriteAsync(item.Content, 0, item.Content.Length);
            }

            return item;
        }

        public Task<IEnumerable<MazeGraphic>> Read()
        {
            return Task.FromResult(Directory
                .EnumerateFiles(this.basePath)
                .Select(async p => await ReadMazeGraphicFromFile(p))
                .Select(t => t.Result));
        }

        public async Task<MazeGraphic> Update(MazeGraphic item)
        {
            string fullPath = this.FindFullPathByName(item.Name);

            if (string.IsNullOrEmpty(fullPath))
            {
                return null;
            }

            using (FileStream fileStream = new FileStream(fullPath, FileMode.Truncate, FileAccess.Write, FileShare.None))
            {
                await fileStream.WriteAsync(item.Content, 0, item.Content.Length);
            }

            return item;
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

        private async Task<MazeGraphic> ReadMazeGraphicFromFile(string fullPath)
        {
            using (FileStream fileStream = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    Task copyTask = fileStream.CopyToAsync(memoryStream);
                    string extension = Path.GetExtension(fullPath);
                    string name = Path.GetFileNameWithoutExtension(fullPath);

                    await copyTask;

                    return new MazeGraphic
                    {
                        Name = name,
                        GraphicType = this.extensionPicker.GetTypeByExtension(extension),
                        Content = memoryStream.ToArray()
                    };
                }
            }
        }
    }
}