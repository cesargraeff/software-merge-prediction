using MediatR;
using Microsoft.AspNetCore.Mvc;

using Domain.Task.Commands;

namespace Application.Controllers.Task
{
    [Route("v1/tasks")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TaskController(IMediator mediator)
            => _mediator = mediator;

        [HttpPost]
        public async Task<Unit> Create([FromBody] CreateTaskCommand command)
        {
            var result = await _mediator.Send(command);

            return Unit.Value;
        }

        [HttpPut]
        public async Task<Unit> Update([FromBody] UpdateTaskCommand command)
        {
            var result = await _mediator.Send(command);

            return Unit.Value;
        }

        [HttpDelete]
        public async Task<Unit> Delete([FromBody] DeleteTaskCommand command)
        {
            var result = await _mediator.Send(command);

            return Unit.Value;
        }
    }
}