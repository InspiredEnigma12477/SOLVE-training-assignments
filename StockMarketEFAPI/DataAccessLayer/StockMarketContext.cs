using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;
using StockMarketEFAPI.Models;

namespace StockMarketEFAPI.DataAccessLayer
{
    public class StockMarketContext : DbContext
    {
        string connectionString = "server=localhost;user=root;password=1234567890;database=SolveStockMarket";
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<StockPrice> StockPrice { get; set; }

        public StockMarketContext() : base() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(@"server=localhost;database=SolveStockMarket;uid=root;password=1234567890;",
                mysqlOptions =>
                {
                    mysqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);                                                                     // Additional configuration options...
                });
        }

        protected override void OnModelCreating(ModelBuilder optionsBuilder)
        {
            //optionsBuilder.UseMySql(connectionString);
        }
    }
}