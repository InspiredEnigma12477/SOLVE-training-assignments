using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFramework;
using System.Data.Common;
using System.Data.Entity;

namespace EmploeeAPI.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class EmployeeContext : DbContext
    {
        EmployeeContext(DbConnection) : base(options) { }

        public DbSet<Employee> Employees { get; set; }

    }
}
