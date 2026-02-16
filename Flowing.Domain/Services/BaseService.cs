using Flowing.Domain.Notifications;

namespace Flowing.Domain.Services
{
    public abstract class BaseService
    {
        protected readonly IDomainNotificationHandler _notifications;

        protected BaseService(IDomainNotificationHandler notifications)
        {
            _notifications = notifications;
        }

        protected void Notify(string key, string message)
        {
            _notifications.Add(new DomainNotification(key, message));
        }
    }
}
