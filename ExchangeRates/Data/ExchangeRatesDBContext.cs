using ExchangeRates.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeRates.Data
{
    public class ExchangeRatesDBContext : DbContext
    {
        public ExchangeRatesDBContext(DbContextOptions<ExchangeRatesDBContext> options) : base(options)
        {

        }

        public DbSet<Root> Root { get; set; }
        public DbSet<Rate> Rate { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rate>()
                .Property(r => r.Mid)
                .IsRequired();

            modelBuilder.Entity<Rate>()
                .Property(r => r.Code)
                .IsRequired();

            modelBuilder.Entity<Root>()
                .Property(r => r.EffectiveDate)
                .IsRequired();
        }
    }
}
