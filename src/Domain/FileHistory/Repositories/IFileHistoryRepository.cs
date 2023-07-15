namespace Domain.FileHistory.Repositories
{
    public interface IFileHistoryRepository
    {
        ValueTask Create(Domain.FileHistory.Models.FileHistory fileHistory);
        ValueTask<Domain.FileHistory.Models.FileHistory?> GetById(Guid id);
        void Update(Domain.FileHistory.Models.FileHistory fileHistory);
        void Delete(Domain.FileHistory.Models.FileHistory fileHistory);
    }
}