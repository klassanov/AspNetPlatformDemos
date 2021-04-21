using System;
using System.Web;
using Demo3.Modules.Interfaces;

namespace Demo3.Modules.Handlers
{
    public class DateTimeHandler : IHttpHandler, IDateTimeHandler
    {
        public bool IsReusable => false;

        public void ProcessRequest(HttpContext context)
        {
            if (context.Items.Contains(Constants.DateTimeKey) && context.Items[Constants.DateTimeKey] is DateTime time)
            {
                string msg = $"DateTimeHandler: The date I am provided with is {time.ToLongDateString()}";
                context.Response.Write(msg);
            }
            else
            {
                context.Response.Write("DateTimeHandler: Hey, the info I need is missing :(((");
            }
        }
    }
}