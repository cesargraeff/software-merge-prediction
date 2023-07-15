using Microsoft.EntityFrameworkCore;

using Domain.Developer.Repositories;
using Infrastructure.PostgreSQL.Context;

namespace Infrastructure.PostgreSQL.Repositories.Developer
{
    public class DeveloperRepository : IDeveloperRepository
    {
        private readonly PostgreSQLContext _context;
        public DeveloperRepository(PostgreSQLContext context)
        {
            _context = context;
        }

        public async ValueTask<Domain.Developer.Models.Developer?> GetById(Guid id)
           => await _context.Developers.Where(x => x.Id == id).FirstOrDefaultAsync();

        public async ValueTask Create(Domain.Developer.Models.Developer developer)
            => await _context.Developers.AddAsync(developer);

        public async ValueTask<IEnumerable<Domain.Developer.Models.Developer>?> List()
            => await _context.Developers.AsNoTracking().ToListAsync();

        public void Update(Domain.Developer.Models.Developer developer)
            => _context.Entry(developer).State = EntityState.Modified;

        public void Delete(Domain.Developer.Models.Developer developer)
            => _context.Developers.Remove(developer);

        public async ValueTask<Domain.Developer.Models.Developer?> GetByCode(int id)
            => await _context.Developers.Where(x => x.Code == id).FirstOrDefaultAsync();
    }
}