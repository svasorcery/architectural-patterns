using System;

namespace SvaSorcery.Patterns.Enterprise.Base.ValueObject
{
    public record DateRangeValueObject
    {
        public DateTime From { get; private set; }
        public DateTime To { get; private set; }

        public DateRangeValueObject(DateTime from, DateTime to)
        {
            From = from;
            To = to;
        }

        public DateRangeValueObject(string fromString, string toString)
        {
            if (!TryParse(fromString, out DateTime from))
                throw new ArgumentException(nameof(fromString));

            if (!TryParse(toString, out DateTime to))
                throw new ArgumentException(nameof(toString));

            _ = new DateRangeValueObject(from, to);
        }

        public bool IsBetween(DateTime dateToCheck)
            => dateToCheck >= From && dateToCheck < To;

        public bool IsStarted => From < DateTime.Now;

        public bool IsFinished => To < DateTime.Now;

        private static bool TryParse(string dateString, out DateTime date)
            => DateTime.TryParse(dateString, out date);
    }
}
