namespace NotificationApp
{
    // Opdracht 2: logging via inheritance
    public class LoggedSmsNotificationService : SmsNotificationService
    {
        public override void Send(string recipient, string message)
        {
            Console.WriteLine("LOG: notificatie wordt verstuurd");
            base.Send(recipient, message);
        }
    }
}
