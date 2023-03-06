using Microsoft.EntityFrameworkCore;
using MyProductList.Data.Models;
using System.Reflection;

namespace MyProductList.Data.DBOperations
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ShopList> ShopLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductCategory>()
              .HasOne(c => c.Product)
              .WithMany(cp => cp.Product_Categories)
              .HasForeignKey(ci => ci.ProductId);

            modelBuilder.Entity<ProductCategory>()
              .HasOne(c => c.Category)
              .WithMany(cp => cp.Product_Categories)
              .HasForeignKey(ci => ci.CategoryId);

            modelBuilder.Entity<ShopListProducts>()
               .HasOne(c => c.Product)
               .WithMany(cp => cp.ShopList_Products)
               .HasForeignKey(ci => ci.ProductId);

            modelBuilder.Entity<ShopListProducts>()
              .HasOne(c => c.ShopList)
              .WithMany(cp => cp.ShopList_Products)
              .HasForeignKey(ci => ci.ShopListId);
        }
    }
}