using MediatR;
using Microsoft.AspNetCore.Mvc;

using Domain.Services;
using Domain.Developer.Commands;
using Domain.Branch.Commands;

namespace Application.Controllers.Functionality
{
    [Route("v1/github")]
    [ApiController]
    public class GitHubController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IGitHubService _gitHubService;

        public GitHubController(IMediator mediator, IGitHubService gitHubService)
        {
            _mediator = mediator;
            _gitHubService = gitHubService;
        }

        [HttpPost]
        public async Task<ActionResult> Test()
        {
            await _mediator.Send(new ImportDevelopersCommand());

            await _mediator.Send(new ImportBranchesCommand());

            await _mediator.Send(new ImportCommitsCommand());

            return new JsonResult(new
            {
                Success = true
            });
        }
    }
}