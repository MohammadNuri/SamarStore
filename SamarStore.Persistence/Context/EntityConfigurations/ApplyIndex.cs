using Microsoft.EntityFrameworkCore;
using SamarStore.Application.Services.Common.Queries.GetSlider;
using SamarStore.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamarStore.Persistence.Context.EntityConfigurations
{
    public class ApplyIndex
    {
        public static void HasIndex(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
        }
    }
}
