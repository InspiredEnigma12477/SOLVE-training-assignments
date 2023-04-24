using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using StockMarket.Models;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace StockMarket.DataAccessLayer
{
    public class StockMarketContext : DbContext
    {
        string connectionString = "server=localhost;user=root;password=1234567890;database=mydatabase";
        public DbSet<Stock> Stocks { get; set; }

        public StockMarketContext() : base() { }
        public StockMarketContext(DbContextOptions<StockMarketContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString);
        }
    }
}