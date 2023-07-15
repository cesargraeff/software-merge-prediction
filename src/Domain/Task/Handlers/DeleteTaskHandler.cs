using MediatR;

using Domain.Shared.Handlers;
using Domain.Shared.Repositories;
using Domain.Task.Commands;
using Domain.Task.Repositories;

namespace Domain.Task.Handlers
{
    public class DeleteTaskHandler : Handler<DeleteTaskCommand>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUnityOfWork _unityOfWork;
        public DeleteTaskHandler(ITaskRepository taskRepository, IUnityOfWork unityOfWork)
        {
            _taskRepository = taskRepository;
            _unityOfWork = unityOfWork;
        }

        public override async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.GetById(request.Id);

            if (task != null)
            {
                _taskRepository.Delete(task);

                await _unityOfWork.Commit();

                return Unit.Value;
            }

            return Unit.Value;
        }
    }
}