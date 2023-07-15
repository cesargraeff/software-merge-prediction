namespace Domain.Class.Repositories
{
    public interface IClassRepository
    {
        ValueTask Create(Domain.Class.Models.Class @class);
        ValueTask<Domain.Class.Models.Class?> GetById(Guid id);
        void Update(Domain.Class.Models.Class @class);
        void Delete(Domain.Class.Models.Class @class);
    }
}