using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using admin.Models;
using Microsoft.AspNetCore.Identity;

namespace admin.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Category> Categories { get; set; }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 

            // relations and behaviours
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category) // En produkt har en kategori
                .WithMany(c => c.Products) // En kategori har många produkter
                .HasForeignKey(p => p.CategoryId) // ForeignKey i Product-tabellen för Category
                .OnDelete(DeleteBehavior.Restrict); // Förhindra radering av kategori om produkter finns

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Seller) // En produkt har en säljare
                .WithMany(s => s.Products) // En säljare har många produkter
                .HasForeignKey(p => p.SellerId) // ForeignKey i Product-tabellen för Seller
                .OnDelete(DeleteBehavior.Restrict); // Förhindra radering av säljare om produkter finns

            
        }*/
    }
}


