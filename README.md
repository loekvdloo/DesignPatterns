# Design Patterns – Loek van de Loo

Al mijn Design Patterns-opdrachten (C#, .NET 8) in één repo. Open `DesignPatterns.sln` in Visual Studio om alle projecten tegelijk te zien. Elk project kan ook los gestart worden.

| Map | Pattern | Project | Wat zit erin |
|---|---|---|---|
| [`01-StrategyPattern`](01-StrategyPattern/) | Strategy | `StrategyPattern` | Ducks met uitwisselbaar fly-, quack- en swim-gedrag |
| [`02-AdapterPattern`](02-AdapterPattern/) | Adapter | `ConsoleApp2` | NotificationApp met `WhatsAppNotificationAdapter` voor een externe WhatsApp-library |
| [`03-FacadePattern-Game`](03-FacadePattern-Game/) | Facade | `ConsoleApp3` | `GameFacade` die Graphics, Audio, Save, Network en GameEngine start |
| [`04-FacadePattern-HomeTheater`](04-FacadePattern-HomeTheater/) | Facade + Principle of Least Knowledge | `ConsoleApp4` | `HomeTheaterFacade` en de antwoorden over de Law of Demeter |
| [`05-DecoratorPattern`](05-DecoratorPattern/) | Decorator | `NotificationApp` | Logging-, Urgent- en Timestamp-decorators en de uitwerking van het Decorator-document |

## Decorator-opdracht

- Code: [`05-DecoratorPattern/NotificationApp`](05-DecoratorPattern/NotificationApp/)
  - `Decorators/` – `NotificationDecorator`, `LoggingNotificationDecorator`, `UrgentNotificationDecorator`, `TimestampNotificationDecorator`
  - `Inheritance/` – de inheritance-versies uit opdracht 2 en 3 (om de class explosion te laten zien)
  - `Program.cs` – voert alle opdrachten na elkaar uit, inclusief de eindopdracht
- Antwoorden: [`05-DecoratorPattern/ANTWOORDEN.md`](05-DecoratorPattern/ANTWOORDEN.md) en het ingevulde Word-document in dezelfde map

### Eindopdracht – objectstructuur

```
LoggingNotificationDecorator
   ↓
TimestampNotificationDecorator
   ↓
UrgentNotificationDecorator
   ↓
SmsNotificationService
```
