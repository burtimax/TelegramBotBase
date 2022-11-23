using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BotApplication.Bot.Db.DbBot;

namespace BotApplication.BotStore.Interfaces.IRepositories
{
    public interface ISantaBaseRepository<TEntity> where TEntity : class, IBaseEntity<long>
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IReadOnlyList<TEntity>> ListAllAsync();
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<int> CountAllAsync();
        Task<List<TEntity>> GetAsNoTrackingAsync(Func<TEntity, bool> predicate);
        Task<IEnumerable<TEntity>> GetAsync(Func<TEntity, bool> predicate);
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
    }
    
}