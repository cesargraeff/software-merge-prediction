using MediatR;

using Domain.Shared.Handlers;
using Domain.Shared.Repositories;
using Domain.Scenario.Commands;
using Domain.Scenario.Repositories;

namespace Domain.Scenario.Handlers
{
    public class UpdateScenarioHandler : Handler<UpdateScenarioCommand>
    {
        private readonly IScenarioRepository _scenarioRepository;
        private readonly IUnityOfWork _unityOfWork;
        public UpdateScenarioHandler(IScenarioRepository scenarioRepository, IUnityOfWork unityOfWork)
        {
            _scenarioRepository = scenarioRepository;
            _unityOfWork = unityOfWork;
        }

        public override async Task<Unit> Handle(UpdateScenarioCommand request, CancellationToken cancellationToken)
        {
            var scenario = await _scenarioRepository.GetById(request.Id);

            if (scenario != null)
            {
                scenario.Update(
                    name: request.Name,
                    description: request.Description,
                    criticality: request.Criticality
                );

                _scenarioRepository.Update(scenario);

                await _unityOfWork.Commit();

                return Unit.Value;
            }

            return Unit.Value;
        }
    }
}