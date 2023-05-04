using Microsoft.EntityFrameworkCore;
using StockMarketAPI.Models;

namespace StockMarketAPI.DataAccessLayer
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
            //optionsBuilder.UseMySql(connectionString);
        }
    }
}