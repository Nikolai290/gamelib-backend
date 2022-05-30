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

        public PostgresDbContext() {
            connectionString = "Host=localhost;Port=5435;Database=gamelib;Username=postgres;Password=Gjhyjabkmvs";
        }
        public PostgresDbContext(
            IOptions<PostgresDbSettings> options
        ) {
            this.settings = options.Value;
            connectionString = GetConnectionString();
            Database.Migrate();
            if (Environment.GetEnvironmentVariable("BASE_INIT_DATABASE") == "true") {
                DatabaseInit.Init(this);
            }
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

        private string GetConnectionString() {
            var envHost = Environment.GetEnvironmentVariable("DB_HOST");
            return string.IsNullOrEmpty(envHost)
                ? settings.GetConnectionString()
                : GetConnectionStringFromEnv();
        }

        private static string GetConnectionStringFromEnv() {
            var builder = new List<string>();
            builder.Add("Host=" + Environment.GetEnvironmentVariable("DB_HOST"));
            builder.Add("Port=" + Environment.GetEnvironmentVariable("DB_PORT"));
            builder.Add("Database=" + Environment.GetEnvironmentVariable("DB_NAME"));
            builder.Add("Username=" + Environment.GetEnvironmentVariable("DB_USERNAME"));
            builder.Add("Password=" + Environment.GetEnvironmentVariable("DB_PASSWORD"));

            return string.Join(';', builder);
        }
    }
}
