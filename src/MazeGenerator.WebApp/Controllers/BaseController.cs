using System.Diagnostics;
using System.Web.Mvc;
using MazeGenerator.ObjectModel.Utils;

namespace MazeGenerator.WebApp.Controllers
{
    public abstract class BaseController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
            {
                base.OnException(filterContext);
            }

            base.OnException(filterContext);
        }
    }
}