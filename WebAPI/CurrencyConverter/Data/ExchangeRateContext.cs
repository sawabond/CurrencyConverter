using Microsoft.EntityFrameworkCore;
using Model;

namespace CurrencyConverter.Data
{
    public class ExchangeRateContext : DbContext
    {
        public ExchangeRateContext(DbContextOptions options)
            :base(options)
        {

        }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }
    }
}
