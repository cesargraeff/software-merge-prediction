namespace Domain.Branch.Commands
{
    public class UpdateBranchCommand : CreateBranchCommand
    {
        public Guid Id { get; set; }
    }
}