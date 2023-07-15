using MediatR;

using Domain.Shared.Handlers;
using Domain.Shared.Repositories;
using Domain.Branch.Commands;
using Domain.Branch.Repositories;

namespace Domain.Method.Handlers
{
    public class DeleteBranchHandler : Handler<DeleteBranchCommand>
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IUnityOfWork _unityOfWork;
        public DeleteBranchHandler(IBranchRepository branchRepository, IUnityOfWork unityOfWork)
        {
            _branchRepository = branchRepository;
            _unityOfWork = unityOfWork;
        }

        public override async Task<Unit> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
        {
            var branch = await _branchRepository.GetById(request.Id);

            if (branch != null)
            {
                _branchRepository.Delete(branch);

                await _unityOfWork.Commit();

                return Unit.Value;
            }

            return Unit.Value;
        }
    }
}