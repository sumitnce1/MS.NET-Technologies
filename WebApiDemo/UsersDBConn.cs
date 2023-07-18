using Microsoft.EntityFrameworkCore;
using WebApiDemo.Model;

namespace WebApiDemo
{
    public class UsersDBConn : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string con = "server=localhost;database=admissiondb;uid=root;pwd=Admin@123;";
            optionsBuilder.UseMySQL(con);
        }
        public DbSet<Users> Users { get; set; }
    }
}
