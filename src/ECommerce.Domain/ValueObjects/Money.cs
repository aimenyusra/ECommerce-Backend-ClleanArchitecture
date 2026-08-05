using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Domain.ValueObjects
{
    public sealed class Money : IEquatable<Money>
    {
        public decimal Amount { get; }
        public string Currency { get; }
        private Money(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }
        public static Money Create (decimal amount, string currency = "USD")
        {
            if (amount < 0) throw new ArgumentException("Amount cannot be negative", nameof(amount));
            if (string.IsNullOrWhiteSpace(currency)) 
                throw new ArgumentException("Currency cannot be null or empty", nameof(currency));
            return new Money(amount, currency.ToUpperInvariant());
        }
        public Money Add(Money other)
        {
          EnsureSameCurrency (other);
            return new Money(Amount + other.Amount, Currency);
        }
        private void EnsureSameCurrency(Money other)
        { 
            if (Currency != other.Currency)
                throw new InvalidOperationException($"Cannot add amounts with different currencies: {Currency} and {other.Currency}");
        }
        public Money Multiply (int factor)
        {
            if (factor < 0) throw new ArgumentException("Factor cannot be negative", nameof(factor));
            return new Money(Amount * factor, Currency);
        }
        public bool Equals(Money? other) =>
        
            other is not null && Amount == other.Amount && Currency == other.Currency;
        
        public override bool Equals(object? obj) => Equals(obj as Money);
        public override int GetHashCode() => HashCode.Combine(Amount, Currency);
        public override string ToString() => $"{Amount:0.00} {Currency}";
    }
}
