namespace Domain.Scenario.Repositories
{
    public interface IScenarioRepository
    {
        ValueTask Create(Domain.Scenario.Models.Scenario scenario);
        ValueTask<Domain.Scenario.Models.Scenario?> GetById(Guid id);
        void Update(Domain.Scenario.Models.Scenario scenario);
        void Delete(Domain.Scenario.Models.Scenario scenario);
    }
}