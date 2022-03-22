using CurrencyConverter.Data;
using System.Threading.Tasks;

namespace CurrencyConverter.Interfaces
{
    public interface IUnitOfWork
    {
        ExchangeRateRepository ExchangeRateRepo { get; }
        Task<bool> ConfirmAsync();
    }
}