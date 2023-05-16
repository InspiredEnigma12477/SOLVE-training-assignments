using Microsoft.EntityFrameworkCore;
using System.Xml;
using VechileMS.Models;

namespace VechileMS.DataAcessLogic
{
    public class VechileContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=localhost;Database=SolveTraining;user=root;password=1234567890;");
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=SolveTraining;Trusted_Connection=True;MultipleActiveResultSets=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DealerVehicle>()
                .HasMany(dv => dv.Notes)
                .WithOne()
                .HasForeignKey(n => n.Id);

           /* modelBuilder.Entity<Note>()
                .HasOne(n => n.Id)
                .WithMany(dv => dv.Notes)
                .HasForeignKey(n => n.DealerVehicleId);*/
        }



        public DbSet<DealerVehicle> Vehicles { get; set; }
        //public DbSet<string> Notes { get; set; }

    }
}
