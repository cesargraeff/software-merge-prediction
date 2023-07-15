using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Domain.Shared.Repositories;
using Domain.Functionality.Repositories;
using Domain.Method.Repositories;
using Domain.Branch.Repositories;
using Domain.File.Repositories;
using Domain.Commit.Repositories;
using Domain.Developer.Repositories;
using Domain.Scenario.Repositories;
using Domain.Class.Repositories;
using Domain.FileHistory.Repositories;
using Domain.FileLine.Repositories;
using Domain.Task.Repositories;
using Infrastructure.SQLite.Data;
using Infrastructure.PostgreSQL.Context;
using Infrastructure.PostgreSQL.Repositories.Functionality;
using Infrastructure.PostgreSQL.Repositories.Method;
using Infrastructure.PostgreSQL.Repositories.Branch;
using Infrastructure.PostgreSQL.Repositories.File;
using Infrastructure.PostgreSQL.Repositories.Commit;
using Infrastructure.PostgreSQL.Repositories.Developer;
using Infrastructure.PostgreSQL.Repositories.Scenario;
using Infrastructure.PostgreSQL.Repositories.Class;
using Infrastructure.PostgreSQL.Repositories.FileHistory;
using Infrastructure.PostgreSQL.Repositories.FileLine;
using Infrastructure.PostgreSQL.Repositories.Task;

namespace Infrastructure.PostgreSQL.Extensions
{
    public static class PostgreSQLExtensions
    {
        public static IServiceCollection AddPostgreSQL(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddNpgsql<PostgreSQLContext>(configuration["Database:PostgreSQL:Connection"]);
            services.AddScoped<IUnityOfWork, UnityOfWork>();

            AddRepositories(services);

            return services;
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddTransient<IFunctionalityRepository, FunctionalityRepository>();
            services.AddTransient<IMethodRepository, MethodRepository>();
            services.AddTransient<IBranchRepository, BranchRepository>();
            services.AddTransient<IFileRepository, FileRepository>();
            services.AddTransient<ICommitRepository, CommitRepository>();
            services.AddTransient<IDeveloperRepository, DeveloperRepository>();
            services.AddTransient<IScenarioRepository, ScenarioRepository>();
            services.AddTransient<IClassRepository, ClassRepository>();
            services.AddTransient<IFileHistoryRepository, FileHistoryRepository>();
            services.AddTransient<IFileLineRepository, FileLineRepository>();
            services.AddTransient<ITaskRepository, TaskRepository>();
        }
    }
}