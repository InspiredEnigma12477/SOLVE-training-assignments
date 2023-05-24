using Microsoft.EntityFrameworkCore;
using VechileMS.Models;

namespace VechileMS.DataAcessLogic
{
    public class VechileContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(@"server=localhost;database=SolveTraining;uid=root;password=1234567890;",
                mysqlOptions =>
                {
                    mysqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);                                                                     // Additional configuration options...
                });
            //optionsBuilder.UseSqlServer(@"Server=localhost:3306;Database=SolveTraining;Trusted_Connection=True;MultipleActiveResultSets=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DealerVehicle>()
                .HasKey(dv => dv.Id);
        }


        public DbSet<DealerVehicle> Vehicles { get; set; }
        public DbSet<Note> Note { get; set; }

    }
}
