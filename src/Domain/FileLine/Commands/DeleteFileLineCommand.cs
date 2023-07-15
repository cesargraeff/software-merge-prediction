using MediatR;

using Domain.Shared.Commands;

namespace Domain.FileLine.Commands
{
    public class DeleteFileLineCommand : Command<Unit>
    {
        public Guid Id { get; set; }
    }
}