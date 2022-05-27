using gamelib_backend.Domain.Core.DbEntities;
using gamelib_backend.Domain.Interfaces;
using gamelib_backend.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace gamelib_backend.Infrastructure.Domain.Repositories {
    public class BaseCrudRepository<TEntity, TId> : IBaseCrudRepository<TEntity, TId> where TEntity : DbEntity<TId> {

        protected readonly IDbContext dbContext;
        private readonly DbContext _dbContext;

        public BaseCrudRepository(IDbContext dbContext) {
            this.dbContext = dbContext;
            this._dbContext = (DbContext)dbContext;
        }

        public async Task CreateAsync(TEntity entity) {
            await _dbContext
                .Set<TEntity>()
                .AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateRangeAsync(IEnumerable<TEntity> entities) {
            await _dbContext
                .Set<TEntity>()
                .AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TId id) {
            var entity = await GetByIdAsync(id);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IList<TEntity>> GetAllAsync() {
            var entities = await _dbContext.Set<TEntity>().ToListAsync();
            return entities;
        }

        public async Task<TEntity> GetByIdAsync(TId id) {
            var entity = await _dbContext
               .Set<TEntity>()
               .Where(x => !x.IsDeleted)
               .SingleAsync(x => x.Id.Equals(id));
            return entity;
        }

        public async Task UpdateAsync(TEntity entity) {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateRangeAsync(IEnumerable<TEntity> entities) {
            _dbContext
                .Set<TEntity>()
                .UpdateRange(entities);
            await _dbContext.SaveChangesAsync();
        }
    }
}
