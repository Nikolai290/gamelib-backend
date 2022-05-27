using gamelib_backend.Domain.Interfaces.Repositories;
using gamelib_backend.Infrastructure.Domain.Repositories;

namespace gamelib_backend.IoC {
    public static class RepositoryModule {
        public static void ConfigureRepository(this IServiceCollection services) {
            services.AddScoped<ICompanyRepository, CompanyRepository>();
        }
    }
}
