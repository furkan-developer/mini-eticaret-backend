using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnionArch.Application.Repositories;
using OnionArch.Persistence.Contexts.MsSql;
using OnionArch.Persistence.Repositories;
using OnionArch.Persistence.Tools;
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
                options.UseSqlServer(Configuration.ConnectionString);                
            });
        }

        public static void ConfigurePersistenceServices(this IServiceCollection services)
        {
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
        }
    }
}
