namespace NotificationApp
{
    public class EmailNotificationService : INotificationService
    {
        // virtual zodat de inheritance-opdrachten (2 en 3) Send kunnen overriden
        public virtual void Send(string recipient, string message)
        {
            Console.WriteLine("EMAIL");
            Console.WriteLine($"Aan: {recipient}");
            Console.WriteLine($"Bericht: {message}");
            Console.WriteLine();
        }
    }
}
