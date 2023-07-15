using Microsoft.EntityFrameworkCore;

using Domain.Shared.Entities;
using Infrastructure.PostgreSQL.Mappings.Functionality;
using Infrastructure.PostgreSQL.Mappings.Method;
using Infrastructure.PostgreSQL.Mappings.Branch;
using Infrastructure.PostgreSQL.Mappings.File;
using Infrastructure.PostgreSQL.Mappings.Commit;
using Infrastructure.PostgreSQL.Mappings.Developer;
using Infrastructure.PostgreSQL.Mappings.Scenario;
using Infrastructure.PostgreSQL.Mappings.Class;
using Infrastructure.PostgreSQL.Mappings.FileHistory;
using Infrastructure.PostgreSQL.Mappings.FileLine;
using Infrastructure.PostgreSQL.Mappings.Task;

namespace Infrastructure.PostgreSQL.Context
{
    public class PostgreSQLContext : DbContext
    {
        public PostgreSQLContext(DbContextOptions<PostgreSQLContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<Domain.Functionality.Models.Functionality> Functionalities { get; set; }
        public DbSet<Domain.Method.Models.Method> Methods { get; set; }
        public DbSet<Domain.Branch.Models.Branch> Branches { get; set; }
        public DbSet<Domain.File.Models.File> Files { get; set; }
        public DbSet<Domain.Commit.Models.Commit> Commits { get; set; }
        public DbSet<Domain.Developer.Models.Developer> Developers { get; set; }
        public DbSet<Domain.Scenario.Models.Scenario> Scenarios { get; set; }
        public DbSet<Domain.Class.Models.Class> Classes { get; set; }
        public DbSet<Domain.FileHistory.Models.FileHistory> FileHistories { get; set; }
        public DbSet<Domain.FileLine.Models.FileLine> FileLines { get; set; }
        public DbSet<Domain.Task.Models.Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new FunctionalityMap());
            builder.ApplyConfiguration(new MethodMap());
            builder.ApplyConfiguration(new BranchMap());
            builder.ApplyConfiguration(new FileMap());
            builder.ApplyConfiguration(new CommitMap());
            builder.ApplyConfiguration(new DeveloperMap());
            builder.ApplyConfiguration(new ScenarioMap());
            builder.ApplyConfiguration(new ClassMap());
            builder.ApplyConfiguration(new FileHistoryMap());
            builder.ApplyConfiguration(new FileLineMap());
            builder.ApplyConfiguration(new TaskMap());
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            var AddedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Added).ToList();

            AddedEntities.ForEach(E =>
            {
                if (typeof(Entity).IsInstanceOfType(E.Entity) && (
                    E.Property("CreatedAt").CurrentValue == null
                    || ((DateTime)E.Property("CreatedAt").CurrentValue).CompareTo(DateTime.MinValue) == 0
                ))
                {
                    E.Property("CreatedAt").CurrentValue = DateTime.UtcNow;
                }
            });

            var EditedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Modified).ToList();

            EditedEntities.ForEach(E =>
            {
                if (typeof(Entity).IsInstanceOfType(E.Entity) && (
                    E.Property("UpdatedAt").CurrentValue == null
                    || ((DateTime)E.Property("UpdatedAt").CurrentValue).CompareTo(DateTime.MinValue) == 0
                    || ((DateTime)E.Property("UpdatedAt").CurrentValue) < DateTime.UtcNow
                ))
                {
                    E.Property("UpdatedAt").CurrentValue = DateTime.UtcNow;
                }
            });

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}