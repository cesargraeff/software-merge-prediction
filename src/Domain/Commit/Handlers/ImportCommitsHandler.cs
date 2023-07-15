using MediatR;

using Domain.Shared.Handlers;
using Domain.Shared.Repositories;
using Domain.Developer.Commands;
using Domain.Developer.Repositories;
using Domain.Services;
using Domain.Branch.Commands;
using Domain.Commit.Repositories;

namespace Domain.Developer.Handlers
{
    public class ImportCommitsHandler : Handler<ImportCommitsCommand>
    {
        private readonly IDeveloperRepository _developerRepository;
        private readonly IUnityOfWork _unityOfWork;
        private readonly IGitHubService _githubService;
        private readonly ICommitRepository _commitRepository;

        public ImportCommitsHandler(IDeveloperRepository developerRepository, IUnityOfWork unityOfWork, IGitHubService githubService, ICommitRepository commitRepository)
        {
            _developerRepository = developerRepository;
            _unityOfWork = unityOfWork;
            _githubService = githubService;
            _commitRepository = commitRepository;
        }

        public override async Task<Unit> Handle(ImportCommitsCommand request, CancellationToken cancellationToken)
        {
            var commits = await _githubService.Commits();

            foreach (var commit in commits)
            {
                var developer = await _developerRepository.GetByCode(commit.Author.Id);

                if (developer == null)
                {
                    developer = new Domain.Developer.Models.Developer(
                        name: commit.Author.Login ?? "",
                        workingHours: 0,
                        experience: 0,
                        code: commit.Author.Id
                    );

                    await _developerRepository.Create(developer);
                    await _unityOfWork.Commit();
                }

                var model = new Domain.Commit.Models.Commit(
                    code: commit.Sha,
                    description: commit.Commit.Message,
                    date: commit.Committer.Date,
                    conflict: false,
                    developerId: developer.Id
                );

                await _commitRepository.Create(model);
                await _unityOfWork.Commit();
            }

            return Unit.Value;
        }
    }
}