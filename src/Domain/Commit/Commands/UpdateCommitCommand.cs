namespace Domain.Commit.Commands
{
    public class UpdateCommitCommand : CreateCommitCommand
    {
        public Guid Id { get; set; }
    }
}