using Microsoft.EntityFrameworkCore;

using Domain.Task.Repositories;
using Infrastructure.PostgreSQL.Context;

namespace Infrastructure.PostgreSQL.Repositories.Task
{
    public class TaskRepository : ITaskRepository
    {
        private readonly PostgreSQLContext _context;
        public TaskRepository(PostgreSQLContext context)
        {
            _context = context;
        }

        public async ValueTask Create(Domain.Task.Models.Task task)
            => await _context.Tasks.AddAsync(task);

        public async ValueTask<Domain.Task.Models.Task?> GetById(Guid id)
            => await _context.Tasks.Where(x => x.Id == id).FirstOrDefaultAsync();

        public void Update(Domain.Task.Models.Task task)
            => _context.Entry(task).State = EntityState.Modified;

        public void Delete(Domain.Task.Models.Task task)
            => _context.Tasks.Remove(task);
    }
}