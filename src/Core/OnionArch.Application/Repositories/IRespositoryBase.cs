using Microsoft.EntityFrameworkCore;
using OnionArch.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArch.Application.Repositories
{
    public interface IRespositoryBase<TEntity>
        where TEntity : BaseEntity
    {
        DbSet<TEntity> Table { get; }
    }
}
