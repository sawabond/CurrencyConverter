using Microsoft.EntityFrameworkCore;

namespace CurrencyConverter
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
