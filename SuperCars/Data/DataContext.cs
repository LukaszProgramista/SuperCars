using Microsoft.EntityFrameworkCore;
using SuperCarAPI.Models;

namespace SuperCarAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=supercarsdb;Trusted_Connection=true;TrustServerCertificate=true;");
        }

        public DbSet<SuperCar> SuperCars { get; set; }

    }
}
