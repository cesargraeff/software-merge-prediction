using MediatR;

using Domain.Shared.Handlers;
using Domain.Shared.Repositories;
using Domain.Commit.Commands;
using Domain.Commit.Repositories;

namespace Domain.Commit.Handlers
{
    public class UpdateCommitHandler : Handler<UpdateCommitCommand>
    {
        private readonly ICommitRepository _commitRepository;
        private readonly IUnityOfWork _unityOfWork;
        public UpdateCommitHandler(ICommitRepository commitRepository, IUnityOfWork unityOfWork)
        {
            _commitRepository = commitRepository;
            _unityOfWork = unityOfWork;
        }

        public override async Task<Unit> Handle(UpdateCommitCommand request, CancellationToken cancellationToken)
        {
            var commit = await _commitRepository.GetById(request.Id);

            if (commit != null)
            {
                commit.Update(
                    code: request.Code,
                    description: request.Description,
                    date: request.Date,
                    conflict: request.Conflict
                );
                _commitRepository.Update(commit);

                await _unityOfWork.Commit();

                return Unit.Value;
            }

            return Unit.Value;
        }
    }
}