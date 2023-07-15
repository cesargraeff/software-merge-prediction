using MediatR;

using Domain.Shared.Handlers;
using Domain.Shared.Repositories;
using Domain.FileLine.Commands;
using Domain.FileLine.Repositories;

namespace Domain.FileLine.Handlers
{
    public class UpdateFileLineHandler : Handler<UpdateFileLineCommand>
    {
        private readonly IFileLineRepository _fileLineRepository;
        private readonly IUnityOfWork _unityOfWork;
        public UpdateFileLineHandler(IFileLineRepository fileLineRepository, IUnityOfWork unityOfWork)
        {
            _fileLineRepository = fileLineRepository;
            _unityOfWork = unityOfWork;
        }

        public override async Task<Unit> Handle(UpdateFileLineCommand request, CancellationToken cancellationToken)
        {
            var fileLine = await _fileLineRepository.GetById(request.Id);

            if (fileLine != null)
            {
                fileLine.Update(
                    line: request.Line,
                    code: request.Code,
                    operation: request.Operation
                );

                _fileLineRepository.Update(fileLine);

                await _unityOfWork.Commit();

                return Unit.Value;
            }

            return Unit.Value;
        }
    }
}