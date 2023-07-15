using Microsoft.EntityFrameworkCore;

using Domain.Branch.Repositories;
using Infrastructure.PostgreSQL.Context;

namespace Infrastructure.PostgreSQL.Repositories.Branch
{
    public class BranchRepository : IBranchRepository
    {
        private readonly PostgreSQLContext _context;
        public BranchRepository(PostgreSQLContext context)
        {
            _context = context;
        }

        public async ValueTask Create(Domain.Branch.Models.Branch branch)
            => await _context.Branches.AddAsync(branch);

        public async ValueTask<Domain.Branch.Models.Branch?> GetById(Guid id)
            => await _context.Branches.Where(x => x.Id == id).FirstOrDefaultAsync();

        public async ValueTask<IEnumerable<Domain.Branch.Models.Branch>?> List()
            => await _context.Branches.AsNoTracking().ToListAsync();

        public void Update(Domain.Branch.Models.Branch branch)
            => _context.Entry(branch).State = EntityState.Modified;

        public void Delete(Domain.Branch.Models.Branch branch)
            => _context.Branches.Remove(branch);

        public async ValueTask<Domain.Branch.Models.Branch?> GetByName(string name)
           => await _context.Branches.Where(x => x.Name == name).FirstOrDefaultAsync();
    }
}