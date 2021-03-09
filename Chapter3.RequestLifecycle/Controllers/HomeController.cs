using System.Web.Mvc;
using Chapter3.RequestLifecycle.Infrastructure;

namespace Chapter3.RequestLifecycle.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(HttpContext.Application[Constants.Events]);
        }
    }
}