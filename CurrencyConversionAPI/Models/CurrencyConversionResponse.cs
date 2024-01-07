namespace CurrencyConversionAPI.Models
{
    public class CurrencyConversionResponse
    {
        public string from_currency { get; set; }
        public double from_currency_amount { get; set; }
        public string to_currency { get; set; }
        public double to_currency_amount { get; set; }
        public double conversion_rate { get; set; }
    }
}
