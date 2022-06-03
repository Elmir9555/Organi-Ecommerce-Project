using System;
using EndProjectOrgani.Entities;
using Microsoft.EntityFrameworkCore;

namespace EndProjectOrgani.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }

    }
}
