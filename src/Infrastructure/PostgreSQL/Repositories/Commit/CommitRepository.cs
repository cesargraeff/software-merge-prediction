using Microsoft.EntityFrameworkCore;

using Domain.Commit.Repositories;
using Infrastructure.PostgreSQL.Context;

namespace Infrastructure.PostgreSQL.Repositories.Commit
{
    public class CommitRepository : ICommitRepository
    {
        private readonly PostgreSQLContext _context;
        public CommitRepository(PostgreSQLContext context)
        {
            _context = context;
        }

        public async ValueTask Create(Domain.Commit.Models.Commit commit)
            => await _context.Commits.AddAsync(commit);

        public async ValueTask<Domain.Commit.Models.Commit?> GetById(Guid id)
            => await _context.Commits.Where(x => x.Id == id).FirstOrDefaultAsync();

        public async ValueTask<IEnumerable<Domain.Commit.Models.Commit>?> List()
            => await _context.Commits.Include(x => x.Developer).AsNoTracking().ToListAsync();

        public void Update(Domain.Commit.Models.Commit commit)
            => _context.Entry(commit).State = EntityState.Modified;

        public void Delete(Domain.Commit.Models.Commit commit)
            => _context.Commits.Remove(commit);
    }
}