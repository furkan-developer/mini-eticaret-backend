using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OnionArch.Application.Repositories;
using OnionArch.Domain.Entities.Common;
using OnionArch.Persistence.Contexts.MsSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.Persistence.Repositories
{
    public class WriteRepository<TEntity> : IWriteRepository<TEntity>
        where TEntity : BaseEntity
    {
        private readonly ECommerceDbContext _dbContext;

        public WriteRepository(ECommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<TEntity> Table
            => _dbContext.Set<TEntity>();

        public async Task<bool> AddAsync(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry = await Table.AddAsync(entity);
            bool IsAdd = entityEntry.State == EntityState.Added ? true : false;
            return IsAdd;
        }

        public async Task<bool> AddRangeAsync(List<TEntity> entities)
        {
            await Table.AddRangeAsync(entities);
            return true;
        }

        public bool Remove(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry =  Table.Remove(entity);
            bool IsRemove = entityEntry.State.Equals(EntityState.Deleted);
            return IsRemove;
        }

        public bool RemoveRange(List<TEntity> entities)
        {
            Table.RemoveRange(entities);
            return true;
        }

        public async Task<bool> RemoveByIdAsync(string id)
        {
            TEntity entity = await Table.FirstOrDefaultAsync(entity => entity.Id == Guid.Parse(id));
            bool IsRemove =  Remove(entity);
            return IsRemove;
        }

        public bool Update(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry = Table.Update(entity);
            bool IsUpdate = entityEntry.State.Equals(EntityState.Modified);
            return IsUpdate;
        }

        public async Task<int> SaveChangesAsync()
        {
            int result = await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}
