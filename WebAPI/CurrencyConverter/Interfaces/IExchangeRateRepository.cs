using Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CurrencyConverter.Interfaces
{
    public interface IExchangeRateRepository
    {
        Task<ExchangeRate> GetAsync(int id);
        Task<ExchangeRate> GetByNameAsync(string currencyName);
        Task<IEnumerable<ExchangeRate>> GetAllAsync();
        IEnumerable<ExchangeRate> Find(Expression<Func<ExchangeRate, bool>> expression);
        Task AddAsync(ExchangeRate exchangeRate);
        Task AddRangeAsync(IEnumerable<ExchangeRate> exchangeRates);
        void Remove(ExchangeRate exchangeRate);
        void RemoveRange (IEnumerable<ExchangeRate> exchangeRates);
    }
}