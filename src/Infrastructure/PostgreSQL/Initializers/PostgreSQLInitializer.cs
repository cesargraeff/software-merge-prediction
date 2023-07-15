using Microsoft.EntityFrameworkCore;

namespace Infrastructure.PostgreSQL.Initializers
{
    public static class PostgreSQLInitializer
    {
        public static void MigrateDatabase<PostgreSQLContext>(this PostgreSQLContext dbContext) where PostgreSQLContext : DbContext
        {
            dbContext.Database.Migrate();
        }
    }
}