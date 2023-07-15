using MediatR;

using Domain.Shared.Handlers;
using Domain.Shared.Repositories;
using Domain.Task.Commands;
using Domain.Task.Repositories;

namespace Domain.Task.Handlers
{
    public class UpdateTaskHandler : Handler<UpdateTaskCommand>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUnityOfWork _unityOfWork;
        public UpdateTaskHandler(ITaskRepository taskRepository, IUnityOfWork unityOfWork)
        {
            _taskRepository = taskRepository;
            _unityOfWork = unityOfWork;
        }

        public override async Task<Unit> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetById(request.Id);

            if (task != null)
            {
                task.Update(
                    name: request.Name,
                    description: request.Description,
                    estimation: request.Estimation,
                    priority: request.Priority,
                    criticality: request.Criticality,
                    deliveryDate: request.DeliveryDate
                );

                _taskRepository.Update(task);

                await _unityOfWork.Commit();

                return Unit.Value;
            }

            return Unit.Value;
        }
    }
}