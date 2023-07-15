using MediatR;

using Domain.Shared.Handlers;
using Domain.Shared.Repositories;
using Domain.Developer.Commands;
using Domain.Developer.Repositories;

namespace Domain.Developer.Handlers
{
    public class DeleteDeveloperHandler : Handler<DeleteDeveloperCommand>
    {
        private readonly IDeveloperRepository _developerRepository;
        private readonly IUnityOfWork _unityOfWork;
        public DeleteDeveloperHandler(IDeveloperRepository developerRepository, IUnityOfWork unityOfWork)
        {
            _developerRepository = developerRepository;
            _unityOfWork = unityOfWork;
        }

        public override async Task<Unit> Handle(DeleteDeveloperCommand request, CancellationToken cancellationToken)
        {
            var developer = await _developerRepository.GetById(request.Id);

            if (developer != null)
            {
                _developerRepository.Delete(developer);

                await _unityOfWork.Commit();

                return Unit.Value;
            }

            return Unit.Value;
        }
    }
}