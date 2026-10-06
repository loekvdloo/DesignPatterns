using System;

namespace NotificationApp
{
    public class NotificationManager
    {
        private INotificationService _notificationService;

        public void Send(string recipient, string message, INotificationService notificationService)
        {
            _notificationService = notificationService;
            _notificationService.Send(recipient, message);
        }
    }
}
