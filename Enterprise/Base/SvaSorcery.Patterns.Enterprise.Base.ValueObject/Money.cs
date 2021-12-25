using System;

namespace SvaSorcery.Patterns.Enterprise.Base.ValueObject
{
    public record Money
    {
        public decimal Amount { get; }
        public Currency Currency { get; }

        public Money(decimal amount, Currency currency)
            => (Amount, Currency) = (amount * currency.CentFactor, currency);

        public Money NewMoney(decimal amount)
            => new(amount, Currency);

        public Money Add(Money value)
            => NewMoney(Amount + value.Amount);

        public Money Subtract(Money value)
            => NewMoney(Amount - value.Amount);

        public Money Multiply(int factor, MidpointRounding rounding = MidpointRounding.AwayFromZero)
            => NewMoney(Math.Round(Amount * factor, rounding));

        public Money Divide(int factor, MidpointRounding rounding = MidpointRounding.AwayFromZero)
            => NewMoney(Math.Round(Amount / factor, rounding));

        public Money[] Allocate(int parts)
        {
            var result = new Money[parts];
            var allocateAmount = Amount / parts;
            for (int i = 0; i < parts; i++)
            {
                result[i] = new Money(allocateAmount, Currency);
            }
            return result;
        }

        public static Money Dollars(decimal amount)
            => new(amount, new Currency("USD", 2));

        public static Money Roubles(decimal amount)
            => new(amount, new Currency("RUR", 2));
    }

    public record Currency
    {
        public string Name { get; }
        public int FractionDigits { get; }
        public int CentFactor => _cents[FractionDigits];

        private readonly int[] _cents = { 1, 10, 100, 1000 };

        public Currency(string name, int fractionDigits = 2)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            if (fractionDigits < 0 || fractionDigits > 3)
                throw new ArgumentOutOfRangeException(nameof(fractionDigits));

            Name = name;
            FractionDigits = fractionDigits;
        }
    }
}
