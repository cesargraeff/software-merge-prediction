using MediatR;

using Domain.Shared.Commands;

namespace Domain.Scenario.Commands
{
    public class CreateScenarioCommand : Command<Unit>
    {
        public int Name { get; set; }
        public int Description { get; set; }
        public int Criticality { get; set; }
    }
}