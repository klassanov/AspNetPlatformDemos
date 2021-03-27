using System;
using System.Diagnostics;
using System.Web;

namespace Chapter4.ModuleEvents.Infrastructure
{
    public class TimerModule : IHttpModule
    {
        private Stopwatch timer;
        public event EventHandler<RequestTimerEventArgs> RequestTimed;

        public void Init(HttpApplication application)
        {
            application.BeginRequest += (src, args) =>
            {
                this.timer = Stopwatch.StartNew();
            };

            application.EndRequest += (src, args) =>
            {
                RequestTimed?.Invoke(this, new RequestTimerEventArgs { DurationMilliseconds = this.timer.ElapsedMilliseconds });
            };
        }

        public void Dispose()
        {
        }
    }
}