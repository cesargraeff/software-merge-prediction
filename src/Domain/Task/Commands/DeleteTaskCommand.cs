using MediatR;

using Domain.Shared.Commands;

namespace Domain.Task.Commands
{
    public class DeleteTaskCommand : Command<Unit>
    {
        public Guid Id { get; set; }
    }
}