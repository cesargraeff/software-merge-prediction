using MediatR;

using Domain.Shared.Commands;

namespace Domain.Class.Commands
{
    public class CreateClassCommand : Command<Unit>
    {
        public string Name { get; set; }
        public int StartLine { get; set; }
        public int FinishLine { get; set; }
    }
}