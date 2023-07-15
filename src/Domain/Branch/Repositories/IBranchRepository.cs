namespace Domain.Branch.Repositories
{
    public interface IBranchRepository
    {
        ValueTask Create(Domain.Branch.Models.Branch branch);
        ValueTask<Domain.Branch.Models.Branch?> GetById(Guid id);
        ValueTask<IEnumerable<Domain.Branch.Models.Branch>?> List();
        void Update(Domain.Branch.Models.Branch branch);
        void Delete(Domain.Branch.Models.Branch branch);
        ValueTask<Domain.Branch.Models.Branch?> GetByName(string name);
    }
}