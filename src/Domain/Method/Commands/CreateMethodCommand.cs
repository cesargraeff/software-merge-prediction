using MediatR;

using Domain.Shared.Commands;

namespace Domain.Method.Commands
{
    public class CreateMethodCommand : Command<Unit>
    {
        public string Name { get; set; }
        public int StartLine { get; set; }
        public int FinishLine { get; set; }
    }
}