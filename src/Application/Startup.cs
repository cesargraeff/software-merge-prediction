using MediatR;
using Microsoft.OpenApi.Models;

using Domain.Functionality.Models;
using Infrastructure.PostgreSQL.Context;
using Infrastructure.PostgreSQL.Extensions;
using Infrastructure.PostgreSQL.Initializers;
using GitHub.Services;
using Domain.Services;

public class Startup
{
    private IConfiguration _configuration { get; }
    public Startup(IConfiguration configuration)
        => _configuration = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(typeof(Functionality).Assembly); });
        services.AddPostgreSQL(_configuration);

        services.AddTransient<IGitHubService, GitHubService>();

        ConfigureSwagger(services);
    }

    private void ConfigureSwagger(IServiceCollection services)
    {
        services.AddSwaggerGen(configs =>
        {
            configs.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Software Merge Prediction",
                Version = "v1",
                Description = ""
            });
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, PostgreSQLContext dbContext)
    {
        PostgreSQLInitializer.MigrateDatabase(dbContext);

        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}