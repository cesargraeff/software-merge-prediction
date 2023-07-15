using MediatR;
using Microsoft.AspNetCore.Mvc;

using Domain.Method.Commands;

namespace Application.Controllers.Method
{
    [Route("v1/methods")]
    [ApiController]
    public class MethodController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MethodController(IMediator mediator)
            => _mediator = mediator;

        [HttpPost]
        public async Task<Unit> Create([FromBody] CreateMethodCommand command)
        {
            var result = await _mediator.Send(command);

            return Unit.Value;
        }

        [HttpPut]
        public async Task<Unit> Update([FromBody] UpdateMethodCommand command)
        {
            var result = await _mediator.Send(command);

            return Unit.Value;
        }

        [HttpDelete]
        public async Task<Unit> Delete([FromBody] DeleteMethodCommand command)
        {
            var result = await _mediator.Send(command);

            return Unit.Value;
        }
    }
}