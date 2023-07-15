using MediatR;
using Microsoft.AspNetCore.Mvc;

using Domain.Functionality.Commands;

namespace Application.Controllers.Functionality
{
    [Route("v1/functionalities")]
    [ApiController]
    public class FunctionalityController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FunctionalityController(IMediator mediator)
            => _mediator = mediator;

        [HttpPost]
        public async Task<Unit> Create([FromBody] CreateFunctionalityCommand command)
        {
            var result = await _mediator.Send(command);

            return Unit.Value;
        }

        [HttpPut]
        public async Task<Unit> Update([FromBody] UpdateFunctionalityCommand command)
        {
            var result = await _mediator.Send(command);

            return Unit.Value;
        }

        [HttpDelete]
        public async Task<Unit> Delete([FromBody] DeleteFunctionalityCommand command)
        {
            var result = await _mediator.Send(command);

            return Unit.Value;
        }
    }
}