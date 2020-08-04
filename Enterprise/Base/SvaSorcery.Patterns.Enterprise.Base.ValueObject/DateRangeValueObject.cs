using System;

namespace SvaSorcery.Patterns.Enterprise.Base.ValueObject
{
    public class DateRangeValueObject
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public DateRangeValueObject(DateTime from, DateTime to)
        {
            From = from;
            To = to;
        }

        public DateRangeValueObject(string fromString, string toString)
        {
            TryParse(fromString, out DateTime from);
            TryParse(toString, out DateTime to);
            new DateRangeValueObject(from, to);
        }

        public bool IsBetween(DateTime dateToCheck)
            => dateToCheck >= From && dateToCheck < To;

        public bool IsStarted => From < DateTime.Now;

        public bool IsFinished => To < DateTime.Now;

        private bool TryParse(string dateString, out DateTime date)
            => DateTime.TryParse(dateString, out date);
    }
}
