using System.Web;

namespace Demo3.Modules.Modules
{
    public class RedirectModule : IHttpModule
    {
        /* If the ONLY thing that an action method does is issuing a redirection,
         * then it becomes an expensive operation. 
         * We can "short circuit" the request processing and optimize it. 
         * 
         * By doing the redirection at the beginning of the request processing,
         * compared to doing it in an action method, we do not execute the following
         * expensive steps:
         * 
         * Locating and instantiating the controller factory
         * Locating and instantiating the controller activator
         * Locating and isntantiating the action invoker
         * Identifying the action method
         * Examining the action method for filter attributes
         * Invoking the action method
         * Invoking the RedirectToActionMethod
         */

        public void Init(HttpApplication application)
        {
            application.BeginRequest += (src, args) =>
            {
                if (HttpContext.Current.Request.RawUrl.ToLower().Contains("/home/oldaction"))
                {
                    application.Context.Response.Redirect("/home/newaction");
                }
            };
        }

        public void Dispose()
        {
        }
    }
}