using MediatR;

using Domain.Shared.Commands;

namespace Domain.File.Commands
{
    public class DeleteFileCommand : Command<Unit>
    {
        public Guid Id { get; set; }
    }
}