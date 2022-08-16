using OnionArch.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.Application.Repositories
{
    public interface IReadRepository<TEntity> : IRespositoryBase<TEntity>
        where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAllByCondition(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> GetByIdAsync(string id);
    }
}
