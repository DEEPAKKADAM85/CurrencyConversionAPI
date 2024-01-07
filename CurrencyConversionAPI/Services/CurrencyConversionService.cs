using CurrencyConversionAPI.Models;

namespace CurrencyConversionAPI.Services
{
    public class CurrencyConversionService : ICurrencyConversionService
    {
        private readonly CurrencyContext _dbContext;

        public CurrencyConversionService(CurrencyContext dbContext)
        {
            _dbContext = dbContext;
        }
        public CurrencyConversionResponse PerformCurrencyConversion(CurrencyConversionRequest currencyConversionRequest)
        {
            CurrencyConversionResponse currencyConversionResponse = null;
            var lstCurrency = CurrencyData.GetCurrencies();

            if (lstCurrency != null)
            {
                var currency = lstCurrency.Where(x => x.FromCurrency == currencyConversionRequest.from_currency && x.ToCurrency == currencyConversionRequest.to_currency).FirstOrDefault();
                if (currency != null)
                {
                    currencyConversionResponse = new CurrencyConversionResponse()
                    {
                        from_currency = currency.FromCurrency,
                        from_currency_amount = currencyConversionRequest.from_currency_amount,
                        to_currency = currency.ToCurrency,
                        to_currency_amount = (currencyConversionRequest.from_currency_amount * currency.ConversionRate),
                        conversion_rate = currency.ConversionRate
                    };
                }
            }
            return currencyConversionResponse;
        }

        public CurrencyConversionResponse PerformCurrencyConversionWithDbContext(CurrencyConversionRequest currencyConversionRequest)
        {
            CurrencyConversionResponse currencyConversionResponse = null;

            var currency = _dbContext.Currencies.Where(x => x.FromCurrency == currencyConversionRequest.from_currency && x.ToCurrency == currencyConversionRequest.to_currency).FirstOrDefault();
            if (currency != null)
            {
                currencyConversionResponse = new CurrencyConversionResponse()
                {
                    from_currency = currency.FromCurrency,
                    from_currency_amount = currencyConversionRequest.from_currency_amount,
                    to_currency = currency.ToCurrency,
                    to_currency_amount = (currencyConversionRequest.from_currency_amount * currency.ConversionRate),
                    conversion_rate = currency.ConversionRate
                };
            }
            return currencyConversionResponse;
        }
    }
}
