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
        public static ExchangeRate MapFromDto(this ExchangeRate model, UpdateExchangeRateDto updateExchangeRateDto)
        {
            try
            {
                model.CurrencyName = updateExchangeRateDto.CurrencyName;
                model.BaseCurrencyName = updateExchangeRateDto.BaseCurrencyName;
                model.Amount = updateExchangeRateDto.Amount;

                return model;
            }
            catch
            {
                return null;
            }
        }
        public static ExchangeRate MapExchangeRateDto(this AddExchangeRateDto addExchangeRateDto)
        {
            try
            {
                return new ExchangeRate
                {
                    CurrencyName = addExchangeRateDto.CurrencyName,
                    BaseCurrencyName = addExchangeRateDto.BaseCurrencyName,
                    Amount = addExchangeRateDto.Amount
                };
            }
            catch
            {
                return null;
            }
        }
    }
}
