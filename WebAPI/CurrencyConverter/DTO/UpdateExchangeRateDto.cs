namespace CurrencyConverter.DTO
{
    public class UpdateExchangeRateDto
    {
        public string BaseCurrencyName { get; set; }
        public string CurrencyName { get; set; }
        public double Amount { get; set; }
    }
}
