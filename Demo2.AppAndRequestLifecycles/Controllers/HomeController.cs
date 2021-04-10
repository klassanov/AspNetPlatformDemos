using System.Web.Mvc;

namespace Demo2.AppAndRequestLifecycles.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Hello form the Index method";
        }

        public ActionResult Events()
        {
            return View(HttpContext.Application[Constants.Events]);
        }
    }
}