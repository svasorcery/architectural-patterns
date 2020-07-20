using System;
using System.Timers;

namespace SvaSorcery.Patterns.Enterprise.Cache.Common.Utilities
{
    public class EventTimer
    {
        private readonly Timer _timer;

        public EventTimer(TimeSpan span)
        {
            _timer = new Timer
            {
                Interval = span.Milliseconds
            };
        }

        public void Reset()
        {
            _timer.Stop();
            _timer.Start();
        }

        public void Start() => _timer.Start();
        public void Stop() => _timer.Stop();

        public void AddListener(ElapsedEventHandler handler) => _timer.Elapsed += handler;
        public void RemoveListener(ElapsedEventHandler handler) => _timer.Elapsed -= handler;
    }
}
