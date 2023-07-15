namespace Domain.Scenario.Commands
{
    public class UpdateScenarioCommand : CreateScenarioCommand
    {
        public Guid Id { get; set; }
    }
}