using NLog;
using NLog.Web;
using Microsoft.EntityFrameworkCore;
using FishingBattle.Anglers.Service.DB;
using FishingBattle.Anglers.Service.Interfaces;
using FishingBattle.Anglers.Service.Repositories;
using FishingBattle.Anglers.Service.MappingProfiles;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();

    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    builder.Host.UseNLog();

    builder.Services.AddSwaggerGen();

    builder.Services.AddDbContext<AnglerDbContext>(op => op.UseInMemoryDatabase("Anglers"));
    builder.Services.AddAutoMapper(typeof(AnglerProfile));
    builder.Services.AddScoped<IAnglerRepository, AnglerRepository>();

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AnglersApi v1"));
    }

    // Configure the HTTP request pipeline.

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    // NLog: catch setup errors
    logger.Error(ex, "Stopped program because of exception");
    throw;
}
finally
{ 
    NLog.LogManager.Shutdown();
}
