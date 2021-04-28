using System.Web.Mvc;

namespace Demo4.TracingRequests.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Session["testSessionKey"] = "TestSessionKey";

            HttpContext.Trace.Warn("Home controller", "Hello from the Index method. This is a custom trace WARNING message");
            HttpContext.Trace.Write("My custom category", "Hello again");
            HttpContext.Trace.Write("HomeController", "Example Exception", new System.Exception("test exception"));
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}