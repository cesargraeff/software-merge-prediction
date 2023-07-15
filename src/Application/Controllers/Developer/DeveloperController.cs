using MediatR;
using Microsoft.AspNetCore.Mvc;

using Domain.Developer.Commands;
using Domain.Developer.Repositories;

namespace Application.Controllers.Developer
{
    [Route("v1/developers")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IDeveloperRepository _developerRepository;

        public DeveloperController(IMediator mediator, IDeveloperRepository developerRepository)
        {
            _mediator = mediator;
            _developerRepository = developerRepository;
        }

        [HttpGet]
        public async Task<ActionResult> List()
        {
            return new JsonResult(await _developerRepository.List());
        }

        [HttpPost]
        public async Task<Unit> Create([FromBody] CreateDeveloperCommand command)
        {
            var result = await _mediator.Send(command);

            return Unit.Value;
        }

        [HttpPut]
        public async Task<Unit> Update([FromBody] UpdateDeveloperCommand command)
        {
            var result = await _mediator.Send(command);

            return Unit.Value;
        }

        [HttpDelete]
        public async Task<Unit> Delete([FromBody] DeleteDeveloperCommand command)
        {
            var result = await _mediator.Send(command);

            return Unit.Value;
        }
    }
}