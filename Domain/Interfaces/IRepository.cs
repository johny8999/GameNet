﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
      DbSet<TEntity> DbEntities { get; }

      IQueryable<TEntity> Get { get; }
      IQueryable<TEntity> GetNoTraking { get; }

      Task AddAsync(TEntity entity, bool AutoSave = true);
      Task AddRangeAsync(IEnumerable<TEntity> entities, bool AutoSave = true);

      Task DeleteAsync(TEntity entity, bool AutoSave = true);
      Task DeleteRangeAsync(IEnumerable<TEntity> entities, bool AutoSave = true);

      Task UpdateAsync(TEntity entity, bool AutoSave = true);
      Task UpdateRangeAsync(IEnumerable<TEntity> entities, bool AutoSave = true);

      Task<TEntity> GetById(params object[] Id);

      Task<int> SaveChangeAsync();
    }

}
