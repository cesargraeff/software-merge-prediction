namespace Domain.Functionality.Repositories
{
    public interface IFunctionalityRepository
    {
        ValueTask Create(Domain.Functionality.Models.Functionality functionality);
        ValueTask<Domain.Functionality.Models.Functionality?> GetById(Guid id);
        void Update(Domain.Functionality.Models.Functionality functionality);
        void Delete(Domain.Functionality.Models.Functionality functionality);
    }
}