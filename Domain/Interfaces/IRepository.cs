using System.Collections.Generic;
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

      Task AddAsync(TEntity entity, bool autoSave = true);
      Task AddRangeAsync(IEnumerable<TEntity> entities, bool autoSave = true);

      Task DeleteAsync(TEntity entity, bool autoSave = true);
      Task DeleteRangeAsync(IEnumerable<TEntity> entities, bool autoSave = true);

      Task UpdateAsync(TEntity entity, bool autoSave = true);
      Task UpdateRangeAsync(IEnumerable<TEntity> entities, bool autoSave = true);

      Task<TEntity> GetById(params object[] id);

      Task<int> SaveChangeAsync();
    }

}
