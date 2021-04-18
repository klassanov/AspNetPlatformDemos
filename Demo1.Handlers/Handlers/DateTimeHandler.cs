using System;
using System.Web;

namespace Demo1.Handlers.Handlers
{
    public class DateTimeHandler : IHttpHandler
    {
        /// <summary>
        /// You will need to configure this handler in the Web.config file of your 
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: https://go.microsoft.com/?linkid=8101007
        /// </summary>

        // Return false in case your Managed Handler cannot be reused for another request.
        // Usually this would be false in case you have some state information preserved per request.
        public bool IsReusable => false;

        public void ProcessRequest(HttpContext context)
        {
            string msg = $"<h1>Today is {DateTime.Now:f}</h1>";
            context.Response.Write(msg);
        }
    }
}