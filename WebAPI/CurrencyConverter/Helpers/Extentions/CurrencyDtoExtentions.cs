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
        public static ExchangeRate MapFromDto(this ExchangeRate model, ExchangeRateDto exchangeRateDto)
        {
            try
            {
                model.CurrencyName = exchangeRateDto.CurrencyName;
                model.BaseCurrencyName = exchangeRateDto.BaseCurrencyName;
                model.Amount = exchangeRateDto.Amount;
                return model;
            }
            catch
            {
                return null;
            }

        }
        public static ExchangeRate MapExchangeRateDto(this ExchangeRateDto exchangeRateDto)
        {
            try
            {
                return new ExchangeRate
                {
                    CurrencyName = exchangeRateDto.CurrencyName,
                    BaseCurrencyName = exchangeRateDto.BaseCurrencyName,
                    Amount = exchangeRateDto.Amount
                };
            }
            catch
            {
                return null;
            }

        }
    }
}
