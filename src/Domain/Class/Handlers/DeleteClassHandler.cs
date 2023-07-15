using MediatR;

using Domain.Shared.Handlers;
using Domain.Shared.Repositories;
using Domain.Class.Commands;
using Domain.Class.Repositories;

namespace Domain.Class.Handlers
{
    public class DeleteClassHandler : Handler<DeleteClassCommand>
    {
        private readonly IClassRepository _classRepository;
        private readonly IUnityOfWork _unityOfWork;
        public DeleteClassHandler(IClassRepository classRepository, IUnityOfWork unityOfWork)
        {
            _classRepository = classRepository;
            _unityOfWork = unityOfWork;
        }

        public override async Task<Unit> Handle(DeleteClassCommand request, CancellationToken cancellationToken)
        {
            var @class = await _classRepository.GetById(request.Id);

            if (@class != null)
            {
                _classRepository.Delete(@class);

                await _unityOfWork.Commit();

                return Unit.Value;
            }

            return Unit.Value;
        }
    }
}