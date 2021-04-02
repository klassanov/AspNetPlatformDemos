﻿using System.Web;

namespace Chapter5.Handlers.Infrastructure
{
    public class InfoModule : IHttpModule
    {
        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public void Init(HttpApplication application)
        {
            application.PostMapRequestHandler += (src, args) =>
              {
                  string handlerName = application.Context.Handler.GetType().FullName;
                  application.Context.Response.Write($"Response generated by {handlerName}");
              };
        }
    }
}