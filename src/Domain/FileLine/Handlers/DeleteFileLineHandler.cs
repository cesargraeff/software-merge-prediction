using MediatR;

using Domain.Shared.Handlers;
using Domain.Shared.Repositories;
using Domain.FileLine.Commands;
using Domain.FileLine.Repositories;

namespace Domain.FileLine.Handlers
{
    public class DeleteFileLineHandler : Handler<DeleteFileLineCommand>
    {
        private readonly IFileLineRepository _fileLineRepository;
        private readonly IUnityOfWork _unityOfWork;
        public DeleteFileLineHandler(IFileLineRepository fileLineRepository, IUnityOfWork unityOfWork)
        {
            _fileLineRepository = fileLineRepository;
            _unityOfWork = unityOfWork;
        }

        public override async Task<Unit> Handle(DeleteFileLineCommand request, CancellationToken cancellationToken)
        {
            var fileLine = await _fileLineRepository.GetById(request.Id);

            if (fileLine != null)
            {
                _fileLineRepository.Delete(fileLine);

                await _unityOfWork.Commit();

                return Unit.Value;
            }

            return Unit.Value;
        }
    }
}