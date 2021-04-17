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
                        app.Response.Write($"<div>There have been {requestUrls.Count} requests</div>");
                        app.Response.Write("<table><tr><th>#</th><th>URL</th></tr>");
                        for (int i = 0; i < requestUrls.Count; i++)
                        {
                            app.Response.Write($"<tr><td>{i}</td><td>&nbsp; {requestUrls[i]}</td></tr>");
                        }
                        app.Response.Write("</table>");

                        app.CompleteRequest();
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