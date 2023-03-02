using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using SystemGlobalServices.Models;
using SystemGlobalServices.Services;
using SystemGlobalServices.Helpers;

namespace SystemGlobalServices.Controllers
{
    [ApiController]
    public class CurrencyController : Controller
    {
        ILogger<CurrencyController> _logger;

        ICurrencyService _currencyService; 

        public CurrencyController(ILogger<CurrencyController> logger, ICurrencyService currencyService)
        {
            _logger = logger;

            _currencyService = currencyService;
        }

        [Route("/Currencies")]
        [HttpGet]
        public async Task<ActionResult<PaginationList<Currency>>> GetCurrencies([FromQuery] CurrencyPaginationSettings paginationSettings) 
        {
            var currencies = await _currencyService.GetCurrencies(paginationSettings);

            _logger.LogInformation("Get " + currencies.Count + "currenies at " + DateTime.Now);

            return currencies;
        }

        [Route("/Currency")]
        [HttpGet]
        public async Task<ActionResult<Currency>> GetCurrency(string id)
        {
            var currency = await _currencyService.GetCurrency(id);

            _logger.LogInformation("Get currency with ID: " + currency.Id + " at " + DateTime.Now);

            return currency;
        }
    }
}

