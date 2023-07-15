using MediatR;

using Domain.Shared.Commands;

namespace Domain.FileHistory.Commands
{
    public class CreateFileHistoryCommand : Command<Unit>
    {
        public int LinesAdded { get; set; }
        public int LinesRemoved { get; set; }
        public int Operation { get; set; }
    }
}