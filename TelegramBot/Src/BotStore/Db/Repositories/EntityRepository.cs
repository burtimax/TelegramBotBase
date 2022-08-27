using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BotApplication.Bot.Db.DbBot;
using BotApplication.BotStore.Db.Context;
using BotApplication.BotStore.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace BotApplication.BotStore.Db.Repositories
{
    public class SantaBaseRepository<TEntity> : ISantaBaseRepository<TEntity>
        where TEntity : class, IBaseEntity<long>
    {
        protected readonly StoreContext _db;
        private readonly DbSet<TEntity> _dbSet;

        public SantaBaseRepository(StoreContext db)
        {
            _db = db;
            _dbSet = _db.Set<TEntity>();
        }


        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IReadOnlyList<TEntity>> ListAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<int> CountAllAsync()
        {
            return await _dbSet.CountAsync();
        }

        public async Task<List<TEntity>> GetAsNoTrackingAsync(Func<TEntity, bool> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).AsQueryable().ToListAsync();
        }

        public Task<IEnumerable<TEntity>> GetAsync(Func<TEntity, bool> predicate)
        {
            return Task.FromResult(_dbSet.Where(predicate));
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _db.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            await _db.SaveChangesAsync();
        }
        
    }
}