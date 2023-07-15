using MediatR;

using Domain.Shared.Handlers;
using Domain.Shared.Repositories;
using Domain.FileHistory.Commands;
using Domain.FileHistory.Repositories;

namespace Domain.FileHistory.Handlers
{
    public class UpdateFileHistoryHandler : Handler<UpdateFileHistoryCommand>
    {
        private readonly IFileHistoryRepository _fileHistoryRepository;
        private readonly IUnityOfWork _unityOfWork;
        public UpdateFileHistoryHandler(IFileHistoryRepository fileHistoryRepository, IUnityOfWork unityOfWork)
        {
            _fileHistoryRepository = fileHistoryRepository;
            _unityOfWork = unityOfWork;
        }

        public override async Task<Unit> Handle(UpdateFileHistoryCommand request, CancellationToken cancellationToken)
        {
            var fileHistory = await _fileHistoryRepository.GetById(request.Id);

            if (fileHistory != null)
            {
                fileHistory.Update(
                    linesAdded: request.LinesAdded,
                    linesRemoved: request.LinesRemoved,
                    operation: request.Operation
                );

                _fileHistoryRepository.Update(fileHistory);

                await _unityOfWork.Commit();

                return Unit.Value;
            }

            return Unit.Value;
        }
    }
}