using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MazeGenerator.ObjectModel.Maze;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MazeGenerator.Persistence.File.IntegrationTests
{
    [TestClass]
    public class MazeGraphicRepositoryTests
    {
        private const string basePath = @"D:\mazes";
        private MazeGraphicRepository repository = new MazeGraphicRepository(basePath);

        [TestMethod]
        [Ignore]
        public async Task GetNames()
        {
            List<string> names = (await this.repository.GetNames()).ToList();

            Assert.AreEqual(2, names.Count);
            Assert.IsTrue(names.All(n => n == "1" || n == "2"));
        }

        [TestMethod]
        [Ignore]
        public async Task GetByName()
        {
            string name = "1";

            MazeGraphic mazeGraphic = await this.repository.GetByName(name);

            Assert.IsNotNull(mazeGraphic);
            Assert.AreEqual(0, mazeGraphic.Content.Length);
            Assert.AreEqual(name, mazeGraphic.Name);
        }

        [TestMethod]
        [Ignore]
        public async Task Delete()
        {
            string name = "test";

            await this.repository.Delete(new MazeGraphic
            {
                Name = name
            });
        }

        [TestMethod]
        [Ignore]
        public async Task Create()
        {
            MazeGraphic graphic = new MazeGraphic
            {
                Content = Enumerable.Range(0, 100).Select(Convert.ToByte).ToArray(),
                Name = "test",
                GraphicType = "123"
            };

            await this.repository.Create(graphic);
        }

        [TestMethod]
        [Ignore]
        public async Task Read()
        {
            var graphics = (await this.repository.Read()).ToArray();
        }

        [TestMethod]
        [Ignore]
        public async Task Update()
        {
            MazeGraphic graphic = new MazeGraphic
            {
                Content = Enumerable.Range(0, 50).Select(Convert.ToByte).ToArray(),
                Name = "test",
                GraphicType = "123"
            };

            await this.repository.Update(graphic);
        }
    }
}
