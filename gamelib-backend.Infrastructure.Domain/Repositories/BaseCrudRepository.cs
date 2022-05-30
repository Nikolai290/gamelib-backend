using gamelib_backend.Domain.Core.DbEntities;
using gamelib_backend.Domain.Interfaces;
using gamelib_backend.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace gamelib_backend.Infrastructure.Domain.Repositories {
    public class BaseCrudRepository<TEntity, TId> : IBaseCrudRepository<TEntity, TId> where TEntity : DbEntity<TId> {

        private readonly IDbContext dbContext;
        private readonly DbContext _dbContext;

        public BaseCrudRepository(IDbContext dbContext) {
            this.dbContext = dbContext;
            this._dbContext = (DbContext)dbContext;
        }

        public virtual async Task CreateAsync(TEntity entity) {
            await _dbContext
                .Set<TEntity>()
                .AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task CreateRangeAsync(IEnumerable<TEntity> entities) {
            await _dbContext
                .Set<TEntity>()
                .AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(TId id) {
            var entity = await GetByIdAsync(id);
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<IList<TEntity>> GetAllAsync() {
            var entities = await _dbContext.Set<TEntity>().ToListAsync();
            return entities;
        }

        public virtual async Task<TEntity> GetByIdAsync(TId id) {
            var entity = await _dbContext
               .Set<TEntity>()
               .Where(x => !x.IsDeleted)
               .SingleAsync(x => x.Id.Equals(id));
            return entity;
        }

        public virtual async Task<IList<TEntity>> GetByIdsAsync(TId[] ids) {
            if (ids.Length == 0) {
                return new List<TEntity>();
            }
            var entities = await _dbContext
               .Set<TEntity>()
               .Where(x => !x.IsDeleted)
               .Where(x => ids.Contains(x.Id))
               .ToListAsync();
            return entities;
        }


        public virtual async Task UpdateAsync(TEntity entity) {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task UpdateRangeAsync(IEnumerable<TEntity> entities) {
            _dbContext
                .Set<TEntity>()
                .UpdateRange(entities);
            await _dbContext.SaveChangesAsync();
        }
    }
}
