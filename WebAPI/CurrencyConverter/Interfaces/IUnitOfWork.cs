using CurrencyConverter.Data;

namespace CurrencyConverter.Interfaces
{
    public interface IUnitOfWork
    {
        ExchangeRateRepository ExchangeRateRepo { get; }
        bool Confirm();
    }
}