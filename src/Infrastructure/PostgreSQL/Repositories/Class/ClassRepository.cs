using Microsoft.EntityFrameworkCore;

using Domain.Class.Repositories;
using Infrastructure.PostgreSQL.Context;

namespace Infrastructure.PostgreSQL.Repositories.Class
{
    public class ClassRepository : IClassRepository
    {
        private readonly PostgreSQLContext _context;
        public ClassRepository(PostgreSQLContext context)
        {
            _context = context;
        }

        public async ValueTask Create(Domain.Class.Models.Class @class)
            => await _context.Classes.AddAsync(@class);

        public async ValueTask<Domain.Class.Models.Class?> GetById(Guid id)
            => await _context.Classes.Where(x => x.Id == id).FirstOrDefaultAsync();

        public void Update(Domain.Class.Models.Class @class)
            => _context.Entry(@class).State = EntityState.Modified;

        public void Delete(Domain.Class.Models.Class @class)
            => _context.Classes.Remove(@class);
    }
}