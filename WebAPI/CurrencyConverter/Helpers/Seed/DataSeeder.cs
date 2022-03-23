using CurrencyConverter.Data;
using Microsoft.EntityFrameworkCore;
using Model;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace CurrencyConverter.Helpers.Seed
{
    public static class DataSeeder
    {
        private const string SeedFilePath = @"C:\Users\Саша\source\repos\CurrencyConverter\WebAPI\CurrencyConverter\Helpers\Seed\seed-data.json";
        public static async Task Seed(CurrencyConverterContext context)
        {
            if (await context.ExchangeRates.AnyAsync())
            {
                return;
            }

            string modelsJson;

            using (var streamReader = new StreamReader(SeedFilePath))
            {
                modelsJson = await streamReader.ReadToEndAsync();
            }

            var options = new JsonSerializerOptions{ WriteIndented = true };

            var models = JsonSerializer.Deserialize<IEnumerable<ExchangeRate>>(modelsJson, options);

            await context.AddRangeAsync(models);

            await context.SaveChangesAsync();
        }
    }
}
