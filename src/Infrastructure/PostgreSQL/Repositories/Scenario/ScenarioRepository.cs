using Microsoft.EntityFrameworkCore;

using Domain.Scenario.Repositories;
using Infrastructure.PostgreSQL.Context;

namespace Infrastructure.PostgreSQL.Repositories.Scenario
{
    public class ScenarioRepository : IScenarioRepository
    {
        private readonly PostgreSQLContext _context;
        public ScenarioRepository(PostgreSQLContext context)
        {
            _context = context;
        }

        public async ValueTask Create(Domain.Scenario.Models.Scenario scenario)
            => await _context.Scenarios.AddAsync(scenario);

        public async ValueTask<Domain.Scenario.Models.Scenario?> GetById(Guid id)
            => await _context.Scenarios.Where(x => x.Id == id).FirstOrDefaultAsync();

        public void Update(Domain.Scenario.Models.Scenario scenario)
            => _context.Entry(scenario).State = EntityState.Modified;

        public void Delete(Domain.Scenario.Models.Scenario scenario)
            => _context.Scenarios.Remove(scenario);
    }
}