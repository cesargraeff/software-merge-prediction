namespace Domain.Shared.DTO
{
    public class GitHubCommitDTO
    {
        public string? Sha { get; set; }

        public GitHubCommiterDTO? Committer { get; set; }

        public GitHubCommitDataDTO? Commit { get; set; }

        public GitHubDeveloperDTO? Author { get; set; }
    }
}