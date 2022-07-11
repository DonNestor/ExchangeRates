using ExchangeRates.Interfaces;
using ExchangeRates.Iterfaces;
using ExchangeRates.Models;
using ExchangeRates.OutsideEndpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRates.Services
{
    public class ExchangeRatesService : IExchangeRatesService
    {
        private readonly IRepositoryExchangeRates _repositoryExchangeRates;

        public ExchangeRatesService(IRepositoryExchangeRates repositoryExchangeRates)
        {
            _repositoryExchangeRates = repositoryExchangeRates;
        }


        /// <summary>
        /// Get the latest exchange rates
        /// </summary>
        /// <returns></returns>
        public Root GetExchangeRatesFromHttp()
        {
           
            HttpGrabber http = new HttpGrabber();
            var response = http.GetExchangeRates();

            //Check the current date
            var isCurrent = _repositoryExchangeRates.CheckEffectiveDate(response.Result.EffectiveDate);

            if(isCurrent)
            {
                _repositoryExchangeRates.SaveExchangeRates(response.Result);
            }

            var result = GetExchangeRatesFromDB();

            return result;
        }

        private Root GetExchangeRatesFromDB()
        {
            var result = _repositoryExchangeRates.GetExchangeRatesDB();
            return result;
        }
    }
}
