namespace NotificationApp
{
    // Opdracht 7
    public class UrgentNotificationDecorator : NotificationDecorator
    {
        public UrgentNotificationDecorator(INotificationService notificationService)
            : base(notificationService)
        {
        }

        public override void Send(string recipient, string message)
        {
            // Extra gedrag: [URGENT] voor het bericht zetten
            string urgentMessage = "[URGENT] " + message;

            // Doorgeven aan het ingepakte object
            notificationService.Send(recipient, urgentMessage);
        }
    }
}
