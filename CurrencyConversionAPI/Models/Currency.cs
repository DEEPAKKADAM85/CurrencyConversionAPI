namespace CurrencyConversionAPI.Models
{
    public class Currency
    {
        public int ID { get; set; }
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
        public double ConversionRate { get; set; }
    }
}
