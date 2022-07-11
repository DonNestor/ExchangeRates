using ExchangeRates.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRates.Iterfaces
{
    public interface IRepositoryExchangeRates
    {
        void SaveExchangeRates(Root rootModel);
        bool CheckEffectiveDate(DateTime effectiveDate);
        Root GetExchangeRatesDB();
    }
}
