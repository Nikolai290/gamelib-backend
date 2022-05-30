using gamelib_backend.Business.Interfaces.Services;
using gamelib_backend.Infrastructure.Business.Services;

namespace gamelib_backend.IoC {
    public static class ServiceModule {
        public static IServiceCollection ConfigureService(this IServiceCollection services) {
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IGameService, GameService>();
            return services;
        }
    }
}
