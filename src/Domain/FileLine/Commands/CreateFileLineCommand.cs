using MediatR;

using Domain.Shared.Commands;

namespace Domain.FileLine.Commands
{
    public class CreateFileLineCommand : Command<Unit>
    {
        public int Line { get; set; }
        public string Code { get; set; }
        public int Operation { get; set; }
    }
}