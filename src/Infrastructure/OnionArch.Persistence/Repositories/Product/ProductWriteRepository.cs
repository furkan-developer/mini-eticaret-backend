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
    public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(ECommerceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
