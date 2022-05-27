using gamelib_backend.Domain.Core.DbEntities;

namespace gamelib_backend.Domain.Interfaces.Repositories {
    public interface IBaseCrudRepository<TEntity, TId> where TEntity : DbEntity<TId> {
        public Task<TEntity> GetByIdAsync(TId id);
        public Task<IList<TEntity>> GetAllAsync();
        public Task CreateAsync(TEntity entity);
        public Task CreateRangeAsync(IEnumerable<TEntity> entities);
        public Task UpdateAsync(TEntity entity);
        public Task UpdateRangeAsync(IEnumerable<TEntity> entities);
        public Task DeleteAsync(TId id);
    }
}
