using MediatR;

using Domain.Shared.Commands;

namespace Domain.Branch.Commands
{
    public class CreateBranchCommand : Command<Unit>
    {
        public string Name { get; set; }
    }
}