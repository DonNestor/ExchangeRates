using ExchangeRates.Models;
using System;

namespace ExchangeRates.Interfaces
{
    public interface IExchangeRatesService
    {
        Root GetExchangeRatesFromHttp();

    }
}