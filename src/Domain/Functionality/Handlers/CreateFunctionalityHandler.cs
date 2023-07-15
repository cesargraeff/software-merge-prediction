using MediatR;

using Domain.Shared.Handlers;
using Domain.Shared.Repositories;
using Domain.Functionality.Commands;
using Domain.Functionality.Repositories;

namespace Domain.Functionality.Handlers
{
    public class CreateFunctionalityHandler : Handler<CreateFunctionalityCommand>
    {
        private readonly IFunctionalityRepository _functionalityRepository;
        private readonly IUnityOfWork _unityOfWork;
        public CreateFunctionalityHandler(IFunctionalityRepository functionalityRepository, IUnityOfWork unityOfWork)
        {
            _functionalityRepository = functionalityRepository;
            _unityOfWork = unityOfWork;
        }

        public override async Task<Unit> Handle(CreateFunctionalityCommand request, CancellationToken cancellationToken)
        {
            var functionality = new Domain.Functionality.Models.Functionality(
                name: request.Name,
                description: request.Description
            );

            await _functionalityRepository.Create(functionality);

            await _unityOfWork.Commit();

            return Unit.Value;
        }
    }
}