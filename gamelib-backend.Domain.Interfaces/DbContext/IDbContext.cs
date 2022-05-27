using gamelib_backend.Domain.Core.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace gamelib_backend.Domain.Interfaces {
    public interface IDbContext {
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Company> Companies { get; set; }

    }
}
