using MoneyControl.Business.Interfaces;

namespace MoneyControl.Business.Notifications;

public class Notifier : INotifier
{
    private List<Notification> _notifications;

    public Notifier()
    {
        _notifications = new List<Notification>();
    }

    public void Add(Notification notification)
    {
        _notifications.Add(notification);
    }
    public List<Notification> GetNotifications()
    {
        return _notifications;
    }
    public bool HaveNotification()
    {
        return _notifications.Any();
    }
}
