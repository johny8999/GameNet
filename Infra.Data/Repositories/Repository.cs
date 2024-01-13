using Domain.Interfaces;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Models.MainModel;

namespace Infra.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseModel
    {
        #region Constructor

        private readonly ApplicationContext _context;
        private readonly DbSet<TEntity> _dbSet;

        #endregion

        public Repository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public IQueryable<TEntity> GetEntitiesByQuery(bool noTracking = false,
            params Expression<Func<TEntity, object>>[] includes
        )
        {
            var query = noTracking == false
                ? _dbSet.AsQueryable()
                : _dbSet.AsQueryable().AsNoTracking();
            return query;
        }

        public async Task<TEntity> GetEntitiesById(Guid id, bool noTracking = false,
            params Expression<Func<TEntity, object>>[] includes)
        {
            var query = noTracking == false
                ? _dbSet.AsQueryable()
                : _dbSet.AsQueryable().AsNoTracking();

            if (includes != null)
                includes.ToList().ForEach(include =>
                {
                    if (include != null)
                        query = query.Include(include);
                });
            return query.FirstOrDefault();
        }

        public async Task<List<TEntity>> ExecuteRawSqlQuery(string sql, params object[] parameters)
        {
            // try
            // {
            //     var result = await _dbSet(sql).ToListAsync();
            //     return result;
            // }
            // catch (Exception ex)
            // {
            //     Console.WriteLine("RawQuery Err:" + ex.ToString());
            //     throw;
            // }
            return default;
        }

        public async Task<bool> AddEntity(TEntity entity)
        {
            try
            {
                // entity.CreatedAt = DateTime.UtcNow;
                // entity.UpdatedAt = entity.CreatedAt;
                //   entity.ID = Guid.NewGuid();
                await _dbSet.AddAsync(entity);
                //    if (entity.Id != Guid.Empty)
                {
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> AddRangeEntity(List<TEntity> entities, Guid? id = null)
        {
            try
            {
                List<TEntity> input = new();
                foreach (var entity in entities)
                {
                    //      entity.CreatedAt = DateTime.UtcNow;
                    //    entity.UpdatedAt = entity.CreatedAt;
                    //       entity.Id = id ?? Guid.NewGuid();
                    input.Add(entity);
                }

                await _dbSet.AddRangeAsync(input);
                //  if (input.Any(a => a.Id != Guid.Empty))
                {
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Guid> AddEntityReturnId(TEntity entity)
        {
            try
            {
                //  entity.CreatedAt = DateTime.UtcNow;
                //  entity.UpdatedAt = entity.CreatedAt;
                //     entity.Id = Guid.NewGuid();
                await _dbSet.AddAsync(entity);
                //     if (entity.Id != Guid.Empty)
                {
                    //       return entity.Id;
                }

                return Guid.Empty;
            }
            catch (Exception)
            {
                return Guid.Empty;
            }
        }

        public void UpdateEntity(TEntity entity)
        {
            // entity.UpdatedAt = DateTime.UtcNow;
            _dbSet.Update(entity);
        }

        public void UpdateRangeEntity(List<TEntity> entities)
        {
            List<TEntity> input = new();
            entities.ForEach((entity) =>
            {
                //   entity.UpdatedAt = DateTime.UtcNow;
                input.Add(entity);
            });
            _dbSet.UpdateRange(input);
        }

        public void RemoveEntity(TEntity entity)
        {
            //  entity.IsDeleted = true;
            UpdateEntity(entity);
        }

        public async Task RemoveRangeEntity(List<TEntity> entities)
        {
            List<TEntity> input = new();
            entities.ForEach((entity) =>
            {
                //    entity.IsDeleted = true;
                input.Add(entity);
            });
            _dbSet.UpdateRange(input);
        }

        public async Task RemoveEntity(Guid entityId)
        {
            var entity = await GetEntitiesById(entityId);
            RemoveEntity(entity);
        }

        public async Task HardRemoveEntity(Guid entityId)
        {
            var entity = await GetEntitiesById(entityId);
            _dbSet.Remove(entity);
        }

        public void HardRemoveRangEntity(List<TEntity> entities)
        {
            List<TEntity> input = new();
            entities.ForEach((entity) =>
            {
                // UpdateEntity(entity);
                input.Add(entity);
            });
            _dbSet.RemoveRange(input);
        }

        public async Task<bool> SaveChanges()
        {
            try
            {
                var res = await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw;
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
