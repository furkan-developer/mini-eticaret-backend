using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnionArch.Persistence.Contexts.MsSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.Persistence.Extensions
{
    public  static class PersistenceExtensions
    {
        public static void ConfigureMsSqlServer(this IServiceCollection services)
        {
            services.AddDbContext<ECommerceDbContext>(options =>
            {
                options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ECommerceGY;Trusted_Connection=True;");
            });
        }
    }
}
