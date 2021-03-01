using System.Web.Mvc;

namespace Chapter3.ApplicationLifecycle.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Hello, folks!";
        }
    }
}