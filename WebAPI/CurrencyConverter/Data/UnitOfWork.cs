using CurrencyConverter.Interfaces;
using System.Threading.Tasks;

namespace CurrencyConverter.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CurrencyConverterContext _context;
        public ExchangeRateRepository ExchangeRateRepo { get; private set; }
        public UnitOfWork(CurrencyConverterContext context)
        {
            _context = context;
            ExchangeRateRepo = new ExchangeRateRepository(context);

            _context.Database.EnsureCreated();
        }
        public async Task<bool> ConfirmAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}