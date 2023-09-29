using Microsoft.EntityFrameworkCore;
using SamarStore.Application.Interfaces.Context;
using SamarStore.Common.Roles;
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
        public DbSet<UserInRole> UsersInRoles { get; set; }
        public DbSet<Category> Categories { get; set; }


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
