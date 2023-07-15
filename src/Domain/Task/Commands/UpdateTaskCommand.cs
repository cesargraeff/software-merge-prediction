namespace Domain.Task.Commands
{
    public class UpdateTaskCommand : CreateTaskCommand
    {
        public Guid Id { get; set; }
    }
}