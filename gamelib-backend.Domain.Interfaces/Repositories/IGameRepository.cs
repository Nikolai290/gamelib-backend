using gamelib_backend.Domain.Core.DbEntities;

namespace gamelib_backend.Domain.Interfaces.Repositories {
    public interface IGameRepository : IBaseCrudRepository<Game, int>{
    }
}
