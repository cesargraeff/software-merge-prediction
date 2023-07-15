namespace Domain.FileHistory.Commands
{
    public class UpdateFileHistoryCommand : CreateFileHistoryCommand
    {
        public Guid Id { get; set; }
    }
}