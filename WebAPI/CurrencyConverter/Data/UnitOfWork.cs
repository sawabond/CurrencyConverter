using CurrencyConverter.Interfaces;

namespace CurrencyConverter.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public ExchangeRateRepository ExchangeRateRepo { get; private set; }
        public UnitOfWork(ExchangeRateContext context)
        {
            ExchangeRateRepo = new ExchangeRateRepository(context);
        }
    }
}
