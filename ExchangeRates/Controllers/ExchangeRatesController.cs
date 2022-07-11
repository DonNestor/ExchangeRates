using ExchangeRates.Interfaces;
using ExchangeRates.OutsideEndpoints;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRates.Controllers
{
    public class ExchangeRatesController : Controller
    {
        private readonly IExchangeRatesService _exchangeRate;
        public ExchangeRatesController(IExchangeRatesService exchangeRatesService)
        {
            _exchangeRate = exchangeRatesService;
        }
        public IActionResult Index()
        {
            var result = _exchangeRate.GetExchangeRatesFromHttp();

            return View(result);
        }
    }
}
