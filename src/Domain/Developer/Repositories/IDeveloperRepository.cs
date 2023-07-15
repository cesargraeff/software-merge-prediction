namespace Domain.Developer.Repositories
{
    public interface IDeveloperRepository
    {
        ValueTask Create(Domain.Developer.Models.Developer developer);
        ValueTask<Domain.Developer.Models.Developer?> GetById(Guid id);
        ValueTask<IEnumerable<Domain.Developer.Models.Developer>?> List();
        void Update(Domain.Developer.Models.Developer developer);
        void Delete(Domain.Developer.Models.Developer developer);
        ValueTask<Domain.Developer.Models.Developer?> GetByCode(int id);
    }
}