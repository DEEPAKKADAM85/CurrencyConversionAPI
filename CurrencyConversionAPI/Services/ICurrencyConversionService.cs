using CurrencyConversionAPI.Models;

namespace CurrencyConversionAPI.Services
{
    public interface ICurrencyConversionService
    {
        CurrencyConversionResponse PerformCurrencyConversion(CurrencyConversionRequest currencyConversionRequest);

        CurrencyConversionResponse PerformCurrencyConversionWithDbContext(CurrencyConversionRequest currencyConversionRequest);
    }
}
