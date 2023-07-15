using MediatR;

using Domain.Shared.Handlers;
using Domain.Shared.Repositories;
using Domain.Branch.Commands;
using Domain.Branch.Repositories;

namespace Domain.Branch.Handlers
{
    public class UpdateBranchHandler : Handler<UpdateBranchCommand>
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IUnityOfWork _unityOfWork;
        public UpdateBranchHandler(IBranchRepository branchRepository, IUnityOfWork unityOfWork)
        {
            _branchRepository = branchRepository;
            _unityOfWork = unityOfWork;
        }

        public override async Task<Unit> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
        {
            var branch = await _branchRepository.GetById(request.Id);

            if (branch != null)
            {
                branch.Update(
                    name: request.Name
                );

                _branchRepository.Update(branch);

                await _unityOfWork.Commit();

                return Unit.Value;
            }

            return Unit.Value;
        }
    }
}