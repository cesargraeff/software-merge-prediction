using MediatR;

using Domain.Shared.Handlers;
using Domain.Shared.Repositories;
using Domain.Method.Commands;
using Domain.Method.Repositories;

namespace Domain.Method.Handlers
{
    public class UpdateMethodHandler : Handler<UpdateMethodCommand>
    {
        private readonly IMethodRepository _methodRepository;
        private readonly IUnityOfWork _unityOfWork;
        public UpdateMethodHandler(IMethodRepository methodRepository, IUnityOfWork unityOfWork)
        {
            _methodRepository = methodRepository;
            _unityOfWork = unityOfWork;
        }

        public override async Task<Unit> Handle(UpdateMethodCommand request, CancellationToken cancellationToken)
        {
            var method = await _methodRepository.GetById(request.Id);

            if (method != null)
            {
                method.Update(
                    name: request.Name,
                    startLine: request.StartLine,
                    finishLine: request.FinishLine
                );

                _methodRepository.Update(method);

                await _unityOfWork.Commit();

                return Unit.Value;
            }

            return Unit.Value;
        }
    }
}