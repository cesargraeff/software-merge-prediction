using MediatR;

using Domain.Shared.Commands;

namespace Domain.Scenario.Commands
{
    public class DeleteScenarioCommand : Command<Unit>
    {
        public Guid Id { get; set; }
    }
}