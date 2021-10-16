using System;
using System.Collections.Generic;

namespace MoneyCalculator.Domain
{
    public interface ICurrencyStorageService
    {
        string Next();
    }
    public class CurrencyStorageService : ICurrencyStorageService
    {
        private Dictionary<int, string> _currencies = new Dictionary<int, string>();
        private readonly Random _random = new Random();
        public CurrencyStorageService()
        {
            Intialize();
        }
        private void Intialize()
        {
            _currencies.Add(1, "GBP");
            _currencies.Add(2, "EUR");
            _currencies.Add(3, "INR");
            _currencies.Add(4, "USD");
            _currencies.Add(5, "FR");
            _currencies.Add(6, "NZD");
            _currencies.Add(7, "QAR");
        }
        public string Next()
        {
            return _currencies[_random.Next(1, 7)];
        }
    }
}
