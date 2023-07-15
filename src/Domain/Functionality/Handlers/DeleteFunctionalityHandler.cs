using MediatR;

using Domain.Shared.Handlers;
using Domain.Shared.Repositories;
using Domain.Functionality.Commands;
using Domain.Functionality.Repositories;

namespace Domain.Functionality.Handlers
{
    public class DeleteFunctionalityHandler : Handler<DeleteFunctionalityCommand>
    {
        private readonly IFunctionalityRepository _functionalityRepository;
        private readonly IUnityOfWork _unityOfWork;
        public DeleteFunctionalityHandler(IFunctionalityRepository functionalityRepository, IUnityOfWork unityOfWork)
        {
            _functionalityRepository = functionalityRepository;
            _unityOfWork = unityOfWork;
        }

        public override async Task<Unit> Handle(DeleteFunctionalityCommand request, CancellationToken cancellationToken)
        {
            var functionality = await _functionalityRepository.GetById(request.Id);

            if (functionality != null)
            {
                _functionalityRepository.Delete(functionality);

                await _unityOfWork.Commit();

                return Unit.Value;
            }

            return Unit.Value;
        }
    }
}