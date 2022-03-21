using CurrencyConverter.Data;
using CurrencyConverter.Repositories;

namespace CurrencyConverter.UnitOfWork
{
    public class UnitOfWork
    {
        private ExchangeRateRepository _exchangeRatesRepo;
        private ExchangeRateContext _exchangeRatesContext;
        public ExchangeRateRepository ExchangeRatesRepo
        {
            get
            {
                if (_exchangeRatesRepo == null)
                    _exchangeRatesRepo = new ExchangeRateRepository(_exchangeRatesContext);
                return _exchangeRatesRepo;
            }
        }
    }
}
