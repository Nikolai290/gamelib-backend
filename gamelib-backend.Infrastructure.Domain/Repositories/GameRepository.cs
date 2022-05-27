using gamelib_backend.Domain.Core.DbEntities;
using gamelib_backend.Domain.Interfaces.Repositories;
using gamelib_backend.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamelib_backend.Infrastructure.Domain.Repositories {
    public class GameRepository : BaseCrudRepository<Game, int>, IGameRepository {
        public GameRepository(IDbContext dbContext) : base(dbContext) {
        }
    }
}
