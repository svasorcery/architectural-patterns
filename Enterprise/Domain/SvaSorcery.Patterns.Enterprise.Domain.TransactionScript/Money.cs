using System;

namespace SvaSorcery.Patterns.Enterprise.Domain.TransactionScript
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

        public Money Add(Money value)
            => new Money(Amount += value.Amount, Currency);

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
