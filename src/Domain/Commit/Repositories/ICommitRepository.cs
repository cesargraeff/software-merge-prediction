namespace Domain.Commit.Repositories
{
    public interface ICommitRepository
    {
        ValueTask Create(Domain.Commit.Models.Commit commit);
        ValueTask<Domain.Commit.Models.Commit?> GetById(Guid id);
        ValueTask<IEnumerable<Domain.Commit.Models.Commit>?> List();
        void Update(Domain.Commit.Models.Commit commit);
        void Delete(Domain.Commit.Models.Commit commit);
    }
}