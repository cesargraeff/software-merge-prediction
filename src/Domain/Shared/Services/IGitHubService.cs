using Domain.Shared.DTO;

namespace Domain.Services
{
    public interface IGitHubService
    {
        Task<List<GitHubDeveloperDTO>> Developers();

        Task<List<GitHubBranchDTO>> Branches();

        Task<List<GitHubCommitDTO>> Commits();

    }
}