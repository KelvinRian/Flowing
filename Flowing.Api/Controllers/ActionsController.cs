using Flowing.Domain.Commands.Action;
using Flowing.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Flowing.Api.Controllers
{
    [ApiController]
    public class ActionsController : ControllerBase
    {
        private readonly IActionService _actionService;

        public ActionsController(IActionService actionService)
        {
            _actionService = actionService;
        }

        [HttpPost("goals/{goalId}/action")]
        public async Task<IActionResult> AddAction([FromRoute] Guid goalId, [FromBody] AddActionCommand command)
        {
            await _actionService.AddAction(command, goalId);
            return Ok();
        }

        // TODO
        // Update
        // Delete
        // Change Status
    }
}
