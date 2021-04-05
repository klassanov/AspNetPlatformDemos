using System;
using System.Web;

namespace Chapter5.HandlersAndModules.Infrastructure
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