using Microsoft.EntityFrameworkCore;

using Domain.File.Repositories;
using Infrastructure.PostgreSQL.Context;

namespace Infrastructure.PostgreSQL.Repositories.File
{
    public class FileRepository : IFileRepository
    {
        private readonly PostgreSQLContext _context;
        public FileRepository(PostgreSQLContext context)
        {
            _context = context;
        }

        public async ValueTask Create(Domain.File.Models.File file)
            => await _context.Files.AddAsync(file);

        public async ValueTask<Domain.File.Models.File?> GetById(Guid id)
            => await _context.Files.Where(x => x.Id == id).FirstOrDefaultAsync();

        public void Update(Domain.File.Models.File file)
            => _context.Entry(file).State = EntityState.Modified;

        public void Delete(Domain.File.Models.File file)
            => _context.Files.Remove(file);
    }
}