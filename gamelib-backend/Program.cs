using gamelib_backend.Domain.Interfaces;
using gamelib_backend.Infrastructure.Business.AutomapperProfiles;
using gamelib_backend.Infrastructure.Domain;
using gamelib_backend.Infrastructure.Domain.DbSettings;
using gamelib_backend.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Settings
var dbSettingSection = builder.Configuration.GetSection("DbSettings");
builder.Services.Configure<PostgresDbSettings>(dbSettingSection);

// IoC
builder.Services.AddDbContext<IDbContext, PostgresDbContext>();
builder.Services.AddAutoMapper(
        typeof(CompanyMappingProfile),
        typeof(GameMappingProfile),
        typeof(GenreMappingProfile)
    );
builder.Services.ConfigureRepository();
builder.Services.ConfigureService();
builder.Services.ConfigureValidation();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
