using MediatR;

using Domain.Shared.Handlers;
using Domain.Shared.Repositories;
using Domain.Class.Commands;
using Domain.Class.Repositories;

namespace Domain.Class.Handlers
{
    public class UpdateClassHandler : Handler<UpdateClassCommand>
    {
        private readonly IClassRepository _classRepository;
        private readonly IUnityOfWork _unityOfWork;
        public UpdateClassHandler(IClassRepository classRepository, IUnityOfWork unityOfWork)
        {
            _classRepository = classRepository;
            _unityOfWork = unityOfWork;
        }

        public override async Task<Unit> Handle(UpdateClassCommand request, CancellationToken cancellationToken)
        {
            var @class = await _classRepository.GetById(request.Id);

            if (@class != null)
            {
                @class.Update(
                    name: request.Name,
                    startLine: request.StartLine,
                    finishLine: request.FinishLine
                );

                _classRepository.Update(@class);

                await _unityOfWork.Commit();

                return Unit.Value;
            }

            return Unit.Value;
        }
    }
}