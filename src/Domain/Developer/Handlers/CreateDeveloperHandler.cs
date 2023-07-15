using MediatR;

using Domain.Shared.Handlers;
using Domain.Shared.Repositories;
using Domain.Developer.Commands;
using Domain.Developer.Repositories;

namespace Domain.Developer.Handlers
{
    public class CreateDeveloperHandler : Handler<CreateDeveloperCommand>
    {
        private readonly IDeveloperRepository _developerRepository;
        private readonly IUnityOfWork _unityOfWork;
        public CreateDeveloperHandler(IDeveloperRepository developerRepository, IUnityOfWork unityOfWork)
        {
            _developerRepository = developerRepository;
            _unityOfWork = unityOfWork;
        }

        public override async Task<Unit> Handle(CreateDeveloperCommand request, CancellationToken cancellationToken)
        {
            var developer = new Domain.Developer.Models.Developer(
                name: request.Name,
                workingHours: request.WorkingHours,
                experience: request.Experience
            );

            await _developerRepository.Create(developer);

            await _unityOfWork.Commit();

            return Unit.Value;
        }
    }
}