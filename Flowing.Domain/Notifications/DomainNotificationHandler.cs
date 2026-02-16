namespace Flowing.Domain.Notifications
{
    public class DomainNotificationHandler : IDomainNotificationHandler
    {
        private readonly List<DomainNotification> _notifications = new();

        public void Add(DomainNotification notification)
            => _notifications.Add(notification);

        public bool HasNotifications()
            => _notifications.Any();

        public IReadOnlyCollection<DomainNotification> GetNotifications()
            => _notifications.AsReadOnly();
    }
}
