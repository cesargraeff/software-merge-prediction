using Microsoft.EntityFrameworkCore;

using Domain.Method.Repositories;
using Infrastructure.PostgreSQL.Context;

namespace Infrastructure.PostgreSQL.Repositories.Method
{
    public class MethodRepository : IMethodRepository
    {
        private readonly PostgreSQLContext _context;
        public MethodRepository(PostgreSQLContext context)
        {
            _context = context;
        }

        public async ValueTask Create(Domain.Method.Models.Method method)
            => await _context.Methods.AddAsync(method);

        public async ValueTask<Domain.Method.Models.Method?> GetById(Guid id)
            => await _context.Methods.Where(x => x.Id == id).FirstOrDefaultAsync();

        public void Update(Domain.Method.Models.Method method)
            => _context.Entry(method).State = EntityState.Modified;

        public void Delete(Domain.Method.Models.Method method)
            => _context.Methods.Remove(method);
    }
}