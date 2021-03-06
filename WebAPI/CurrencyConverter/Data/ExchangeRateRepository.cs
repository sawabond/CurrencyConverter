using CurrencyConverter.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CurrencyConverter.Data
{
    public class ExchangeRateRepository : IExchangeRateRepository
    {
        private readonly CurrencyConverterContext _context;
        public ExchangeRateRepository(CurrencyConverterContext context)
        {
            _context = context;
        }
        public async Task AddAsync(ExchangeRate exchangeRate)
        {
            await _context.Set<ExchangeRate>().AddAsync(exchangeRate);
        }
        public async Task AddRangeAsync(IEnumerable<ExchangeRate> exchangeRates)
        {
            await _context.Set<ExchangeRate>().AddRangeAsync(exchangeRates);
        }
        public async Task<IEnumerable<ExchangeRate>> FindAsync(Expression<Func<ExchangeRate, bool>> expression)
        {
            var query = _context.Set<ExchangeRate>().Where(expression);

            return await query.ToListAsync();
        }
        public async Task<IEnumerable<ExchangeRate>> GetAllAsync()
        {
            return await _context.Set<ExchangeRate>().ToListAsync();
        }
        public async Task<ExchangeRate> GetAsync(int id)
        {
            return await _context.Set<ExchangeRate>().FindAsync(id);
        }
        public async Task<ExchangeRate> GetByNamesAsync(string baseCurrencyName, string currencyName)
        {
            return await _context.Set<ExchangeRate>().FirstOrDefaultAsync(x => x.BaseCurrencyName == baseCurrencyName && x.CurrencyName == currencyName);
        }
        public async Task<IEnumerable<ExchangeRate>> GetRangeByNameAsync(string baseCurrencyName)
        {
            var query = _context.Set<ExchangeRate>().Where(exchangeRate => exchangeRate.BaseCurrencyName == baseCurrencyName);

            return await query.ToListAsync();
        }
        public void Update(ExchangeRate exchangeRate)
        {
            _context.Set<ExchangeRate>().Update(exchangeRate);
        }
        public void Remove(ExchangeRate exchangeRate)
        {
            _context.Set<ExchangeRate>().Remove(exchangeRate);
        }
        public void RemoveRange(IEnumerable<ExchangeRate> exchangeRates)
        {
            _context.Set<ExchangeRate>().RemoveRange(exchangeRates);
        }
    }
}