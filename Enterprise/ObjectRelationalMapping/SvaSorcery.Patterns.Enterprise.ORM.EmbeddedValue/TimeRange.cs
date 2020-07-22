using System;

namespace SvaSorcery.Patterns.Enterprise.ORM.EmbeddedValue
{
    public class TimeRange
    {
        public TimeSpan From { get; }
        public TimeSpan To { get; }

        public TimeRange(TimeSpan from, TimeSpan to)
        {
            From = from;
            To = to;
        }
    }
}
