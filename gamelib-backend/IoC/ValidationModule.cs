using FluentValidation;
using gamelib_backend.Business.Dtos;
using gamelib_backend.Infrastructure.Business.Validators;

namespace gamelib_backend.IoC {
    public static class ValidationModule {
        public static IServiceCollection ConfigureValidation(this IServiceCollection services) {
            services.AddScoped<IValidator<CreateGameDto>, CreateGameDtoValidator>();
            services.AddScoped<IValidator<UpdateGameDto>, UpdateGameDtoValidator>();

            services.AddScoped<IValidator<CreateGenreDto>, CreateGenreDtoValidator>();
            services.AddScoped<IValidator<UpdateGenreDto>, UpdateGenreDtoValidator>();

            services.AddScoped<IValidator<CreateCompanyDto>, CreateCompanyDtoValidator>();
            services.AddScoped<IValidator<UpdateCompanyDto>, UpdateCompanyDtoValidator>();

            return services;
        }
    }
}
