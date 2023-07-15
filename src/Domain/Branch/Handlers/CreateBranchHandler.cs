using MediatR;

using Domain.Shared.Handlers;
using Domain.Shared.Repositories;
using Domain.Branch.Commands;
using Domain.Branch.Repositories;

namespace Domain.Branch.Handlers
{
    public class CreateBranchHandler : Handler<CreateBranchCommand>
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IUnityOfWork _unityOfWork;
        public CreateBranchHandler(IBranchRepository branchRepository, IUnityOfWork unityOfWork)
        {
            _branchRepository = branchRepository;
            _unityOfWork = unityOfWork;
        }

        public override async Task<Unit> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
        {
            var branch = new Domain.Branch.Models.Branch(
                name: request.Name
            );

            await _branchRepository.Create(branch);

            await _unityOfWork.Commit();

            return Unit.Value;
        }
    }
}