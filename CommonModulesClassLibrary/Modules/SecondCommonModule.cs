using System.Web;

namespace CommonModulesClassLibrary.Modules
{
    public class SecondCommonModule : IHttpModule
    {
        public void Init(HttpApplication application)
        {
            application.EndRequest += (src, args) =>
            {
                HttpContext.Current.Response.Write("Hello from the SecondCommonModule <br/>");
            };
        }

        public void Dispose()
        {
        }
    }
}
