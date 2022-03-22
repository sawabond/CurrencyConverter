using Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CurrencyConverter.Interfaces
{
    public interface IExchangeRateRepository
    {
        Task<ExchangeRate> Get(int id);
        Task<ExchangeRate> GetByName(string currencyName);
        Task<IEnumerable<ExchangeRate>> GetAll();
        IEnumerable<ExchangeRate> Find(Expression<Func<ExchangeRate, bool>> expression);
        Task Add(ExchangeRate exchangeRate);
        Task AddRange(IEnumerable<ExchangeRate> exchangeRates);
        void Remove(ExchangeRate exchangeRate);
        void RemoveRange (IEnumerable<ExchangeRate> exchangeRates);
    }
}