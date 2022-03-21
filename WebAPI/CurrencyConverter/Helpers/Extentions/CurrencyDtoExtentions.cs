using CurrencyConverter.DTO;
using Model;
using System.Collections.Generic;
using System.Linq;
using System;

namespace CurrencyConverter.Helpers.Extentions
{
    public static class CurrencyDtoExtentions
    {
        public static bool MapFromExchangeRate(this CurrencyDto currencyDto, IList<ExchangeRate> exchangeRates)
        {
            try
            {
                if (exchangeRates.All(x => x.BaseCurrencyName == exchangeRates[0].BaseCurrencyName) == false)
                {
                    return false;
                }

                currencyDto.Base = exchangeRates[0].BaseCurrencyName;
                
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
