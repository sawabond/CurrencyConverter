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
        Task AddAsync(ExchangeRate exchangeRate);
        Task AddRangeAsync(IEnumerable<ExchangeRate> exchangeRates);
        Task<IEnumerable<ExchangeRate>> FindAsync(Expression<Func<ExchangeRate, bool>> expression);
        void Update(ExchangeRate exchangeRate);
        void Remove(ExchangeRate exchangeRate);
        void RemoveRange (IEnumerable<ExchangeRate> exchangeRates);
    }
}