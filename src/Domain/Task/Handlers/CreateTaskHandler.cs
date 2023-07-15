using MediatR;

using Domain.Shared.Handlers;
using Domain.Shared.Repositories;
using Domain.Task.Commands;
using Domain.Task.Repositories;

namespace Domain.Task.Handlers
{
    public class CreateTaskHandler : Handler<CreateTaskCommand>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUnityOfWork _unityOfWork;
        public CreateTaskHandler(ITaskRepository taskRepository, IUnityOfWork unityOfWork)
        {
            _taskRepository = taskRepository;
            _unityOfWork = unityOfWork;
        }

        public override async Task<Unit> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = new Domain.Task.Models.Task(
                name: request.Name,
                description: request.Description,
                estimation: request.Estimation,
                priority: request.Priority,
                criticality: request.Criticality,
                deliveryDate: request.DeliveryDate
            );

            await _taskRepository.Create(task);

            await _unityOfWork.Commit();

            return Unit.Value;
        }
    }
}