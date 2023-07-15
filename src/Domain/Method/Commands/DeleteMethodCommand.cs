using MediatR;

using Domain.Shared.Commands;

namespace Domain.Method.Commands
{
    public class DeleteMethodCommand : Command<Unit>
    {
        public Guid Id { get; set; }
    }
}