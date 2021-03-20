using System.Web;

namespace Chapter4.TimerModule.Modules
{
    public class StatusModule : IHttpModule
    {
        public void Init(HttpApplication application)
        {
            application.EndRequest += (src, args) =>
            {
                HttpContext.Current.Response.Write($" Status code: {HttpContext.Current.Response.Status}");
            };
        }

        public void Dispose()
        {
            //clean-up code here.
        }
    }
}
