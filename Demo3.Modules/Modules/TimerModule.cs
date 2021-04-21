using System;
using System.Diagnostics;
using System.Web;
using Demo3.Modules.Events;

namespace Demo3.Modules.Modules
{
    public class TimerModule : IHttpModule
    {
        private Stopwatch timer;
        public event EventHandler<RequestTimeEventArgs> RequestTimed;

        public void Init(HttpApplication application)
        {
            application.BeginRequest += (src, args) =>
            {
                this.timer = Stopwatch.StartNew();
            };

            application.EndRequest += (src, args) =>
            {
                var eventArgs = new RequestTimeEventArgs { DurationMilliseconds = this.timer.ElapsedMilliseconds };
                RequestTimed?.Invoke(this, eventArgs);
            };
        }

        public void Dispose()
        {
        }
    }
}