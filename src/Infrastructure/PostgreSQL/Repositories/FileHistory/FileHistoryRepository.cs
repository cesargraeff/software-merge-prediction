using Microsoft.EntityFrameworkCore;

using Domain.FileHistory.Repositories;
using Infrastructure.PostgreSQL.Context;

namespace Infrastructure.PostgreSQL.Repositories.FileHistory
{
    public class FileHistoryRepository : IFileHistoryRepository
    {
        private readonly PostgreSQLContext _context;
        public FileHistoryRepository(PostgreSQLContext context)
        {
            _context = context;
        }

        public async ValueTask Create(Domain.FileHistory.Models.FileHistory fileHistory)
            => await _context.FileHistories.AddAsync(fileHistory);

        public async ValueTask<Domain.FileHistory.Models.FileHistory?> GetById(Guid id)
            => await _context.FileHistories.Where(x => x.Id == id).FirstOrDefaultAsync();

        public void Update(Domain.FileHistory.Models.FileHistory fileHistory)
            => _context.Entry(fileHistory).State = EntityState.Modified;

        public void Delete(Domain.FileHistory.Models.FileHistory fileHistory)
            => _context.FileHistories.Remove(fileHistory);
    }
}