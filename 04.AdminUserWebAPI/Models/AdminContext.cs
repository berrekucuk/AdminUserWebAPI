using Microsoft.EntityFrameworkCore;

namespace _04.AdminUserWebAPI.Models
{
    public class AdminContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-2K18C6FK\SQLEXPRESS01; Database=AdminUserDb; Trusted_Connection=True; TrustServerCertificate=True");
        }

        public DbSet<AdminUser> AdminUsers { get; set; }
    }
}
