using MediatR;
using Microsoft.AspNetCore.Mvc;

using Domain.File.Commands;

namespace Application.Controllers.File
{
    [Route("v1/files")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FileController(IMediator mediator)
            => _mediator = mediator;

        [HttpPost]
        public async Task<Unit> Create([FromBody] CreateFileCommand command)
        {
            var result = await _mediator.Send(command);

            return Unit.Value;
        }

        [HttpPut]
        public async Task<Unit> Update([FromBody] UpdateFileCommand command)
        {
            var result = await _mediator.Send(command);

            return Unit.Value;
        }

        [HttpDelete]
        public async Task<Unit> Delete([FromBody] DeleteFileCommand command)
        {
            var result = await _mediator.Send(command);

            return Unit.Value;
        }
    }
}