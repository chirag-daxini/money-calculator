using MoneyCalculator.Models;
using MoneyCalculator.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace MoneyCalculator.Domain
{
    public interface IMoneyStorageService
    {
        IList<IMoney> Get();
    }
    public class MoneyStorageService : IMoneyStorageService
    {
        private readonly Random _random = new Random();
        const int NO_OF_ITEMS = 10;
        private readonly ICurrencyStorageService _currencyStorage;
        public MoneyStorageService(ICurrencyStorageService currencyStorage)
        {
            _currencyStorage = currencyStorage;
        }
        public IList<IMoney> Get()
        {
            List<IMoney> money = new List<IMoney>();
            for (int i = 0; i < NO_OF_ITEMS; i++)
            {
                money.Add(new Money() { Amount = _random.Next(1, 1000), Currency = _currencyStorage.Next() });
            }
            return money;
        }
    }
}
