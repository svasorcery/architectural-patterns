using System;
using System.Timers;

namespace SvaSorcery.Patterns.Enterprise.Resource.ResourceTimer
{
    public class DatabaseConnectionTimer : IResourceTimer
    {
        private readonly Timer _timer;

        public DatabaseConnectionTimer(TimeSpan span)
            => _timer = new()
            {
                Interval = span.Milliseconds
            };

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
