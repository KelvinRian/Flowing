using Flowing.Domain.Commands.Goal;
using Flowing.Domain.Interfaces.Services;
using Flowing.Domain.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace Flowing.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GoalsController : HttpControllerBase
    {
        private readonly IGoalService _goalService;
        private readonly IDomainNotificationHandler _notifications;

        public GoalsController(IGoalService goalService, IDomainNotificationHandler notifications)
        {
            _goalService = goalService;
            _notifications = notifications;
        }

        [HttpPost]
        public async Task<IActionResult> AddGoal([FromBody] AddGoalCommand command)
        {
            await _goalService.Add(command);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateGoalCommand updateCommand)
        {
            await _goalService.Update(id, updateCommand);
            return CustomResponse(_notifications);
        }

        [HttpPut("{id}/finish")]
        public async Task<IActionResult> Finish([FromRoute] Guid id)
        {
            await _goalService.Finish(id);
            return CustomResponse(_notifications);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var goals = await _goalService.GetAll();
            return Ok(goals);
        }

        [HttpPut("{id}/Inactivate")]
        public async Task<IActionResult> Inactivate([FromRoute] Guid id)
        {
            await _goalService.Inactivate(id);
            return CustomResponse(_notifications);
        }

        [HttpGet("{id}/with-actions")]
        public async Task<IActionResult> GetWithActions([FromRoute] Guid id)
        {
            var goalWithActions = await _goalService.GetWithActions(id);
            return Ok(goalWithActions);
        }
    }
}
