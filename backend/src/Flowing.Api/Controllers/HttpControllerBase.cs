using Flowing.Domain.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace Flowing.Api.Controllers
{
    public abstract class HttpControllerBase : ControllerBase
    {
        protected IActionResult CustomResponse(
            IDomainNotificationHandler notifications)
        {
            if (!notifications.HasNotifications())
                return NoContent();

            if (notifications.GetNotifications()
                .Any(n => n.Key.EndsWith(".NotFound")))
                return NotFound(notifications.GetNotifications());

            return UnprocessableEntity(notifications.GetNotifications());
        }
    }
}
