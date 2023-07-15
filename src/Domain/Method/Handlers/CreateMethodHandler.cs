using MediatR;

using Domain.Shared.Handlers;
using Domain.Shared.Repositories;
using Domain.Method.Commands;
using Domain.Method.Repositories;

namespace Domain.Method.Handlers
{
    public class CreateMethodHandler : Handler<CreateMethodCommand>
    {
        private readonly IMethodRepository _methodRepository;
        private readonly IUnityOfWork _unityOfWork;
        public CreateMethodHandler(IMethodRepository methodRepository, IUnityOfWork unityOfWork)
        {
            _methodRepository = methodRepository;
            _unityOfWork = unityOfWork;
        }

        public override async Task<Unit> Handle(CreateMethodCommand request, CancellationToken cancellationToken)
        {
            var method = new Domain.Method.Models.Method(
                name: request.Name,
                startLine: request.StartLine,
                finishLine: request.FinishLine
            );

            await _methodRepository.Create(method);

            await _unityOfWork.Commit();

            return Unit.Value;
        }
    }
}