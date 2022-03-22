using Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CurrencyConverter.Interfaces
{
    public interface IExchangeRateRepository
    {
<<<<<<< HEAD
        Task<ExchangeRate> GetAsync(int id);
        Task<ExchangeRate> GetByNameAsync(string currencyName);
        Task<IEnumerable<ExchangeRate>> GetAllAsync();
        IEnumerable<ExchangeRate> Find(Expression<Func<ExchangeRate, bool>> expression);
        Task AddAsync(ExchangeRate exchangeRate);
        Task AddRangeAsync(IEnumerable<ExchangeRate> exchangeRates);
=======
        Task<ExchangeRate> Get(int id);
        Task<ExchangeRate> GetByName(string currencyName);
        Task<IEnumerable<ExchangeRate>> GetAll();
        Task<IEnumerable<ExchangeRate>> FindAsync(Expression<Func<ExchangeRate, bool>> expression);
        Task Add(ExchangeRate exchangeRate);
        Task AddRange(IEnumerable<ExchangeRate> exchangeRates);
>>>>>>> b59dc24f497d859819a7f64c9a95cd0744c1f70d
        void Remove(ExchangeRate exchangeRate);
        void RemoveRange (IEnumerable<ExchangeRate> exchangeRates);
    }
}