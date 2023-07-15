using MediatR;

using Domain.Shared.Handlers;
using Domain.Shared.Repositories;
using Domain.Developer.Commands;
using Domain.Developer.Repositories;

namespace Domain.Developer.Handlers
{
    public class UpdateDeveloperHandler : Handler<UpdateDeveloperCommand>
    {
        private readonly IDeveloperRepository _developerRepository;
        private readonly IUnityOfWork _unityOfWork;
        public UpdateDeveloperHandler(IDeveloperRepository developerRepository, IUnityOfWork unityOfWork)
        {
            _developerRepository = developerRepository;
            _unityOfWork = unityOfWork;
        }

        public override async Task<Unit> Handle(UpdateDeveloperCommand request, CancellationToken cancellationToken)
        {
            var developer = await _developerRepository.GetById(request.Id);

            if (developer != null)
            {
                developer.Update(
                    name: request.Name,
                    workingHours: request.WorkingHours,
                    experience: request.Experience
                );

                _developerRepository.Update(developer);

                await _unityOfWork.Commit();

                return Unit.Value;
            }

            return Unit.Value;
        }
    }
}