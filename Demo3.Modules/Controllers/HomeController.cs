using System;
using System.Linq;
using System.Web.Mvc;
using Demo3.Modules.Models;

namespace Demo3.Modules.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BuiltInModules()
        {
            var modules = HttpContext.ApplicationInstance.Modules;
            var moduleInfoCollection = modules.AllKeys
                                              .Select(x => new ModuleInfoModel { Name = x, Type = modules[x].GetType().FullName })
                                              .OrderByDescending(x => x.Name);

            return View(moduleInfoCollection);
        }

        public ActionResult EventsList()
        {
            return View();
        }

        public ActionResult EventsListError()
        {
            throw new Exception("Testing the Error event");
        }

        public string OldAction()
        {
            return "Hello from the OldAction";
        }

        public string NewAction()
        {
            return "Hello from the NewAction";
        }

    }
}