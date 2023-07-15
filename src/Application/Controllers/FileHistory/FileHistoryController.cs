using MediatR;
using Microsoft.AspNetCore.Mvc;

using Domain.FileHistory.Commands;

namespace Application.Controllers.FileHistory
{
    [Route("v1/filehistories")]
    [ApiController]
    public class FileHistoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FileHistoryController(IMediator mediator)
            => _mediator = mediator;

        [HttpPost]
        public async Task<Unit> Create([FromBody] CreateFileHistoryCommand command)
        {
            var result = await _mediator.Send(command);

            return Unit.Value;
        }

        [HttpPut]
        public async Task<Unit> Update([FromBody] UpdateFileHistoryCommand command)
        {
            var result = await _mediator.Send(command);

            return Unit.Value;
        }

        [HttpDelete]
        public async Task<Unit> Delete([FromBody] DeleteFileHistoryCommand command)
        {
            var result = await _mediator.Send(command);

            return Unit.Value;
        }
    }
}