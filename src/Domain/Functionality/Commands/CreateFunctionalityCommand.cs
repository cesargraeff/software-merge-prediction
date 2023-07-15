using MediatR;

using Domain.Shared.Commands;

namespace Domain.Functionality.Commands
{
    public class CreateFunctionalityCommand : Command<Unit>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}