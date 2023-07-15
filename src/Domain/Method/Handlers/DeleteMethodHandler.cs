using MediatR;

using Domain.Shared.Handlers;
using Domain.Shared.Repositories;
using Domain.Method.Commands;
using Domain.Method.Repositories;

namespace Domain.Method.Handlers
{
    public class DeleteMethodHandler : Handler<DeleteMethodCommand>
    {
        private readonly IMethodRepository _methodRepository;
        private readonly IUnityOfWork _unityOfWork;
        public DeleteMethodHandler(IMethodRepository methodRepository, IUnityOfWork unityOfWork)
        {
            _methodRepository = methodRepository;
            _unityOfWork = unityOfWork;
        }

        public override async Task<Unit> Handle(DeleteMethodCommand request, CancellationToken cancellationToken)
        {
            var method = await _methodRepository.GetById(request.Id);

            if (method != null)
            {
                _methodRepository.Delete(method);

                await _unityOfWork.Commit();

                return Unit.Value;
            }

            return Unit.Value;
        }
    }
}