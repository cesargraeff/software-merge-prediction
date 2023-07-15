using Domain.Shared.Repositories;
using Infrastructure.PostgreSQL.Context;

namespace Infrastructure.SQLite.Data
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly PostgreSQLContext _context;
        public UnityOfWork(PostgreSQLContext context)
        {
            _context = context;
        }

        public async Task<int> Commit()
            => await _context.SaveChangesAsync();
    }
}