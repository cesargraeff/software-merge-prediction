using MediatR;

using Domain.Shared.Commands;

namespace Domain.Functionality.Commands
{
    public class DeleteFunctionalityCommand : Command<Unit>
    {
        public Guid Id { get; set; }
    }
}