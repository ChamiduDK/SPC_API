using Microsoft.EntityFrameworkCore;
using SPC_API.Model;



namespace SPC_API.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        //For each of the model add a DB list
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Tender> Tenders { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<SpcTenderAd> SpcTenderAds { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drug>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<Tender>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Total).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<Supplier>();
            modelBuilder.Entity<Staff>();
            modelBuilder.Entity<Pharmacy>();
            modelBuilder.Entity<SpcTenderAd>();
            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = "";
            optionsBuilder.UseSqlServer(connection);
        }
    }
}
