using System.Web.Mvc;

namespace Demo1.Handlers.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "<h1>Hello from the Index Action Method</h1>";
        }
    }
}