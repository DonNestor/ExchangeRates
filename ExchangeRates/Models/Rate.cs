using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRates.Models
{
    public class Rate
    {
        public int Id { get; set; }
        public string Currency { get; set; }
        public string Code { get; set; }
        public double Mid { get; set; }
    }
}
