namespace NotificationApp
{
    // Opdracht 3: urgent via inheritance
    public class UrgentEmailNotificationService : EmailNotificationService
    {
        public override void Send(string recipient, string message)
        {
            base.Send(recipient, "[URGENT] " + message);
        }
    }
}
