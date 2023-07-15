using MediatR;

using Domain.Shared.Handlers;
using Domain.Shared.Repositories;
using Domain.Commit.Commands;
using Domain.Commit.Repositories;

namespace Domain.Commit.Handlers
{
    public class DeleteCommitHandler : Handler<DeleteCommitCommand>
    {
        private readonly ICommitRepository _commitRepository;
        private readonly IUnityOfWork _unityOfWork;
        public DeleteCommitHandler(ICommitRepository commitRepository, IUnityOfWork unityOfWork)
        {
            _commitRepository = commitRepository;
            _unityOfWork = unityOfWork;
        }

        public override async Task<Unit> Handle(DeleteCommitCommand request, CancellationToken cancellationToken)
        {
            var commit = await _commitRepository.GetById(request.Id);

            if (commit != null)
            {
                _commitRepository.Delete(commit);

                await _unityOfWork.Commit();

                return Unit.Value;
            }

            return Unit.Value;
        }
    }
}