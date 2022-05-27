using gamelib_backend.Domain.Core.DbEntities;

namespace gamelib_backend.Domain.Interfaces.Repositories {
    public interface IBaseCrudRepository<TEntity, TId> where TEntity : DbEntity<TId> {
        Task<TEntity> GetByIdAsync(TId id);
        Task<IList<TEntity>> GetAllAsync();
        Task CreateAsync(TEntity entity);
        Task CreateRangeAsync(IEnumerable<TEntity> entities);
        Task UpdateAsync(TEntity entity);
        Task UpdateRangeAsync(IEnumerable<TEntity> entities);
        Task DeleteAsync(TId id);
        Task<IList<TEntity>> GetByIdsAsync(TId[] ids);
    }
}
