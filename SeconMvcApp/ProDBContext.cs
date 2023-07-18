using Microsoft.EntityFrameworkCore;
using SeconMvcApp.Models;
using System.Collections.Generic;


namespace SeconMvcApp
{
    public class ProDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string con = "server=localhost;port=3306;database=dotnet;uid=root;pwd=Admin@123;";
            optionsBuilder.UseMySql(con, ServerVersion.AutoDetect(con));
        }
        public DbSet<UserDBModel> Users { get; set; }//what table you are going to use

    }
}
