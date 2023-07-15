using MediatR;

using Domain.Shared.Handlers;
using Domain.Shared.Repositories;
using Domain.File.Commands;
using Domain.File.Repositories;

namespace Domain.File.Handlers
{
    public class CreateFileHandler : Handler<CreateFileCommand>
    {
        private readonly IFileRepository _fileRepository;
        private readonly IUnityOfWork _unityOfWork;
        public CreateFileHandler(IFileRepository fileRepository, IUnityOfWork unityOfWork)
        {
            _fileRepository = fileRepository;
            _unityOfWork = unityOfWork;
        }

        public override async Task<Unit> Handle(CreateFileCommand request, CancellationToken cancellationToken)
        {
            var file = new Domain.File.Models.File(
                name: request.Name,
                path: request.Path
            );

            await _fileRepository.Create(file);

            await _unityOfWork.Commit();

            return Unit.Value;
        }
    }
}