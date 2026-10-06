# Decorator Pattern – Antwoorden

Uitwerking van het document *Design Patterns – Decorator* (Loek van de Loo). De code staat in [`NotificationApp/`](NotificationApp/); het ingevulde Word-document staat ernaast.

## Opdracht 1 – Onderzoeken

1. Omdat zowel EmailNotificationService als SmsNotificationService de interface INotificationService implementeren. De variabele heeft het type van de interface, dus ieder object dat die interface implementeert past erin (polymorfisme).

2. Beide classes gebruiken de interface INotificationService.

3. De methode void Send(string recipient, string message).

4. De code die Send() aanroept hangt dan niet af van één concrete class. Je kunt zonder die code aan te passen wisselen tussen e-mail en sms, of later nieuwe services toevoegen (Push, WhatsApp). Dat geeft losse koppeling en het is makkelijker te testen.

## Opdracht 2 – Logging met inheritance

Om Send() te kunnen overriden heb ik Send() in EmailNotificationService en SmsNotificationService virtual gemaakt.

```
public class LoggedEmailNotificationService : EmailNotificationService
{
    public override void Send(string recipient, string message)
    {
        Console.WriteLine("LOG: notificatie wordt verstuurd");
        base.Send(recipient, message);
    }
}
```

LoggedSmsNotificationService is precies hetzelfde, maar erft van SmsNotificationService. Uitvoer van de e-mailversie:

```
LOG: notificatie wordt verstuurd
EMAIL
Aan: student@school.nl
Bericht: Je rooster is gewijzigd.
```

Code: 05-DecoratorPattern/NotificationApp/Inheritance/

## Opdracht 3 – Urgent notifications

```
public class UrgentEmailNotificationService : EmailNotificationService
{
    public override void Send(string recipient, string message)
    {
        base.Send(recipient, "[URGENT] " + message);
    }
}
```

UrgentSmsNotificationService werkt hetzelfde met SmsNotificationService. Uitvoer:

```
EMAIL
Aan: student@school.nl
Bericht: [URGENT] Je rooster is gewijzigd.
```

## Opdracht 4 – Denk eerst na

1. 8 classes: per kanaal 4 (basis, Logged, Urgent, LoggedUrgent), en dat voor Email en SMS.

2. Het aantal classes verdubbelt. Per kanaal heb je dan 2 × 2 × 2 = 8 classes, dus 16 in totaal.

3. TimestampEmail, LoggedTimestampEmail, UrgentTimestampEmail en LoggedUrgentTimestampEmail, en dezelfde vier voor SMS. Dat zijn 8 nieuwe classes.

4. Nee. Het werkt technisch wel, maar elke nieuwe uitbreiding verdubbelt het aantal classes, en elk nieuw kanaal (Push, WhatsApp) brengt weer een hele set subclasses mee.

5. Class explosion: het aantal classes groeit veel te hard (kanalen × 2^uitbreidingen). Daarnaast staat dezelfde code (bijvoorbeeld de logregel) in veel classes dubbel, en de combinaties liggen vast in de code; je kunt niet tijdens het draaien kiezen welke extra's je wilt.

## Opdracht 5 – Begrijpen

1. Zodat een decorator overal gebruikt kan worden waar een INotificationService verwacht wordt. De code die Send() aanroept merkt geen verschil, en je kunt een decorator ook weer in een andere decorator stoppen.

2. Dat field is het object dat wordt ingepakt. De decorator doet zijn extra werk en geeft daarna het versturen door aan dat object.

3. Met het type EmailNotificationService zou de decorator alleen e-mail kunnen inpakken. Met de interface kan hij elk object inpakken: Email, SMS, Push, een adapter en ook een andere decorator.

4. IS-A: de decorator ís een INotificationService (hij implementeert de interface), dus hij kan op de plek van een gewone service gebruikt worden. HAS-A: de decorator héeft een INotificationService (compositie, als field), en daar stuurt hij het werk naartoe.

## Opdracht 6 – LoggingDecorator

```
public override void Send(string recipient, string message)
{
    // Extra gedrag: logging
    Console.WriteLine($"LOG: notificatie naar {recipient}");

    // Doorgeven aan het ingepakte object
    notificationService.Send(recipient, message);
}
```

Uitvoer met EmailNotificationService:

```
LOG: notificatie naar student@school.nl
EMAIL
Aan: student@school.nl
Bericht: Je rooster is gewijzigd.
```

Uitvoer met SmsNotificationService:

```
LOG: notificatie naar 0612345678
SMS
Aan: 0612345678
Bericht: Je rooster is gewijzigd.
```

## Opdracht 6 – Vraag

Nee, ik hoefde LoggingNotificationDecorator niet aan te passen. De decorator kent alleen de interface INotificationService en niet de concrete class. SmsNotificationService implementeert dezelfde interface, dus de decorator werkt er meteen mee.

## Opdracht 7 – UrgentNotificationDecorator

```
public class UrgentNotificationDecorator : NotificationDecorator
{
    public UrgentNotificationDecorator(INotificationService notificationService)
        : base(notificationService)
    {
    }

    public override void Send(string recipient, string message)
    {
        string urgentMessage = "[URGENT] " + message;
        notificationService.Send(recipient, urgentMessage);
    }
}
```

Uitvoer (INotificationService, EmailNotificationService en SmsNotificationService zijn niet aangepast):

```
EMAIL
Aan: student@school.nl
Bericht: [URGENT] Je leslokaal is gewijzigd.
```

## Opdracht 8 – Volg de keten

```
Program
   ↓  Send()
LoggingNotificationDecorator    (schrijft de LOG-regel)
   ↓  Send()
UrgentNotificationDecorator     (zet [URGENT] voor het bericht)
   ↓  Send()
EmailNotificationService        (verstuurt de e-mail)
```

1. Eerst wordt Send() van LoggingNotificationDecorator uitgevoerd, het buitenste object.

2. Daarna Send() van UrgentNotificationDecorator.

3. EmailNotificationService verstuurt uiteindelijk de echte e-mail.

4. Een decorator is zelf een INotificationService (IS-A) en bevat een field van het type INotificationService (HAS-A). Een andere decorator past dus in dat field, net als een gewone service.

## Opdracht 9 – Maakt de volgorde uit?

1. Uitvoer variant A en variant B (deze zijn gelijk):

```
LOG: notificatie naar student@school.nl
EMAIL
Aan: student@school.nl
Bericht: [URGENT] Je rooster is gewijzigd.
```

2. Variant A: Program → LoggingNotificationDecorator → UrgentNotificationDecorator → EmailNotificationService

    Variant B: Program → UrgentNotificationDecorator → LoggingNotificationDecorator → EmailNotificationService

3. Nee, de volgorde van aanroepen is niet hetzelfde. In A wordt eerst gelogd en dan [URGENT] toegevoegd, in B andersom.

4. Ja, de volgorde kan invloed hebben op de uitvoer.

5. Iedere decorator doet zijn werk en geeft het (eventueel aangepaste) bericht door aan het volgende object. Bij Logging + Urgent zie je toevallig geen verschil, omdat de logregel het bericht niet laat zien. Als twee decorators allebei het bericht aanpassen, zie je het wel. Timestamp → Urgent → Email geeft "[URGENT] [14:32] ..." en Urgent → Timestamp → Email geeft "[14:32] [URGENT] ...". De buitenste decorator past het bericht als eerste aan, dus de binnenste decorator zet zijn tekst er als laatste vóór. Ook als de logregel het bericht zou tonen, zou je in A het bericht zonder [URGENT] loggen en in B mét.

## Opdracht 10 – TimestampNotificationDecorator

```
public override void Send(string recipient, string message)
{
    string time = DateTime.Now.ToString("HH:mm");
    notificationService.Send(recipient, $"[{time}] {message}");
}
```

Opbouw van de combinatie Logging → Timestamp → Urgent → Email:

```
INotificationService notification =
    new LoggingNotificationDecorator(
        new TimestampNotificationDecorator(
            new UrgentNotificationDecorator(
                new EmailNotificationService()
            )
        )
    );
```

```
LOG: notificatie naar student@school.nl
EMAIL
Aan: student@school.nl
Bericht: [URGENT] [14:32] Je rooster is gewijzigd.
```

Met SMS vervang je alleen new EmailNotificationService() door new SmsNotificationService(); de decorators blijven hetzelfde. Omdat Timestamp eerder in de keten zit dan Urgent, komt [URGENT] vooraan te staan (zie opdracht 9).

## Opdracht 11 – Vergelijken

1. Dat zie je niet zonder de methode zelf op te zoeken. Het zijn "magic booleans": je weet niet welke true bij urgent, logging of timestamp hoort, en je kunt ze makkelijk in de verkeerde volgorde zetten.

2. De methode krijgt steeds meer parameters, alle bestaande aanroepen moeten aangepast worden, en in Send() komen steeds meer if-statements.

3. De notificatieservice zelf (EmailNotificationService, SmsNotificationService, …). Iedere service moet dan alles kunnen; dat gaat in tegen Single Responsibility en het Open/Closed-principe.

4. b. Decorators, al hangt het wel een beetje af van de situatie.

5. Met decorators heeft iedere class één taak, kun je een nieuwe uitbreiding toevoegen met een nieuwe class zonder bestaande code aan te passen, en zie je aan de opbouw precies wat er gebeurt. Als er maar één simpele optie is die nooit uitgebreid wordt, kan een parameter eenvoudiger zijn, want decorators zorgen voor meer classes en objecten. Zodra er meerdere opties zijn die je wilt combineren, zijn decorators overzichtelijker.

## Opdracht 14 – Pattern Detective

| Situatie | Pattern | Waarom |
|---|---|---|
| A | **Adapter** | de externe service heeft een andere interface (cents/MakePayment) dan mijn applicatie verwacht (euros/Pay). Een adapter maakt die passend. |
| B | **Facade** | één simpele methode StartGame() verbergt het aanroepen van alle subsystemen in de goede volgorde (zie mijn GameFacade in 03-FacadePattern-Game). |
| C | **Decorator** | je pakt de bestaande service in en voegt logging toe zonder de service zelf aan te passen. |
| D | **Adapter** | de WhatsApp-library heeft een andere methode; een adapter laat hem werken als INotificationService (zie WhatsAppNotificationAdapter in 02-AdapterPattern). |
| E | **Decorator** | losse decorators die je naar wens kunt stapelen, zonder class explosion. |

## Opdracht 15 – Adapter, Facade en Decorator

| Pattern | Welk probleem lost het op? | Korte onthoudzin |
|---|---|---|
| Adapter | Een class met een interface die niet past, toch laten werken met de interface die jouw code verwacht (passend maken). | Adapter = passend maken: een verloopstekker. |
| Facade | Een ingewikkeld systeem met veel classes makkelijker maken door er één simpele interface voor te zetten (makkelijker maken). | Facade = makkelijker maken: één knop die alles regelt. |
| Decorator | Gedrag toevoegen aan een object en combineren zonder de originele class aan te passen of voor iedere combinatie een subclass te maken (uitbreiden). | Decorator = uitbreiden: inpakken, laag om laag. |

## Opdracht 16 – Eindopdracht

```
INotificationService eindNotificatie =
    new LoggingNotificationDecorator(
        new TimestampNotificationDecorator(
            new UrgentNotificationDecorator(
                new SmsNotificationService()
            )
        )
    );

eindNotificatie.Send(
    "0612345678",
    "De toets van morgen is verplaatst naar lokaal 2.14."
);
```

Objectstructuur:

```
LoggingNotificationDecorator
   ↓
TimestampNotificationDecorator
   ↓
UrgentNotificationDecorator
   ↓
SmsNotificationService
```

Uitvoer:

```
LOG: notificatie naar 0612345678
SMS
Aan: 0612345678
Bericht: [URGENT] [14:32] De toets van morgen is verplaatst naar lokaal 2.14.
```

Alle objecten werken via INotificationService, en de bestaande notificatieclasses zijn niet aangepast. Code: 05-DecoratorPattern/NotificationApp/Program.cs
