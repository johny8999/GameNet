using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Models.MainModel;

namespace Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : BaseModel
    {
        Task<bool> AddEntity(TEntity entity);
        Task<bool> AddRangeEntity(List<TEntity> entities, Guid? id = null);
        Task<Guid> AddEntityReturnId(TEntity entity);
        Task<TEntity> GetEntitiesById(Guid entityId, bool noTracking = false,
            params Expression<Func<TEntity, object>>[] includes);
        IQueryable<TEntity> GetEntitiesByQuery(bool noTracking = false,
            params Expression<Func<TEntity, object>>[] includes);
        Task<List<TEntity>> ExecuteRawSqlQuery(string sql, params object[] parameters);

        void RemoveEntity(TEntity entity);
        Task RemoveEntity(Guid entityId);
        Task RemoveRangeEntity(List<TEntity> entities);
        Task HardRemoveEntity(Guid entityId);
        void HardRemoveRangEntity(List<TEntity> entities);
        Task<bool> SaveChanges();
        void UpdateEntity(TEntity entity);
        void UpdateRangeEntity(List<TEntity> entities);
    }

}
