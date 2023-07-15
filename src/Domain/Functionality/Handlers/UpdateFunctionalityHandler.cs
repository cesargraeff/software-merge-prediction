using MediatR;

using Domain.Shared.Handlers;
using Domain.Shared.Repositories;
using Domain.Functionality.Commands;
using Domain.Functionality.Repositories;

namespace Domain.Functionality.Handlers
{
    public class UpdateFunctionalityHandler : Handler<UpdateFunctionalityCommand>
    {
        private readonly IFunctionalityRepository _functionalityRepository;
        private readonly IUnityOfWork _unityOfWork;
        public UpdateFunctionalityHandler(IFunctionalityRepository functionalityRepository, IUnityOfWork unityOfWork)
        {
            _functionalityRepository = functionalityRepository;
            _unityOfWork = unityOfWork;
        }

        public override async Task<Unit> Handle(UpdateFunctionalityCommand request, CancellationToken cancellationToken)
        {
            var functionality = await _functionalityRepository.GetById(request.Id);

            if (functionality != null)
            {
                functionality.Update(
                    name: request.Name,
                    description: request.Description
                );

                _functionalityRepository.Update(functionality);

                await _unityOfWork.Commit();

                return Unit.Value;
            }

            return Unit.Value;
        }
    }
}