using MediatR;
using Microsoft.AspNetCore.Mvc;

using Domain.Scenario.Commands;

namespace Application.Controllers.Scenario
{
    [Route("v1/scenarios")]
    [ApiController]
    public class ScenarioController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ScenarioController(IMediator mediator)
            => _mediator = mediator;

        [HttpPost]
        public async Task<Unit> Create([FromBody] CreateScenarioCommand command)
        {
            var result = await _mediator.Send(command);

            return Unit.Value;
        }

        [HttpPut]
        public async Task<Unit> Update([FromBody] UpdateScenarioCommand command)
        {
            var result = await _mediator.Send(command);

            return Unit.Value;
        }

        [HttpDelete]
        public async Task<Unit> Delete([FromBody] DeleteScenarioCommand command)
        {
            var result = await _mediator.Send(command);

            return Unit.Value;
        }
    }
}