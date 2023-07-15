using Microsoft.EntityFrameworkCore;

using Domain.FileLine.Repositories;
using Infrastructure.PostgreSQL.Context;

namespace Infrastructure.PostgreSQL.Repositories.FileLine
{
    public class FileLineRepository : IFileLineRepository
    {
        private readonly PostgreSQLContext _context;
        public FileLineRepository(PostgreSQLContext context)
        {
            _context = context;
        }

        public async ValueTask Create(Domain.FileLine.Models.FileLine fileLine)
            => await _context.FileLines.AddAsync(fileLine);

        public async ValueTask<Domain.FileLine.Models.FileLine?> GetById(Guid id)
            => await _context.FileLines.Where(x => x.Id == id).FirstOrDefaultAsync();

        public void Update(Domain.FileLine.Models.FileLine fileLine)
            => _context.Entry(fileLine).State = EntityState.Modified;

        public void Delete(Domain.FileLine.Models.FileLine fileLine)
            => _context.FileLines.Remove(fileLine);
    }
}