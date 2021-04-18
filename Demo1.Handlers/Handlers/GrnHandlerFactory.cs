using System.Web;

namespace Demo1.Handlers.Handlers
{
    public class GrnHandlerFactory : IHttpHandlerFactory
    {
        public IHttpHandler GetHandler(HttpContext context, string requestType, string url, string pathTranslated)
        {
            if (context.Request.UserAgent.Contains("Chrome"))
            {
                return new ChromeGrnHandler();
            }
            else
            {
                return new DefaultGrnHandler();
            }
        }

        public void ReleaseHandler(IHttpHandler handler)
        {
            //Do nothing: handlers are not reused
        }
    }
}