using Microsoft.EntityFrameworkCore;
using SamarStore.Application.Interfaces.Context;
using SamarStore.Common.Roles;
using SamarStore.Domain.Entities.Users;

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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role { Id = 1, Name = nameof(UserRoles.Admin) });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 2, Name = nameof(UserRoles.Operator) });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 3, Name = nameof(UserRoles.Customer) });
        }
    }
}
