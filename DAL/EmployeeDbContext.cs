using employeedata.Models.DBEntities;
using Microsoft.EntityFrameworkCore;

namespace employeedata.DAL
{
    public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext(DbContextOptions options): base(options) 
        { 

        }

        public DbSet<Employee> Employees { get; set; }


    }
}
