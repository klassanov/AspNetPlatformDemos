using System.Web.Mvc;

namespace Chapter4.BuiltInModules.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var modules = HttpContext.ApplicationInstance.Modules;

            return View();
        }
    }
}