using Microsoft.EntityFrameworkCore;
using Model;

namespace CurrencyConverter.Data
{
    public class CurrencyConverterContext : DbContext
    {
        public CurrencyConverterContext(DbContextOptions options)
            :base(options)
        {

        }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }
    }
}
