using gamelib_backend.Domain.Core.DbEntities;
using gamelib_backend.Domain.Interfaces;
using gamelib_backend.Infrastructure.Domain.DbSettings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace gamelib_backend.Infrastructure.Domain {
    public class PostgresDbContext : DbContext, IDbContext {
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected readonly string connectionString;
        protected readonly PostgresDbSettings settings;

        public PostgresDbContext(IOptions<PostgresDbSettings> options) {
            this.settings = options.Value;
            connectionString = settings.GetConnectionString();
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder
                .UseSnakeCaseNamingConvention()
                .UseLazyLoadingProxies()
                .UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
