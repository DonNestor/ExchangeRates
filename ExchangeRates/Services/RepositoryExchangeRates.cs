using ExchangeRates.Data;
using ExchangeRates.Iterfaces;
using ExchangeRates.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRates.Services
{
    public class RepositoryExchangeRates : IRepositoryExchangeRates
    {
        private readonly ExchangeRatesDBContext _dbContext;
        public RepositoryExchangeRates(ExchangeRatesDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        /// <summary>
        /// Get result from DB
        /// </summary>
        /// <returns></returns>
        public Root GetExchangeRatesDB()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (_dbContext.Root.Any())
                {
                    var ret = _dbContext.Root
                                .Include(r => r.Rates)
                                .OrderBy(r => r.Id)
                                .LastOrDefault();
                    return ret;
                }
            }

            return null;
        }

        /// <summary>
        /// Save to db
        /// </summary>
        /// <param name="rootModel"></param>
        public void SaveExchangeRates(Root rootModel)
        {
            if (_dbContext.Database.CanConnect())
            {
                _dbContext.Root.Add(rootModel);
                _dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Check the current date of exchange rates
        /// </summary>
        /// <param name="effectiveDate"></param>
        /// <returns></returns>
        public bool CheckEffectiveDate(DateTime effectiveDate)
        {
            if (_dbContext.Root.Any())
            {
                var effectiveDateFromDB = _dbContext.Root.OrderBy(r => r.Id).LastOrDefault();
                if (effectiveDateFromDB.EffectiveDate >= effectiveDate)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
