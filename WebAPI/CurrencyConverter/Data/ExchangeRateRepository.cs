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
        private readonly ExchangeRateContext _context;
        public ExchangeRateRepository(ExchangeRateContext context)
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
        public IEnumerable<ExchangeRate> Find(Expression<Func<ExchangeRate, bool>> expression)
        {
            return _context.Set<ExchangeRate>().Where(expression);
        }
        public async Task<IEnumerable<ExchangeRate>> GetAllAsync()
        {
            return await _context.Set<ExchangeRate>().ToListAsync();
        }
        public async Task<ExchangeRate> GetAsync(int id)
        {
            return await _context.Set<ExchangeRate>().FindAsync(id);
        }
        public async Task<ExchangeRate> GetByNameAsync(string currencyName)
        {
            return await _context.Set<ExchangeRate>().SingleOrDefaultAsync(exchangeRate => exchangeRate.CurrencyName == currencyName);
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