using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem
{
    public class EmployeeDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string con = "server=localhost;database=employee_0016;uid=root;pwd=Admin@123;";
            optionsBuilder.UseMySQL(con);
        }
        public DbSet<Employee> Employee { get; set; }
    }
}