using MediatR;

using Domain.Shared.Handlers;
using Domain.Shared.Repositories;
using Domain.File.Commands;
using Domain.File.Repositories;

namespace Domain.File.Handlers
{
    public class UpdateFileHandler : Handler<UpdateFileCommand>
    {
        private readonly IFileRepository _fileRepository;
        private readonly IUnityOfWork _unityOfWork;
        public UpdateFileHandler(IFileRepository fileRepository, IUnityOfWork unityOfWork)
        {
            _fileRepository = fileRepository;
            _unityOfWork = unityOfWork;
        }

        public override async Task<Unit> Handle(UpdateFileCommand request, CancellationToken cancellationToken)
        {
            var file = await _fileRepository.GetById(request.Id);

            if (file != null)
            {
                file.Update(
                    name: request.Name,
                    path: request.Path
                );

                _fileRepository.Update(file);

                await _unityOfWork.Commit();

                return Unit.Value;
            }

            return Unit.Value;
        }
    }
}