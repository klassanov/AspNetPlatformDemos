using System.Web;

namespace Chapter4.ModulesClassLibrary.Modules
{
    /* All common modules that are shared accross applications can be defined and registered
     * at a single place
     * 
     * In order to define a module, we need to reference System.Web
     */
    public class TestModule : IHttpModule
    {
        public void Init(HttpApplication application)
        {
            application.EndRequest += (src, args) =>
              {
                  HttpContext.Current.Response.Write("Hello from the TestModule");
              };
        }

        public void Dispose()
        {
        }
    }
}
