namespace Domain.FileLine.Repositories
{
    public interface IFileLineRepository
    {
        ValueTask Create(Domain.FileLine.Models.FileLine fileLine);
        ValueTask<Domain.FileLine.Models.FileLine?> GetById(Guid id);
        void Update(Domain.FileLine.Models.FileLine fileLine);
        void Delete(Domain.FileLine.Models.FileLine fileLine);
    }
}