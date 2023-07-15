namespace Domain.Method.Repositories
{
    public interface IMethodRepository
    {
        ValueTask Create(Domain.Method.Models.Method method);
        ValueTask<Domain.Method.Models.Method?> GetById(Guid id);
        void Update(Domain.Method.Models.Method method);
        void Delete(Domain.Method.Models.Method method);
    }
}