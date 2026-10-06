using ExternalWhatsAppLibrary;

namespace NotificationApp
{
    public class WhatsAppNotificationAdapter : INotificationService
    {
        private readonly WhatsAppClient _whatsAppClient;

        public WhatsAppNotificationAdapter(WhatsAppClient whatsAppClient)
        {
            _whatsAppClient = whatsAppClient;
        }

        public void Send(string recipient, string message)
        {
            _whatsAppClient.SendWhatsAppMessage(recipient, message, false);
        }
    }
}
