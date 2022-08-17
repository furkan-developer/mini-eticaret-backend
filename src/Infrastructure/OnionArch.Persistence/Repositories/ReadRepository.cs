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

        public IQueryable<TEntity> GetAll(bool canTrackChangeOnData = true)
        {
            var data = Table.AsQueryable();
            if (!canTrackChangeOnData)
                data = data.AsNoTracking();
            return data;
        }
        public IQueryable<TEntity> GetAllByCondition(Expression<Func<TEntity, bool>> filter, bool canTrackChangeOnData = true)       
        {
            var data = Table.AsQueryable();
            if (!canTrackChangeOnData)
                data = data.AsNoTracking();
            return data.Where(filter);
        }
        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter, bool canTrackChangeOnData = true)
        {
            var data = Table.AsQueryable();
            if (!canTrackChangeOnData)
                data = data.AsNoTracking();
            return await data.SingleOrDefaultAsync(filter);
        }
        public async Task<TEntity> GetByIdAsync(Guid id, bool canTrackChangeOnData = true)
        {
            return await GetSingleAsync(e => e.Id == id, canTrackChangeOnData);
        }         
        public IQueryable<TEntity> CheckTracking(IQueryable<TEntity> data, bool canTrackChangeOnData)
        {
            if (!canTrackChangeOnData) data.AsNoTracking();
            return data;
        }
    }
}
