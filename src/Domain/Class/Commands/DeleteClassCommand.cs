using MediatR;

using Domain.Shared.Commands;

namespace Domain.Class.Commands
{
    public class DeleteClassCommand : Command<Unit>
    {
        public Guid Id { get; set; }
    }
}