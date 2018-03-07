using System.Threading.Tasks;
using System.Web.Mvc;
using MazeGenerator.ObjectModel.Maze;
using MazeGenerator.ObjectModel.Persistence;

namespace MazeGenerator.WebApp.Controllers
{
    public class MazeController : Controller
    {
        private readonly IMazeGenerator mazeGenerator;
        private readonly IMazeGraphicRepository mazeGraphicRepository;
        private readonly IMazePainter painter;

        public MazeController(
            IMazeGenerator mazeGenerator,
            IMazePainter painter,
            IMazeGraphicRepository mazeGraphicRepository)
        {
            this.mazeGenerator = mazeGenerator;
            this.mazeGraphicRepository = mazeGraphicRepository;
            this.painter = painter;
        }

        public ActionResult Index()
        {
            return View();
        }

        [OutputCache(NoStore = true, Duration = 0)]
        public async Task<ActionResult> Generate(MazeGenerationOptions options)
        {
            Maze maze = this.mazeGenerator.Generate(options);
            MazeGraphic graphic = this.painter.Paint(maze, options);

            await this.mazeGraphicRepository.Create(graphic);

            return this.File(graphic.Content, "image/jpeg");
        }
    }
}