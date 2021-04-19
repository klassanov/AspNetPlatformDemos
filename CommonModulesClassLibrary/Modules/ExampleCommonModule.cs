using System.Web;

namespace CommonModulesClassLibrary.Modules
{
    /* All common modules that are shared accross applications can be defined and registered
    * at a single place
    * 
    * In order to define a module, we need to reference System.Web
    */
    public class ExampleCommonModule : IHttpModule
    {
        public void Init(HttpApplication application)
        {
            application.EndRequest += (src, args) =>
            {
                HttpContext.Current.Response.Write("Hello from the ExampleCommonModule");
            };
        }

        public void Dispose()
        {
        }
    }
}
