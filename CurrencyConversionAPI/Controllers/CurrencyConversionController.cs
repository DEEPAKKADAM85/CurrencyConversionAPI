using CurrencyConversionAPI.Models;
using CurrencyConversionAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyConversionAPI.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class CurrencyConversionController : ControllerBase
    {
        private readonly ICurrencyConversionService _CurrencyConversionService;

        public CurrencyConversionController(ICurrencyConversionService CurrencyConversionService)
        {
            _CurrencyConversionService = CurrencyConversionService;
        }

        //https://localhost:7014/INR/100/USD

        [HttpGet]
        [Route("{from_currency}/{from_currency_amount}/{to_currency}")]
        public IActionResult Index(string from_currency, double from_currency_amount, string to_currency)
        {
            CurrencyConversionRequest request = new CurrencyConversionRequest
            {
                from_currency = from_currency,
                from_currency_amount = from_currency_amount,
                to_currency = to_currency
            };

            // Using json file currency data, static method to load currency data
            CurrencyConversionResponse response = _CurrencyConversionService.PerformCurrencyConversion(request);

            // Using Database currency table to load currency data and EntityFrameWork DbContext object
            // CurrencyConversionResponse response = _CurrencyConversionService.PerformCurrencyConversionWithDbContext(request);

            if (response == null)
            {
                return new JsonResult($"No currency conversion rate available from {from_currency} to {to_currency} in database.");
            }
            return new JsonResult(response);
        }
    }
}
