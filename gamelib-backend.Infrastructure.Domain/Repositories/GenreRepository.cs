using gamelib_backend.Domain.Core.DbEntities;
using gamelib_backend.Domain.Interfaces;
using gamelib_backend.Domain.Interfaces.Repositories;

namespace gamelib_backend.Infrastructure.Domain.Repositories {
    public class GenreRepository : BaseCrudRepository<Genre, int>, IGenreRepository {
        public GenreRepository(IDbContext dbContext) : base(dbContext) {
        }
    }
}
