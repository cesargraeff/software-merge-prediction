using Domain.Shared.Entities;

namespace Domain.Task.Models
{
    public class Task : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Estimation { get; private set; }
        public int Priority { get; private set; }
        public int Criticality { get; private set; }
        public DateTime DeliveryDate { get; private set; }

        public Task(
            string name,
            string description,
            int estimation,
            int priority,
            int criticality,
            DateTime deliveryDate
        )
        {
            this.Name = name;
            this.Description = description;
            this.Estimation = estimation;
            this.Priority = priority;
            this.Criticality = criticality;
            this.DeliveryDate = deliveryDate;
        }
        public void Update(
            string name,
            string description,
            int estimation,
            int priority,
            int criticality,
            DateTime deliveryDate
        )
        {
            this.Name = name;
            this.Description = description;
            this.Estimation = estimation;
            this.Priority = priority;
            this.Criticality = criticality;
            this.DeliveryDate = deliveryDate;
        }
    }
}