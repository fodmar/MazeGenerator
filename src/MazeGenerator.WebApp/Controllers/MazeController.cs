using System.Web.Mvc;
using MazeGenerator.ObjectModel.Maze;
using MazeGenerator.ObjectModel.Persistence;

namespace MazeGenerator.WebApp.Controllers
{
    public class MazeController : Controller
    {
        private readonly IMazeGenerator mazeGenerator;
        private readonly IMazeGraphicRepository mazeGraphicRepository;

        public MazeController(
            IMazeGenerator mazeGenerator,
            IMazeGraphicRepository mazeGraphicRepository)
        {
            this.mazeGenerator = mazeGenerator;
            this.mazeGraphicRepository = mazeGraphicRepository;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}