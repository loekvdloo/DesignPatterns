namespace NotificationApp
{
    public class SmsNotificationService : INotificationService
    {
        // virtual zodat de inheritance-opdrachten (2 en 3) Send kunnen overriden
        public virtual void Send(string recipient, string message)
        {
            Console.WriteLine("SMS");
            Console.WriteLine($"Aan: {recipient}");
            Console.WriteLine($"Bericht: {message}");
            Console.WriteLine();
        }
    }
}
