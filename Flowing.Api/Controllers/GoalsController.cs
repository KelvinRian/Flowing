using Flowing.Domain.Commands;
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
    }
}
