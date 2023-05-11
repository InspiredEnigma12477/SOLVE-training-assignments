using Microsoft.EntityFrameworkCore;

namespace VechileMS
{
    public class VechileContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=SolveTraining;user=root;password=1234567890;");
        }
        public DbSet<Vehicle> Vehicles {get; set; }
        
    }
}
