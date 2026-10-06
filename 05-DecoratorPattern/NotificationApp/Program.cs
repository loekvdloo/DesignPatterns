namespace NotificationApp
{
    internal class Program
    {
        const string Recipient = "student@school.nl";

        static void Main(string[] args)
        {
            // ---------- Opdracht 1: beginsituatie ----------
            Header("Opdracht 1 - Beginsituatie");
            INotificationService notification = new EmailNotificationService();
            notification.Send(Recipient, "Je rooster is gewijzigd.");

            // ---------- Opdracht 2: logging met inheritance ----------
            Header("Opdracht 2 - Logging met inheritance");
            new LoggedEmailNotificationService().Send(Recipient, "Je rooster is gewijzigd.");
            new LoggedSmsNotificationService().Send("0612345678", "Je rooster is gewijzigd.");

            // ---------- Opdracht 3: urgent met inheritance ----------
            Header("Opdracht 3 - Urgent met inheritance");
            new UrgentEmailNotificationService().Send(Recipient, "Je rooster is gewijzigd.");
            new UrgentSmsNotificationService().Send("0612345678", "Je rooster is gewijzigd.");

            // ---------- Opdracht 6: LoggingNotificationDecorator ----------
            Header("Opdracht 6 - LoggingNotificationDecorator (Email)");
            notification = new EmailNotificationService();
            notification = new LoggingNotificationDecorator(notification);
            notification.Send(Recipient, "Je rooster is gewijzigd.");

            Header("Opdracht 6 - LoggingNotificationDecorator (SMS)");
            notification = new SmsNotificationService();
            notification = new LoggingNotificationDecorator(notification);
            notification.Send("0612345678", "Je rooster is gewijzigd.");

            // ---------- Opdracht 7: UrgentNotificationDecorator ----------
            Header("Opdracht 7 - UrgentNotificationDecorator");
            notification = new UrgentNotificationDecorator(
                new EmailNotificationService()
            );
            notification.Send(Recipient, "Je leslokaal is gewijzigd.");

            // ---------- Opdracht 8 + 9: combineren en volgorde ----------
            Header("Opdracht 9 - Variant A: Logging -> Urgent -> Email");
            notification = new LoggingNotificationDecorator(
                new UrgentNotificationDecorator(
                    new EmailNotificationService()
                )
            );
            notification.Send(Recipient, "Je rooster is gewijzigd.");

            Header("Opdracht 9 - Variant B: Urgent -> Logging -> Email");
            notification = new UrgentNotificationDecorator(
                new LoggingNotificationDecorator(
                    new EmailNotificationService()
                )
            );
            notification.Send(Recipient, "Je rooster is gewijzigd.");

            // Extra: hier zie je wél verschil in uitvoer door de volgorde
            Header("Opdracht 9 - Extra: Timestamp -> Urgent -> Email");
            notification = new TimestampNotificationDecorator(
                new UrgentNotificationDecorator(
                    new EmailNotificationService()
                )
            );
            notification.Send(Recipient, "Je rooster is gewijzigd.");

            Header("Opdracht 9 - Extra: Urgent -> Timestamp -> Email");
            notification = new UrgentNotificationDecorator(
                new TimestampNotificationDecorator(
                    new EmailNotificationService()
                )
            );
            notification.Send(Recipient, "Je rooster is gewijzigd.");

            // ---------- Opdracht 10: TimestampNotificationDecorator ----------
            Header("Opdracht 10 - Logging -> Timestamp -> Urgent -> Email");
            notification = new LoggingNotificationDecorator(
                new TimestampNotificationDecorator(
                    new UrgentNotificationDecorator(
                        new EmailNotificationService()
                    )
                )
            );
            notification.Send(Recipient, "Je rooster is gewijzigd.");

            Header("Opdracht 10 - Logging -> Timestamp -> Urgent -> SMS");
            notification = new LoggingNotificationDecorator(
                new TimestampNotificationDecorator(
                    new UrgentNotificationDecorator(
                        new SmsNotificationService()
                    )
                )
            );
            notification.Send("0612345678", "Je rooster is gewijzigd.");

            // ---------- Opdracht 16: eindopdracht ----------
            // Schema:
            // LoggingNotificationDecorator
            //   ↓
            // TimestampNotificationDecorator
            //   ↓
            // UrgentNotificationDecorator
            //   ↓
            // SmsNotificationService
            Header("Opdracht 16 - Eindopdracht (SMS + urgent + timestamp + logging)");
            INotificationService eindNotificatie =
                new LoggingNotificationDecorator(
                    new TimestampNotificationDecorator(
                        new UrgentNotificationDecorator(
                            new SmsNotificationService()
                        )
                    )
                );
            eindNotificatie.Send("0612345678", "De toets van morgen is verplaatst naar lokaal 2.14.");

            Console.ReadLine();
        }

        static void Header(string title)
        {
            Console.WriteLine($"===== {title} =====");
        }
    }
}
