namespace Flowing.Domain.Notifications
{
    public interface IDomainNotificationHandler
    {
        void Add(DomainNotification notification);
        bool HasNotifications();
        IReadOnlyCollection<DomainNotification> GetNotifications();
    }
}
