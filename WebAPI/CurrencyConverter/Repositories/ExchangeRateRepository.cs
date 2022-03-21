﻿using CurrencyConverter.Data;
using CurrencyConverter.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CurrencyConverter.Repositories
{
    public class ExchangeRateRepository : IExchangeRateRepository
    {
        protected readonly ExchangeRateContext _context;
        public ExchangeRateRepository(ExchangeRateContext context)
        {
            _context = context;
        }
        public void Add(ExchangeRate exchangeRate)
        {
            _context.Set<ExchangeRate>().Add(exchangeRate);
        }
        public void AddRange(IEnumerable<ExchangeRate> exchangeRates)
        {
            _context.Set<ExchangeRate>().AddRange(exchangeRates);
        }
        public IEnumerable<ExchangeRate> Find(Expression<Func<ExchangeRate, bool>> expression)
        {
            return _context.Set<ExchangeRate>().Where(expression);
        }
        public IEnumerable<ExchangeRate> GetAll()
        {
            return _context.Set<ExchangeRate>().ToList();
        }
        public ExchangeRate Get(string currencyName)
        {
            return _context.Set<ExchangeRate>().Find(currencyName);
        }
        public void Remove(ExchangeRate exchangeRate)
        {
            _context.Set<ExchangeRate>().Remove(exchangeRate);
        }
        public void RemoveRange(IEnumerable<ExchangeRate> exchangeRates)
        {
            _context.Set<ExchangeRate>().RemoveRange(exchangeRates);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}