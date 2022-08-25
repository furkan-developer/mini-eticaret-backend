using Microsoft.EntityFrameworkCore;
using OnionArch.Domain.Entities;
using OnionArch.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.Persistence.Contexts.MsSql
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions options) : base(options)
        {
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var entity in datas)
            {
                _ = entity.State switch
                {
                    EntityState.Added => entity.Entity.CreateDate = DateTime.Now,
                    EntityState.Modified => entity.Entity.UpdateDate = DateTime.Now
                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
