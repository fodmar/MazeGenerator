using System.Web.Configuration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MazeGenerator.Generator;
using MazeGenerator.ObjectModel.Maze;
using MazeGenerator.ObjectModel.Persistence;
using MazeGenerator.ObjectModel.Utils;
using MazeGenerator.Persistence.File;

namespace MazeGenerator.WebApp.Installers
{
    public class MazeAppInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.RegisterType<IRandom, Random>();
            container.RegisterType<IMazeGenerator, DepthFirstMazeGenerator>();

            container.Register(Component
                .For<IMazeGraphicRepository>()
                .ImplementedBy<MazeGraphicRepository>()
                .DependsOn(Dependency.OnValue("basePath", WebConfigurationManager.AppSettings.Get("mazeImagesDirectory"))));
        }
    }
}