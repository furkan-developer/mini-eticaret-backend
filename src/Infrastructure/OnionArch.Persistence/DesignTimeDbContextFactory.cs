using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OnionArch.Persistence.Contexts.MsSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ECommerceDbContext>
    {
        public ECommerceDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<ECommerceDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ECommerceGY;Trusted_Connection=True;");
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
