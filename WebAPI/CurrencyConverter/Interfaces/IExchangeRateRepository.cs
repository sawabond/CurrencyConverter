using Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CurrencyConverter.Interfaces
{
    public interface IExchangeRateRepository
    {
        ExchangeRate Get(int id);
        ExchangeRate GetByName(string currencyName);
        IEnumerable<ExchangeRate> GetAll();
        IEnumerable<ExchangeRate> Find(Expression<Func<ExchangeRate, bool>> expression);
        void Add(ExchangeRate exchangeRate);
        void AddRange(IEnumerable<ExchangeRate> exchangeRates);
        void Remove(ExchangeRate exchangeRate);
        void RemoveRange (IEnumerable<ExchangeRate> exchangeRates);
    }
}