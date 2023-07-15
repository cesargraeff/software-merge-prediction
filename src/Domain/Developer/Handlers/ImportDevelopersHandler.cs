using MediatR;

using Domain.Shared.Handlers;
using Domain.Shared.Repositories;
using Domain.Developer.Commands;
using Domain.Developer.Repositories;
using Domain.Services;

namespace Domain.Developer.Handlers
{
    public class ImportDevelopersHandler : Handler<ImportDevelopersCommand>
    {
        private readonly IDeveloperRepository _developerRepository;
        private readonly IUnityOfWork _unityOfWork;
        private readonly IGitHubService _githubService;

        public ImportDevelopersHandler(IDeveloperRepository developerRepository, IUnityOfWork unityOfWork, IGitHubService githubService)
        {
            _developerRepository = developerRepository;
            _unityOfWork = unityOfWork;
            _githubService = githubService;
        }

        public override async Task<Unit> Handle(ImportDevelopersCommand request, CancellationToken cancellationToken)
        {
            var developers = await _githubService.Developers();

            foreach (var dev in developers)
            {
                var exist = await _developerRepository.GetByCode(dev.Id);
                if (exist == null)
                {

                    var developer = new Domain.Developer.Models.Developer(
                        name: dev.Login ?? "",
                        workingHours: 0,
                        experience: 0,
                        code: dev.Id
                    );

                    await _developerRepository.Create(developer);
                    await _unityOfWork.Commit();
                }
            }

            return Unit.Value;
        }
    }
}