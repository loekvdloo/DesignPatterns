namespace NotificationApp
{
    // Opdracht 3: urgent via inheritance
    public class UrgentSmsNotificationService : SmsNotificationService
    {
        public override void Send(string recipient, string message)
        {
            base.Send(recipient, "[URGENT] " + message);
        }
    }
}
