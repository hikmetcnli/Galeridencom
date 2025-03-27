using Microsoft.EntityFrameworkCore;

namespace Galeriden_com.Models
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=PC-1424;Database=Galeridencom;" +
                "User ID=sa;Password=1;Trusted_Connection=False;TrustServerCertificate=True");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Musteri> Musteri { get; set; }
        public DbSet<Arac> Arac { get; set; }
        public DbSet<SatinAlma> SatinAlma { get; set; }
        public DbSet<Satis> Satis { get; set; }
    }
}
