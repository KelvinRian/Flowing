using Flowing.Domain.Commands.Action;
using Flowing.Domain.Enums;
using Flowing.Domain.Interfaces.Services;
using Flowing.Domain.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace Flowing.Api.Controllers
{
    [ApiController]
    public class ActionsController : HttpControllerBase
    {
        private readonly IActionService _actionService;
        private readonly IDomainNotificationHandler _notifications;

        public ActionsController(IActionService actionService, IDomainNotificationHandler notifications)
        {
            _actionService = actionService;
            _notifications = notifications;
        }

        [HttpPost("goals/{goalId}/action")]
        public async Task<IActionResult> AddAction([FromRoute] Guid goalId, [FromBody] AddActionCommand command)
        {
            await _actionService.AddAction(command, goalId);
            return CustomResponse(_notifications);
        }

        [HttpPut("actions/{actionId}")]
        public async Task<IActionResult> UpdateAction([FromRoute] Guid actionId, [FromBody] UpdateActionCommand command)
        {
            await _actionService.UpdateAction(command, actionId);
            return CustomResponse(_notifications);
        }

        [HttpPut("actions/{actionId}/inactivate")]
        public async Task<IActionResult> Inactivate([FromRoute] Guid actionId)
        {
            await _actionService.Inactivate(actionId);
            return CustomResponse(_notifications);
        }

        [HttpPut("actions/{actionId}/change-status-to/{status}")]
        public async Task<IActionResult> ChangeStatus([FromRoute] Guid actionId, Status status)
        {
            await _actionService.ChangeStatus(actionId, status);
            return CustomResponse(_notifications);
        }
    }
}
