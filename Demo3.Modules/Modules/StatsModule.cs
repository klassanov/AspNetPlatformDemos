using System.Collections.Generic;
using System.Web;

namespace Demo3.Modules.Modules
{
    public class StatsModule : IHttpModule
    {
        private static List<string> requestUrls = new List<string>();
        private static object lockObject = new object();


        public void Init(HttpApplication app)
        {
            app.BeginRequest += (src, args) =>
            {
                lock (lockObject)
                {
                    if (app.Request.RawUrl.ToLower() == "/stats")
                    {
                        app.Response.Write($"")
                    }
                    else
                    {
                        requestUrls.Add(app.Request.RawUrl.ToLower());
                    }
                }
            };
        }

        public void Dispose()
        {
        }
    }
}