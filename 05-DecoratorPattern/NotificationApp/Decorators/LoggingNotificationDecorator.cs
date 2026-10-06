namespace NotificationApp
{
    // Opdracht 6
    public class LoggingNotificationDecorator : NotificationDecorator
    {
        public LoggingNotificationDecorator(INotificationService notificationService)
            : base(notificationService)
        {
        }

        public override void Send(string recipient, string message)
        {
            // Extra gedrag: logging
            Console.WriteLine($"LOG: notificatie naar {recipient}");

            // Doorgeven aan het ingepakte object
            notificationService.Send(recipient, message);
        }
    }
}
