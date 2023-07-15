using MediatR;

using Domain.Shared.Handlers;
using Domain.Shared.Repositories;
using Domain.Scenario.Commands;
using Domain.Scenario.Repositories;

namespace Domain.Scenario.Handlers
{
    public class CreateScenarioHandler : Handler<CreateScenarioCommand>
    {
        private readonly IScenarioRepository _scenarioRepository;
        private readonly IUnityOfWork _unityOfWork;
        public CreateScenarioHandler(IScenarioRepository scenarioRepository, IUnityOfWork unityOfWork)
        {
            _scenarioRepository = scenarioRepository;
            _unityOfWork = unityOfWork;
        }

        public override async Task<Unit> Handle(CreateScenarioCommand request, CancellationToken cancellationToken)
        {
            var scenario = new Domain.Scenario.Models.Scenario(
                name: request.Name,
                description: request.Description,
                criticality: request.Criticality
            );

            await _scenarioRepository.Create(scenario);

            await _unityOfWork.Commit();

            return Unit.Value;
        }
    }
}