using Ecommerce.Data.Builders;
using Ecommerce.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Ecommerce.Data
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {

        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // builder'ları çağır
            new ProductBuilder(modelBuilder.Entity<Product>());
            new CategoryBuilder(modelBuilder.Entity<Category>());
        }
    }
}
