using System;
using System.Web;

namespace Chapter5.HandlersAndModules.Infrastructure
{
    public class DateTimeHandler : IHttpHandler, IDateTimeHandler
    {
        public bool IsReusable => false;

        public void ProcessRequest(HttpContext context)
        {
            if (context.Items.Contains(Constants.DateTimeKey) && context.Items[Constants.DateTimeKey] is DateTime)
            {
                string msg = ((DateTime)context.Items[Constants.DateTimeKey]).ToLongDateString();
                context.Response.Write(msg);
            }
            else
            {
                context.Response.Write("Hey, the info I need is missing :(((");
            }
        }
    }
}