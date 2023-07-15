namespace Domain.File.Repositories
{
    public interface IFileRepository
    {
        ValueTask Create(Domain.File.Models.File file);
        ValueTask<Domain.File.Models.File?> GetById(Guid id);
        void Update(Domain.File.Models.File file);
        void Delete(Domain.File.Models.File file);
    }
}