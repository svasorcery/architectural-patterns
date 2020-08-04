using System;

namespace SvaSorcery.Patterns.Enterprise.Base.ValueObject
{
    public class Money
    {
        public decimal Amount { get; private set; }
        public Currency Currency { get; }

        public Money(decimal amount, Currency currency)
        {
            Currency = currency;
            Amount = amount * currency.CentFactor;
        }

        public Money NewMoney(decimal amount)
            => new Money(amount, Currency);

        public Money Add(Money value)
            => NewMoney(Amount + value.Amount);

        public Money Subtract(Money value)
            => NewMoney(Amount - value.Amount);

        public Money Multiply(int factor, MidpointRounding rounding = MidpointRounding.AwayFromZero)
            => NewMoney(Math.Round(Amount * factor, rounding));

        public Money Divide(int factor, MidpointRounding rounding = MidpointRounding.AwayFromZero)
            => NewMoney(Math.Round(Amount / factor, rounding));

        public bool Equals(Money other)
            => CheckSameCurrency(other) && Amount == other.Amount;

        private bool CheckSameCurrency(Money value)
            => Currency.Name == value.Currency.Name;

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

        public static Money Dollars(decimal amount) => new Money(amount, new Currency("USD", 2));
        public static Money Roubles(decimal amount) => new Money(amount, new Currency("RUR", 2));
    }

    public class Currency
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
