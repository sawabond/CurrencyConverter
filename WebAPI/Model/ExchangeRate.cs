namespace Model
{
    public class ExchangeRate
    {
        public int Id { get; set; }
        public string BaseCurrencyName { get; set; }
        public string CurrencyName { get; set; }
        public double Amount { get; set; }
    }
}