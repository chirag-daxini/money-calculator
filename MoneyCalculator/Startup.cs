using Microsoft.Extensions.Hosting;
using MoneyCalculator.Domain;
using MoneyCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MoneyCalculator
{
    public class Startup : IHostedService
    {
        private readonly IMoneyStorageService _moneyStorage;
        private readonly IMoneyCalculator _moneyCalculator;
        public Startup(IMoneyStorageService moneyStorage, IMoneyCalculator moneyCalculator)
        {
            _moneyStorage = moneyStorage;
            _moneyCalculator = moneyCalculator;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Welcome to Currency calculator Enter your choice (1 - Maximum currency or 2 -  Currency wise sum):");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    {
                        var monies = new List<Money>();
                        monies.Add(new Money() { Amount = 100, Currency = "EUR" });
                        monies.Add(new Money() { Amount = 500, Currency = "EUR" });
                        monies.Add(new Money() { Amount = 2, Currency = "EUR" });
                        var result = _moneyCalculator.Max(monies);
                        Console.WriteLine($"largest amount in collection is {result.Amount}");
                    }
                    break;
                case "2":
                    {
                        var monies = _moneyStorage.Get();
                        var result = _moneyCalculator.SumPerCurrency(monies);
                        Console.WriteLine($"SumPerCurrency is {string.Join(',', Enumerable.Select(monies, x => x))}");
                    }
                    break;
                default:
                    {
                        Console.WriteLine("Wrong choice");
                        break;
                    }
            }

        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Program ended");
        }
    }
}
