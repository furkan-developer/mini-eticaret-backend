using Microsoft.EntityFrameworkCore;
using OnionArch.Application.Repositories;
using OnionArch.Domain.Entities.Common;
using OnionArch.Persistence.Contexts.MsSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.Persistence.Repositories
{
    internal class ReadRepository<TEntity> : IReadRepository<TEntity>
        where TEntity : BaseEntity
    {
        private readonly ECommerceDbContext _dbContext;

        public ReadRepository(ECommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<TEntity> Table => _dbContext.Set<TEntity>();

        public IQueryable<TEntity> GetAll() 
            => Table.AsQueryable();

        public IQueryable<TEntity> GetAllByCondition(Expression<Func<TEntity, bool>> filter)
            => Table.Where(filter);

        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter)
            => await Table.FirstOrDefaultAsync(filter);

        public Task<TEntity> GetByIdAsync(string id)
            => Table.FirstOrDefaultAsync(entity => entity.Id == Guid.Parse(id));        
    }
}
