namespace NotificationApp
{
    // Opdracht 10
    public class TimestampNotificationDecorator : NotificationDecorator
    {
        public TimestampNotificationDecorator(INotificationService notificationService)
            : base(notificationService)
        {
        }

        public override void Send(string recipient, string message)
        {
            // Extra gedrag: huidige tijd voor het bericht zetten
            string time = DateTime.Now.ToString("HH:mm");
            string timestampedMessage = $"[{time}] {message}";

            // Doorgeven aan het ingepakte object
            notificationService.Send(recipient, timestampedMessage);
        }
    }
}
