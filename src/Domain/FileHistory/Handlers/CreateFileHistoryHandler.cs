using MediatR;

using Domain.Shared.Handlers;
using Domain.Shared.Repositories;
using Domain.FileHistory.Commands;
using Domain.FileHistory.Repositories;

namespace Domain.FileHistory.Handlers
{
    public class CreateFileHistoryHandler : Handler<CreateFileHistoryCommand>
    {
        private readonly IFileHistoryRepository _fileHistoryRepository;
        private readonly IUnityOfWork _unityOfWork;
        public CreateFileHistoryHandler(IFileHistoryRepository fileHistoryRepository, IUnityOfWork unityOfWork)
        {
            _fileHistoryRepository = fileHistoryRepository;
            _unityOfWork = unityOfWork;
        }

        public override async Task<Unit> Handle(CreateFileHistoryCommand request, CancellationToken cancellationToken)
        {
            var fileHistory = new Domain.FileHistory.Models.FileHistory(
                linesAdded: request.LinesAdded,
                linesRemoved: request.LinesRemoved,
                operation: request.Operation
            );

            await _fileHistoryRepository.Create(fileHistory);

            await _unityOfWork.Commit();

            return Unit.Value;
        }
    }
}