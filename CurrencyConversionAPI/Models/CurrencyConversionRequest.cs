namespace CurrencyConversionAPI.Models
{
    public class CurrencyConversionRequest
    {
        public string from_currency { get; set; }
        public double from_currency_amount { get; set; }
        public string to_currency { get; set; }
    }
}
