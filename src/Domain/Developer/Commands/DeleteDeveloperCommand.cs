using MediatR;

using Domain.Shared.Commands;

namespace Domain.Developer.Commands
{
    public class DeleteDeveloperCommand : Command<Unit>
    {
        public Guid Id { get; set; }
    }
}