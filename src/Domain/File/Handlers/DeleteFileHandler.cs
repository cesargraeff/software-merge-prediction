using MediatR;

using Domain.Shared.Handlers;
using Domain.Shared.Repositories;
using Domain.File.Commands;
using Domain.File.Repositories;

namespace Domain.File.Handlers
{
    public class DeleteFileHandler : Handler<DeleteFileCommand>
    {
        private readonly IFileRepository _fileRepository;
        private readonly IUnityOfWork _unityOfWork;
        public DeleteFileHandler(IFileRepository fileRepository, IUnityOfWork unityOfWork)
        {
            _fileRepository = fileRepository;
            _unityOfWork = unityOfWork;
        }

        public override async Task<Unit> Handle(DeleteFileCommand request, CancellationToken cancellationToken)
        {
            var file = await _fileRepository.GetById(request.Id);

            if (file != null)
            {
                _fileRepository.Delete(file);

                await _unityOfWork.Commit();

                return Unit.Value;
            }

            return Unit.Value;
        }
    }
}