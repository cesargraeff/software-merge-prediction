using Microsoft.EntityFrameworkCore;

using Domain.Functionality.Repositories;
using Infrastructure.PostgreSQL.Context;

namespace Infrastructure.PostgreSQL.Repositories.Functionality
{
    public class FunctionalityRepository : IFunctionalityRepository
    {
        private readonly PostgreSQLContext _context;
        public FunctionalityRepository(PostgreSQLContext context)
        {
            _context = context;
        }

        public async ValueTask Create(Domain.Functionality.Models.Functionality functionality)
            => await _context.Functionalities.AddAsync(functionality);

        public async ValueTask<Domain.Functionality.Models.Functionality?> GetById(Guid id)
            => await _context.Functionalities.Where(x => x.Id == id).FirstOrDefaultAsync();

        public void Update(Domain.Functionality.Models.Functionality functionality)
            => _context.Entry(functionality).State = EntityState.Modified;

        public void Delete(Domain.Functionality.Models.Functionality functionality)
            => _context.Functionalities.Remove(functionality);
    }
}