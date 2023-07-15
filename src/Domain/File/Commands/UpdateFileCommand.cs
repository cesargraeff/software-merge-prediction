namespace Domain.File.Commands
{
    public class UpdateFileCommand : CreateFileCommand
    {
        public Guid Id { get; set; }
    }
}