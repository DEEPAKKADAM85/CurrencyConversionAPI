using Newtonsoft.Json;

namespace CurrencyConversionAPI.Models
{
    public class CurrencyData : Currency
    {
        //Static method to get Currency Data
        public static List<Currency> GetCurrencies()
        {
            // Hard coded currency data

            //List<Currency> Currencies = new List<Currency>();
            //Currencies.Add(new Currency { ID = 1, FromCurrency = "USD", ToCurrency = "INR", ConversionRate = 82.34 });
            //Currencies.Add(new Currency { ID = 2, FromCurrency = "GBP", ToCurrency = "USD", ConversionRate = 1.28 });
            //return Currencies;

            string json = File.ReadAllText("CurrencyData.json"); // reading currency data from Json file
            List<Currency> currencies = JsonConvert.DeserializeObject<List<Currency>>(json);
            return currencies;
        }
    }
}
