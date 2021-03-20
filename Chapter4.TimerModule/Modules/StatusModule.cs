using System.Web;

namespace Chapter4.TimerModule.Modules
{
    public class StatusModule : IHttpModule
    {
        public void Init(HttpApplication application)
        {
            application.EndRequest += (src, args) =>
            {
                HttpContext.Current.Response.Write($" Response Status: {HttpContext.Current.Response.Status}");
            };
        }

        public void Dispose()
        {
            //clean-up code here.
        }
    }
}
