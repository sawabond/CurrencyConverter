using CurrencyConverter.Interfaces;

namespace CurrencyConverter.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ExchangeRateContext _context;
        public ExchangeRateRepository ExchangeRateRepo { get; private set; }
        public UnitOfWork(ExchangeRateContext context)
        {
            _context = context;
            ExchangeRateRepo = new ExchangeRateRepository(context);
        }
        public bool Confirm()
        {
            return _context.SaveChanges() > 0;
        }
    }
}