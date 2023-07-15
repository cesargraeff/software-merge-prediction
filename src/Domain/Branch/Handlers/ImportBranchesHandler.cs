using MediatR;

using Domain.Shared.Handlers;
using Domain.Shared.Repositories;
using Domain.Services;
using Domain.Branch.Commands;
using Domain.Branch.Repositories;

namespace Domain.Developer.Handlers
{
    public class ImportBranchesHandler : Handler<ImportBranchesCommand>
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IUnityOfWork _unityOfWork;
        private readonly IGitHubService _githubService;

        public ImportBranchesHandler(IBranchRepository branchRepository, IUnityOfWork unityOfWork, IGitHubService githubService)
        {
            _branchRepository = branchRepository;
            _unityOfWork = unityOfWork;
            _githubService = githubService;
        }

        public override async Task<Unit> Handle(ImportBranchesCommand request, CancellationToken cancellationToken)
        {
            var branches = await _githubService.Branches();

            foreach (var branch in branches)
            {
                var exist = await _branchRepository.GetByName(branch.Name);
                if (exist == null)
                {
                    var model = new Domain.Branch.Models.Branch(
                       name: branch.Name
                   );
                    await _branchRepository.Create(model);
                    await _unityOfWork.Commit();
                }
            }

            return Unit.Value;
        }
    }
}