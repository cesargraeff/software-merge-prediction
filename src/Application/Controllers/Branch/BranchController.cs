using MediatR;
using Microsoft.AspNetCore.Mvc;

using Domain.Branch.Commands;
using Infrastructure.PostgreSQL.Repositories.Branch;
using Domain.Branch.Repositories;

namespace Application.Controllers.Branch
{
    [Route("v1/branches")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IBranchRepository _branch;
        public BranchController(IMediator mediator, IBranchRepository branch)
        {
            _mediator = mediator;
            _branch = branch;
        }

        [HttpGet]
        public async Task<ActionResult> List()
        {
            return new JsonResult(await _branch.List());
        }

        [HttpPost]
        public async Task<Unit> Create([FromBody] CreateBranchCommand command)
        {
            var result = await _mediator.Send(command);

            return Unit.Value;
        }

        [HttpPut]
        public async Task<Unit> Update([FromBody] UpdateBranchCommand command)
        {
            var result = await _mediator.Send(command);

            return Unit.Value;
        }

        [HttpDelete]
        public async Task<Unit> Delete([FromBody] DeleteBranchCommand command)
        {
            var result = await _mediator.Send(command);

            return Unit.Value;
        }
    }
}