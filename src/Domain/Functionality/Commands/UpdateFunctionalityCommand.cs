namespace Domain.Functionality.Commands
{
    public class UpdateFunctionalityCommand : CreateFunctionalityCommand
    {
        public Guid Id { get; set; }
    }
}