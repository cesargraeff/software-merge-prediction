using MediatR;

using Domain.Shared.Handlers;
using Domain.Shared.Repositories;
using Domain.FileLine.Commands;
using Domain.FileLine.Repositories;

namespace Domain.FileLine.Handlers
{
    public class CreateFileLineHandler : Handler<CreateFileLineCommand>
    {
        private readonly IFileLineRepository _fileLineRepository;
        private readonly IUnityOfWork _unityOfWork;
        public CreateFileLineHandler(IFileLineRepository fileLineRepository, IUnityOfWork unityOfWork)
        {
            _fileLineRepository = fileLineRepository;
            _unityOfWork = unityOfWork;
        }

        public override async Task<Unit> Handle(CreateFileLineCommand request, CancellationToken cancellationToken)
        {
            var fileLine = new Domain.FileLine.Models.FileLine(
                line: request.Line,
                code: request.Code,
                operation: request.Operation
            );

            await _fileLineRepository.Create(fileLine);

            await _unityOfWork.Commit();

            return Unit.Value;
        }
    }
}