using Microsoft.EntityFrameworkCore;
using OnionArch.Application.Repositories;
using OnionArch.Domain.Entities;
using OnionArch.Persistence.Contexts.MsSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.Persistence.Repositories
{
    internal class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        public ProductReadRepository(ECommerceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
