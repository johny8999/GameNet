using Domain.Interfaces;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Data.Repositories
{
  public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
  {
    private readonly MainContext _context;

    public Repository(MainContext context)
    {
      _context = context;
      DbEntities = _context.Set<TEntity>();
    }

    public DbSet<TEntity> DbEntities { get; }

    public IQueryable<TEntity> Get => DbEntities;

    public IQueryable<TEntity> GetNoTraking => DbEntities.AsNoTracking();

    public virtual async Task AddAsync(TEntity entity, bool autoSave = true)
    {
      await DbEntities.AddAsync(entity);

      if (autoSave)
      {
        await _context.SaveChangesAsync();
      }
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities, bool autoSave = true)
    {
      await DbEntities.AddRangeAsync(entities);
      if (autoSave)
      {
        await _context.SaveChangesAsync();
      }
    }

    public async Task DeleteAsync(TEntity entity, bool autoSave = true)
    {
      DbEntities.Remove(entity);
      if (autoSave)
      {
        await _context.SaveChangesAsync();
      }
    }

    public async Task DeleteRangeAsync(IEnumerable<TEntity> entities, bool autoSave = true)
    {
      DbEntities.RemoveRange(entities);
      if (autoSave)
      {
        await _context.SaveChangesAsync();
      }
    }

    public async Task<TEntity> GetById(params object[] id)
    {
      return await DbEntities.FindAsync(id);
    }

    public async Task UpdateAsync(TEntity entity, bool autoSave = true)
    {
      DbEntities.Update(entity);
      if (autoSave)
      {
        await _context.SaveChangesAsync();
      }
    }

    public async Task UpdateRangeAsync(IEnumerable<TEntity> entities, bool autoSave = true)
    {
      DbEntities.UpdateRange(entities);
      if (autoSave)
      {
        await _context.SaveChangesAsync();
      }
    }

    public async Task<int> SaveChangeAsync()
    {
      return await _context.SaveChangesAsync();
    }
  }
}
