using MediatR;

using Domain.Shared.Commands;

namespace Domain.Developer.Commands
{
    public class CreateDeveloperCommand : Command<Unit>
    {
        public string Name { get; set; }
        public int WorkingHours { get; set; }
        public int Experience { get; set; }
    }
}