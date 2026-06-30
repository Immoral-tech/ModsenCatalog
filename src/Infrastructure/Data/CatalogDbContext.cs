using Microsoft.EntityFrameworkCore;
using ModsenCatalog.src.Domain.Entities;

namespace ModsenCatalog.src.Infrastructure.Data
{
    public class CatalogDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<PriceHistory> PriceHistories { get; set; }

        public CatalogDbContext(DbContextOptions<CatalogDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // USER
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.HasIndex(u => u.Username).IsUnique();
                entity.HasIndex(u => u.Email).IsUnique();
                entity.Property(u => u.Username).IsRequired().HasMaxLength(100);
                entity.Property(u => u.Email).IsRequired().HasMaxLength(255);
                entity.Property(u => u.PasswordHash).IsRequired();
                entity.Property(u => u.Role).HasConversion<int>();
                entity.HasQueryFilter(u => !u.IsDeleted);
            });

            // CATEGORY
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.HasIndex(c => c.Name).IsUnique();
                entity.Property(c => c.Name).IsRequired().HasMaxLength(100);
                entity.Property(c => c.Description).HasMaxLength(500);
            });

            // PRODUCT
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name).IsRequired().HasMaxLength(200);
                entity.Property(p => p.Description).HasMaxLength(1000);
                entity.Property(p => p.Price).HasColumnType("decimal(18,2)");
                entity.Property(p => p.AverageRating).HasColumnType("decimal(3,2)");
                entity.HasQueryFilter(p => !p.IsDeleted);

                entity.HasOne(p => p.Category)
                    .WithMany(c => c.Products)
                    .HasForeignKey(p => p.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // REVIEW
            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(r => r.Id);
                entity.Property(r => r.Rating).IsRequired();
                entity.Property(r => r.Comment).HasMaxLength(1000);

                entity.HasOne(r => r.User)
                    .WithMany(u => u.Reviews)
                    .HasForeignKey(r => r.UserId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(r => r.Product)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(r => r.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(r => new { r.UserId, r.ProductId }).IsUnique();
            });

            // PRICE HISTORY
            modelBuilder.Entity<PriceHistory>(entity =>
            {
                entity.HasKey(ph => ph.Id);
                entity.Property(ph => ph.OldPrice).HasColumnType("decimal(18,2)");
                entity.Property(ph => ph.NewPrice).HasColumnType("decimal(18,2)");
                entity.Property(ph => ph.ChangedAt).IsRequired();

                entity.HasOne(ph => ph.Product)
                    .WithMany(p => p.PriceHistories)
                    .HasForeignKey(ph => ph.ProductId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}