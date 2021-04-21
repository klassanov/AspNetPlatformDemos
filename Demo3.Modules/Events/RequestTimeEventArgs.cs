using System;

namespace Demo3.Modules.Events
{
    //Custom event with additional field the request duration in milliseconds
    public class RequestTimeEventArgs : EventArgs
    {
        public long DurationMilliseconds { get; set; }
    }
}