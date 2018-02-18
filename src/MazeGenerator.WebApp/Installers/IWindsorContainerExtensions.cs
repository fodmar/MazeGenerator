using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace MazeGenerator.WebApp.Installers
{
    public static class IWindsorContainerExtensions
    {
        public static void RegisterType<TInterface, TConcrete>(this IWindsorContainer container)
            where TInterface : class
            where TConcrete : TInterface
        {
            container.Register(Component
                .For<TInterface>()
                .ImplementedBy<TConcrete>()
                .LifestylePerWebRequest());
        }
    }
}