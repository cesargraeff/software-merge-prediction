using MediatR;

using Domain.Shared.Handlers;
using Domain.Shared.Repositories;
using Domain.FileHistory.Commands;
using Domain.FileHistory.Repositories;

namespace Domain.FileHistory.Handlers
{
    public class DeleteFileHistoryHandler : Handler<DeleteFileHistoryCommand>
    {
        private readonly IFileHistoryRepository _fileHistoryRepository;
        private readonly IUnityOfWork _unityOfWork;
        public DeleteFileHistoryHandler(IFileHistoryRepository fileHistoryRepository, IUnityOfWork unityOfWork)
        {
            _fileHistoryRepository = fileHistoryRepository;
            _unityOfWork = unityOfWork;
        }

        public override async Task<Unit> Handle(DeleteFileHistoryCommand request, CancellationToken cancellationToken)
        {
            var fileHistory = await _fileHistoryRepository.GetById(request.Id);

            if (fileHistory != null)
            {
                _fileHistoryRepository.Delete(fileHistory);

                await _unityOfWork.Commit();

                return Unit.Value;
            }

            return Unit.Value;
        }
    }
}