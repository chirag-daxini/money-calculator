using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneyCalculator.Domain;
using MoneyCalculator.Models;
using MoneyCalculator.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneyCalculator.Tests
{
    [TestClass]
    public class MoneyCalculatorTests
    {
        private IMoneyCalculator _moneyCalculator;
        private List<IMoney> _differentMonies;
        private List<IMoney> _sameCurrencyMonies;
        [TestInitialize]
        public void Intialize()
        {
            _moneyCalculator = new MoneyCalculatorService();

            _differentMonies = new List<IMoney>() {
                new Money() { Amount = 1, Currency = "GBP" },
                new Money() { Amount = 2, Currency = "EUR"}, new Money() { Amount = 3, Currency = "GBP" } };

            _sameCurrencyMonies = new List<IMoney>() {
                new Money() { Amount = 100, Currency = "EUR" },
                new Money() { Amount = 50, Currency = "EUR" },
                new Money() { Amount = 10, Currency = "EUR" }};

        }

        #region Max
        [TestMethod]
        public void Should_throw_Exception_in_case_Of_different_Monies()
        {
            //Act
            var exception = Assert.ThrowsException<ArgumentException>(() => _moneyCalculator.Max(_differentMonies));

            //Assert
            Assert.AreEqual(exception.Message, "All monies are not in the same currency");
        }
        [TestMethod]
        public void Should_return_maximum_money_in_case_of_same_Currency()
        {
            //Arrange
            var preparedResult = _sameCurrencyMonies.OrderByDescending(x => x.Amount).First();

            //Act
            var result = _moneyCalculator.Max(_sameCurrencyMonies);

            //Assert
            Assert.AreEqual(result.Amount, preparedResult.Amount);
            Assert.AreEqual(result.Currency, preparedResult.Currency);
        }
        [TestMethod]
        public void Should_throw_invalidoperation_in_case_of_empty_collection()
        {
            //Arrange
            var emptyCollection = new List<IMoney>();

            //Act
            var exception = Assert.ThrowsException<InvalidOperationException>(() => _moneyCalculator.Max(emptyCollection));

            //Assert
            Assert.AreEqual(exception.GetType(), typeof(InvalidOperationException));

        }
        #endregion

        #region SumByCurrencies
        [TestMethod]
        public void Should_return_sumbycurrency_in_case_of_valid_data()
        {
            //Arrange
            var expectedResult = new List<IMoney>() { new Money() { Amount = 4, Currency = "GBP" }, new Money() { Amount = 2, Currency = "EUR" } };

            //Act
            var result = _moneyCalculator.SumPerCurrency(_differentMonies);

            //Assert
            Assert.IsTrue(result.Count() > 0);
            Assert.AreEqual(result.First().ToString(), expectedResult.First().ToString());
        }
        #endregion
    }
}
