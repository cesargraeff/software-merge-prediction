namespace Domain.Shared.Repositories
{
    public interface IUnityOfWork
    {
        Task<int> Commit();
    }
}