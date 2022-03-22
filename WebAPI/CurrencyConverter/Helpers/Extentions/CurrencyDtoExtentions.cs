using CurrencyConverter.DTO;
using Model;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyConverter.Helpers.Extentions
{
    public static class CurrencyDtoExtentions
    {
        public static bool MapFromExchangeRate(this CurrencyDto currencyDto, IEnumerable<ExchangeRate> exchangeRates)
        {
            try
            {
                currencyDto.Base = exchangeRates.FirstOrDefault().BaseCurrencyName;
                
                foreach (ExchangeRate exchangeRate in exchangeRates)
                {
                    currencyDto.Rates.TryAdd(exchangeRate.CurrencyName, exchangeRate.Amount);
                }

                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
