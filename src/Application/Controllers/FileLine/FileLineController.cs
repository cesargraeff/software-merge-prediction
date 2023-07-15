using MediatR;
using Microsoft.AspNetCore.Mvc;

using Domain.FileLine.Commands;

namespace Application.Controllers.FileLine
{
    [Route("v1/filelines")]
    [ApiController]
    public class FileLineController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FileLineController(IMediator mediator)
            => _mediator = mediator;

        [HttpPost]
        public async Task<Unit> Create([FromBody] CreateFileLineCommand command)
        {
            var result = await _mediator.Send(command);

            return Unit.Value;
        }

        [HttpPut]
        public async Task<Unit> Update([FromBody] UpdateFileLineCommand command)
        {
            var result = await _mediator.Send(command);

            return Unit.Value;
        }

        [HttpDelete]
        public async Task<Unit> Delete([FromBody] DeleteFileLineCommand command)
        {
            var result = await _mediator.Send(command);

            return Unit.Value;
        }
    }
}