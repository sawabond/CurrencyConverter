namespace CurrencyConverter.DTO
{
    public class AddExchangeRateDto
    {
        public string BaseCurrencyName { get; set; }
        public string CurrencyName { get; set; }
        public double Amount { get; set; }
    }
}