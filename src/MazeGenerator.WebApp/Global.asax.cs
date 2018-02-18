﻿using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MazeGenerator.WebApp
{
    public class MazeGeneratorWebApp : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        public static string GetMazeImagesDirectory()
        {
            return HttpContext.Current.Server.MapPath("~/mazes");
        }
    }
}