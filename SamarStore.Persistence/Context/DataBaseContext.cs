using Microsoft.EntityFrameworkCore;
using SamarStore.Application.Interfaces.Context;
using SamarStore.Common.Roles;
using SamarStore.Domain.Entities.Carts;
using SamarStore.Domain.Entities.Finances;
using SamarStore.Domain.Entities.HomePage;
using SamarStore.Domain.Entities.Products;
using SamarStore.Domain.Entities.Users;
using SamarStore.Persistence.Context.EntityConfigurations;

namespace SamarStore.Persistence.Context
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions opetions) : base (opetions)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }
        public DbSet<ProductFeatures> ProductFeatures { get; set; }
        public DbSet<UserInRole> UserInRoles { get; set; }  
        public DbSet<Slider> Slider { get; set; }  
        public DbSet<HomePageImages> HomePageImages { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<RequestPay> RequestPay { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //--Seed Data
            AddData.SeedData(modelBuilder);

            //--Apply Index On Email
            //--Emails cant be Duplicate 
            ApplyIndex.HasIndex(modelBuilder);  
            
            //--Not Showing Deleted Data
            QueryFilter.ApplyQueryFilter(modelBuilder); 
        }

    }
}
