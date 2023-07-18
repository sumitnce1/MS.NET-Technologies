using Microsoft.EntityFrameworkCore;
using TestApplicationAPI;

namespace AdmissionApps
{
    public class AdmissionDbContext : DbContext
    {
        public AdmissionDbContext(DbContextOptions<AdmissionDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string con = "server=localhost;database=admissiondb;uid=root;pwd=Admin@123;";
                optionsBuilder.UseMySQL(con);
            }
        }

        public DbSet<UsersViewModel> Users { get; set; }
    }
}
