using OnionArch.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.Application.Repositories
{
    public interface IWriteRepository<TEntity> : IRespositoryBase<TEntity>
        where TEntity : BaseEntity
    {
        Task<bool> AddAsync(TEntity entity);
        Task<bool> AddRangeAsync(List<TEntity> entities);
        bool Remove(TEntity entity);
        bool RemoveRange(List<TEntity> entities);
        Task<bool> RemoveByIdAsync(string id);
        bool Update(TEntity entity);

        Task<int> SaveChangesAsync();
    }
}
