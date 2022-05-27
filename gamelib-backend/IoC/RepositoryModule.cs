using gamelib_backend.Domain.Interfaces.Repositories;
using gamelib_backend.Infrastructure.Domain.Repositories;

namespace gamelib_backend.IoC {
    public static class RepositoryModule {
        public static IServiceCollection ConfigureRepository(this IServiceCollection services) {
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            return services;
        }
    }
}
