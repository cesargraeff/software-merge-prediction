using MediatR;

using Domain.Shared.Handlers;
using Domain.Shared.Repositories;
using Domain.Commit.Commands;
using Domain.Commit.Repositories;

namespace Domain.Commit.Handlers
{
    public class CreateCommitHandler : Handler<CreateCommitCommand>
    {
        private readonly ICommitRepository _commitRepository;
        private readonly IUnityOfWork _unityOfWork;
        public CreateCommitHandler(ICommitRepository commitRepository, IUnityOfWork unityOfWork)
        {
            _commitRepository = commitRepository;
            _unityOfWork = unityOfWork;
        }

        public override async Task<Unit> Handle(CreateCommitCommand request, CancellationToken cancellationToken)
        {
            var commit = new Domain.Commit.Models.Commit(
                code: request.Code,
                description: request.Description,
                date: request.Date,
                conflict: request.Conflict
            );

            await _commitRepository.Create(commit);

            await _unityOfWork.Commit();

            return Unit.Value;
        }
    }
}