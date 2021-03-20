using System;
using System.Diagnostics;
using System.Web;

namespace Chapter4.TimerModule.Modules
{
    public class TimerModule : IHttpModule
    {
        /*
         Multiple module instances can exist simultaneously and each module can handle
         multiple requests, but sequentially. Each global application class is given its own
         set of module instances.
         */

        private Stopwatch timer;

        /// <summary>
        /// Called only once when the module is created. Not called per request.
        /// If the module processes multiple requests sequentially, this method will be called once
        /// and not per each request.
        /// </summary>
        /// <param name="application"></param>
        public void Init(HttpApplication application)
        {
            //Subscribe for lifecycle events and define custom event handlers
            application.BeginRequest += OnBeginRequest;
            application.EndRequest += OnEndRequest;
        }

        /// <summary>
        /// Called when the class is disposed.
        /// Can be used to release any resources
        /// </summary>
        public void Dispose()
        {
        }

        private void OnBeginRequest(object src, EventArgs args)
        {
            this.timer = Stopwatch.StartNew();
        }

        private void OnEndRequest(object src, EventArgs args)
        {
            string msg = $"Elapsed time: {this.timer.ElapsedMilliseconds} [ms] ";
            HttpContext.Current.Response.Write(msg);
            Debug.WriteLine(msg);

            //Do other things
        }

    }
}