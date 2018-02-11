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
    }
}