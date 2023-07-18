using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCDemo.DBModel
{
    public class Userss
    {
        [Key]
        public int Id { get; set; }

        [Column("Email")]
        [MaxLength(100)]
        public string Email { get; set; }

        [Column("Password")]
        [MaxLength(50)]
        public string Password { get; set; }
    }

    public class MyDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=dotnet;uid=root;pwd=Admin@123;"); //table name
        }
        public DbSet<Userss> Userss { get; set; }
    }
}
