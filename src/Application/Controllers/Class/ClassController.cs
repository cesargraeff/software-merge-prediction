using MediatR;
using Microsoft.AspNetCore.Mvc;

using Domain.Class.Commands;

namespace Application.Controllers.Class
{
    [Route("v1/classes")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ClassController(IMediator mediator)
            => _mediator = mediator;

        [HttpPost]
        public async Task<Unit> Create([FromBody] CreateClassCommand command)
        {
            var result = await _mediator.Send(command);

            return Unit.Value;
        }

        [HttpPut]
        public async Task<Unit> Update([FromBody] UpdateClassCommand command)
        {
            var result = await _mediator.Send(command);

            return Unit.Value;
        }

        [HttpDelete]
        public async Task<Unit> Delete([FromBody] DeleteClassCommand command)
        {
            var result = await _mediator.Send(command);

            return Unit.Value;
        }
    }
}