namespace NotificationApp
{
    // Basis Decorator:
    // IS-A  INotificationService (implementeert de interface)
    // HAS-A INotificationService (bevat het ingepakte object)
    public abstract class NotificationDecorator : INotificationService
    {
        protected INotificationService notificationService;

        public NotificationDecorator(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        public abstract void Send(string recipient, string message);
    }
}
