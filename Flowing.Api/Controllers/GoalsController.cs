using Flowing.Domain.Commands.Goal;
using Flowing.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Flowing.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GoalsController : ControllerBase
    {
        private readonly IGoalService _goalService;

        public GoalsController(IGoalService goalService)
        {
            _goalService = goalService;
        }

        [HttpPost]
        public async Task<IActionResult> AddGoal([FromBody] AddGoalCommand command)
        {
            await _goalService.AddGoal(command);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateGoalCommand updateCommand)
        {
            await _goalService.UpdateGoal(id, updateCommand);
            return Ok();
        }

        // TODO FINISH
        // TODO GET Goals
        // TODO DELETE Goal
        // TODO GET GOAL WITH ACTIONS
    }
}
