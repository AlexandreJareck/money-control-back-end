using MoneyControl.Business.Notifications;

namespace MoneyControl.Business.Interfaces
{
    public interface INotifier
    {
        bool HaveNotification();
        List<Notification> GetNotifications();
        void Add(Notification notification);
    }
}
