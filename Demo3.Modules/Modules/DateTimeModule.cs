using System;
using System.Web;
using Demo3.Modules.Interfaces;

namespace Demo3.Modules.Modules
{
    public class DateTimeModule : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication application)
        {
            application.PostMapRequestHandler += (src, args) =>
            {
                if (application.Context.Handler is IDateTimeHandler)
                {
                    application.Context.Items[Constants.DateTimeKey] = DateTime.Now;
                }
            };
        }
    }
}