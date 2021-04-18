using System.Web;

namespace Demo1.Handlers.Handlers
{
    public class DefaultGrnHandler : IHttpHandler
    {
        public bool IsReusable => false;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            context.Response.Write("<h1>Hello from the DefaultGrnHandler</h1>");
        }
    }
}