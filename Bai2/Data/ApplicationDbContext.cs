using Bai2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bai2.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Laptop", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Điện thoại", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Máy tính", DisplayOrder = 3 }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Iphone 7", Price = 300, CategoryId = 1 },
                new Product { Id = 2, Name = "Iphone 7s", Price = 350, CategoryId = 1 },
                new Product { Id = 3, Name = "Iphone 8", Price = 400, CategoryId = 1 },
                new Product { Id = 4, Name = "Iphone 8s", Price = 420, CategoryId = 1 },
                new Product { Id = 5, Name = "Iphone 11", Price = 600, CategoryId = 1 },
                new Product { Id = 6, Name = "Iphone 11s", Price = 650, CategoryId = 1 },
                new Product { Id = 7, Name = "Iphone 13", Price = 700, CategoryId = 1 },
                new Product { Id = 8, Name = "Iphone 13 Pro", Price = 850, CategoryId = 1 },
                new Product { Id = 9, Name = "Iphone 14", Price = 900, CategoryId = 1 },
                new Product { Id = 10, Name = "Iphone 14 Pro Max ", Price = 1000, CategoryId = 1 },
                new Product { Id = 11, Name = "Ipad Mini", Price = 350, CategoryId = 2 },
                new Product { Id = 12, Name = "Ipad Pro", Price = 550, CategoryId = 2 });
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
