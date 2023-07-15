using MediatR;

using Domain.Shared.Commands;

namespace Domain.Task.Commands
{
    public class CreateTaskCommand : Command<Unit>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Estimation { get; set; }
        public int Priority { get; set; }
        public int Criticality { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}