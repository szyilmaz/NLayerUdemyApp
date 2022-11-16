using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using NLayer.Core.Entities;
using System.Reflection;

namespace NLayer.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }

        public DbSet<Banka> Bankalar { get; set; }
        public DbSet<Sube> Subeler { get; set; }
        public DbSet<Hesap> Hesaplar { get; set; }
        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Hareket> Hareketler { get; set; }
        public DbSet<Lokasyon> Lokasyonlar { get; set; }
        public DbSet<DovizTipi> DovizTipleri { get; set; }
        public DbSet<HareketTipi> HareketTipleri { get; set; }
        public DbSet<HesapTipi> HesapTipleri { get; set; }
        public DbSet<SubeTipi> SubeTipleri { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReference)
                {
                    switch (item.Entity)
                    {
                        case EntityState.Added:
                        {
                            entityReference.CreatedDate = DateTime.Now;
                            break;
                        }
                        case EntityState.Modified:
                        {
                            entityReference.UpdatedDate = DateTime.Now;
                            break;
                        }
                    }
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {

            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReference)
                {
                    switch (item.Entity)
                    {
                        case EntityState.Added:
                            {
                                entityReference.CreatedDate = DateTime.Now;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                entityReference.UpdatedDate = DateTime.Now;
                                break;
                            }
                    }
                }
            }

            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
