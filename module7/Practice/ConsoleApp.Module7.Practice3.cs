using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Module8.Practice
{
    public class Money
    {
        public decimal Amount { get; }
        public string Currency { get; }

        public Money(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        // Первый вариант сложения (без перегрузки операторов)
        public Money Add(Money other)
        {
            if (Currency != other.Currency)
                throw new InvalidOperationException("В данном методе нельзя складывать разные валюты.");

            return new Money(Amount + other.Amount, Currency);
        }

        // Второй вариант сложения
        public static Money operator +(Money left, Money right)
        {
            if (left.Currency == right.Currency)
            {
                return new Money(left.Amount + right.Amount, left.Currency);
            }
            else
            {
                decimal convertedAmount = CurrencyConverter.Convert(right.Amount, right.Currency, left.Currency);
                return new Money(left.Amount + convertedAmount, left.Currency);
            }
        }

        public static bool operator ==(Money left, Money right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Money left, Money right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is Money other)
            {
                if (Currency == other.Currency)
                    return Amount == other.Amount;

                decimal convertedAmount = CurrencyConverter.Convert(other.Amount, other.Currency, Currency);
                return Amount == convertedAmount;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Tuple.Create(Amount, Currency).GetHashCode();
        }

        public override string ToString()
        {
            return $"{Amount} {Currency}";
        }
    }

    public static class CurrencyConverter
    {
        public static decimal Convert(decimal amount, string fromCurrency, string toCurrency)
        {
            if (fromCurrency == "USD" && toCurrency == "EUR")
                return amount * 0.85M;
            if (fromCurrency == "EUR" && toCurrency == "USD")
                return amount * 1.18M;
            // Можно сделать и для других валют

            throw new Exception("Currency conversion not supported");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Money dollars = new Money(100, "USD");
            Money euros = new Money(50, "EUR");

            // Первый вариант сложения
            Money sum1 = dollars.Add(euros); // Четко
            Console.WriteLine($"Sum1: {sum1}");

            // Второй вариант сложения
            Money sum2 = dollars + euros; // произойдет замена валюты
            Console.WriteLine($"Sum2: {sum2}");
        }
    }
}
