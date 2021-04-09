using System;
using System.Diagnostics;
using System.Web;

namespace Demo3.Modules.Modules
{
    public class InfoModule : IHttpModule
    {
        private Stopwatch requestTimer;

        public void Dispose()
        {
        }

        public void Init(HttpApplication application)
        {
            //Subscriptions done here
            application.BeginRequest += (src, args) =>
              {
                  this.requestTimer = Stopwatch.StartNew();
              };

            application.EndRequest += HandleEndRequest;
        }

        private void HandleEndRequest(object src, EventArgs args)
        {
            var status = HttpContext.Current.Response.Status;
            var browser = HttpContext.Current.Request.Browser.Browser;
            var elapsedTime = requestTimer.ElapsedMilliseconds;
            var infoMsg = $"Response status: {status}; Elapsed Time: {elapsedTime} ms; Browser: {browser}";
            HttpContext.Current.Response.Write(infoMsg);
            Debug.WriteLine(infoMsg);
        }
    }
}