using MediatR;

using Domain.Shared.Commands;

namespace Domain.FileHistory.Commands
{
    public class DeleteFileHistoryCommand : Command<Unit>
    {
        public Guid Id { get; set; }
    }
}