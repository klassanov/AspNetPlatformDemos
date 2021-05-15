using System.Web;

namespace CommonModulesClassLibrary.Modules
{
    public class ThirdCommonModule : IHttpModule
    {
        public void Init(HttpApplication application)
        {
            application.EndRequest += (src, args) =>
            {
                HttpContext.Current.Response.Write("Hello from the ThirdCommonModule <br/>");
            };
        }

        public void Dispose()
        {
        }
    }
}
