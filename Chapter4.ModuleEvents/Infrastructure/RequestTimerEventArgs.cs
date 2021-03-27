using System;

namespace Chapter4.ModuleEvents.Infrastructure
{
    //Custom event with additional field the request duration in milliseconds
    public class RequestTimerEventArgs : EventArgs
    {
        public long DurationMilliseconds { get; set; }
    }
}