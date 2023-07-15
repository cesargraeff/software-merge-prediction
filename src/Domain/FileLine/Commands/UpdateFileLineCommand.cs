namespace Domain.FileLine.Commands
{
    public class UpdateFileLineCommand : CreateFileLineCommand
    {
        public Guid Id { get; set; }
    }
}