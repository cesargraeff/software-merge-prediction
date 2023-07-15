using MediatR;

using Domain.Shared.Handlers;
using Domain.Shared.Repositories;
using Domain.Scenario.Commands;
using Domain.Scenario.Repositories;

namespace Domain.Scenario.Handlers
{
    public class DeleteScenarioHandler : Handler<DeleteScenarioCommand>
    {
        private readonly IScenarioRepository _scenarioRepository;
        private readonly IUnityOfWork _unityOfWork;
        public DeleteScenarioHandler(IScenarioRepository scenarioRepository, IUnityOfWork unityOfWork)
        {
            _scenarioRepository = scenarioRepository;
            _unityOfWork = unityOfWork;
        }

        public override async Task<Unit> Handle(DeleteScenarioCommand request, CancellationToken cancellationToken)
        {
            var scenario = await _scenarioRepository.GetById(request.Id);

            if (scenario != null)
            {
                _scenarioRepository.Delete(scenario);

                await _unityOfWork.Commit();

                return Unit.Value;
            }

            return Unit.Value;
        }
    }
}