using MediatR;

using Domain.Shared.Handlers;
using Domain.Shared.Repositories;
using Domain.Class.Commands;
using Domain.Class.Repositories;

namespace Domain.Class.Handlers
{
    public class CreateClassHandler : Handler<CreateClassCommand>
    {
        private readonly IClassRepository _classRepository;
        private readonly IUnityOfWork _unityOfWork;
        public CreateClassHandler(IClassRepository classRepository, IUnityOfWork unityOfWork)
        {
            _classRepository = classRepository;
            _unityOfWork = unityOfWork;
        }

        public override async Task<Unit> Handle(CreateClassCommand request, CancellationToken cancellationToken)
        {
            var @class = new Domain.Class.Models.Class(
                name: request.Name,
                startLine: request.StartLine,
                finishLine: request.FinishLine
            );

            await _classRepository.Create(@class);

            await _unityOfWork.Commit();

            return Unit.Value;
        }
    }
}