using MediatR;
using Microsoft.AspNetCore.Mvc;

using Domain.Commit.Commands;
using Domain.Commit.Repositories;

namespace Application.Controllers.Commit
{
    [Route("v1/commits")]
    [ApiController]
    public class CommitController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICommitRepository _commitRepository;

        public CommitController(IMediator mediator, ICommitRepository commitRepository)
        {
            _mediator = mediator;
            _commitRepository = commitRepository;
        }

        [HttpGet]
        public async Task<ActionResult> List()
        {
            return new JsonResult(await _commitRepository.List());
        }

        [HttpPost]
        public async Task<Unit> Create([FromBody] CreateCommitCommand command)
        {
            var result = await _mediator.Send(command);
            return Unit.Value;
        }

        [HttpPut]
        public async Task<Unit> Update([FromBody] UpdateCommitCommand command)
        {
            var result = await _mediator.Send(command);

            return Unit.Value;
        }

        [HttpDelete]
        public async Task<Unit> Delete([FromBody] DeleteCommitCommand command)
        {
            var result = await _mediator.Send(command);

            return Unit.Value;
        }
    }
}