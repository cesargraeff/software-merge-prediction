namespace Domain.Task.Repositories
{
    public interface ITaskRepository
    {
        ValueTask Create(Domain.Task.Models.Task task);
        ValueTask<Domain.Task.Models.Task?> GetById(Guid id);
        void Update(Domain.Task.Models.Task task);
        void Delete(Domain.Task.Models.Task task);
    }
}