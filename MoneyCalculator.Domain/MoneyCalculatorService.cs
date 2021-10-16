using MoneyCalculator.Models;
using MoneyCalculator.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneyCalculator.Domain
{
    public interface IMoneyCalculator
    {
        /// <summary>
        /// Find the largest amount of money.
        /// </summary>
        /// <returns>The <see cref="IMoney"/> instance having the largest amount.</returns>
        /// <exception cref="ArgumentException">All monies are not in the same currency.</exception>
        IMoney Max(IEnumerable<IMoney> monies);

        /// <summary>
        /// Return a <see cref="IMoney"/> per currency with the sum of all monies of the same currency.
        /// </summary>
        /// <example>{GBP10, GBP20, GBP50} => {GBP80}</example>
        /// <example>{GBP10, GBP20, EUR50} => {GBP30, EUR50}</example>
        /// <example>{GBP10, USD20, EUR50} => {GBP10, USD20, EUR50}</example>
        IEnumerable<IMoney> SumPerCurrency(IEnumerable<IMoney> monies);
    }


    public class MoneyCalculatorService : IMoneyCalculator
    {
        public MoneyCalculatorService()
        {

        }
        public IMoney Max(IEnumerable<IMoney> monies)
        {
            if (!IsAllCurrencySame(monies))
                throw new ArgumentException("All monies are not in the same currency");

            return monies.OrderByDescending(x => x.Amount).First();
        }

        public IEnumerable<IMoney> SumPerCurrency(IEnumerable<IMoney> monies)
        {
            return monies.GroupBy(x => x.Currency).Select(a => new Money() { Currency = a.Key, Amount = a.Sum(x => x.Amount) });
        }
        private bool IsAllCurrencySame(IEnumerable<IMoney> monies)
        {
            return monies.All(x => x.Currency == monies.First().Currency);
        }
    }
}
