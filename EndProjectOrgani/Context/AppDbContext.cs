using System;
using EndProjectOrgani.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EndProjectOrgani.Context
{
    public class AppDbContext:IdentityDbContext<AppUser,AppRole,int>
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogDetail> BlogDetails { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<SaleOff> SaleOffs { get; set; }
        public DbSet<SaleOffDetail> SaleOffDetails { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Advert> Adverts { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Contact> Contacts { get; set; }






    }
}
