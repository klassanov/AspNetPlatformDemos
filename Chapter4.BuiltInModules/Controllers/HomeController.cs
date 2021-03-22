using System.Linq;
using System.Web.Mvc;
using Chapter4.BuiltInModules.Models;

namespace Chapter4.BuiltInModules.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var modules = HttpContext.ApplicationInstance.Modules;
            var moduleInfoCollection = modules.AllKeys
                                              .Select(x => new ModuleInfo { Name = x, Type = modules[x].GetType().FullName })
                                              .OrderByDescending(x => x.Name);

            return View(moduleInfoCollection);
        }
    }
}